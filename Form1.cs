using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LabDatos;

public partial class Form1 : Form
{
    // ── Gestores ─────────────────────────────────────────────────────────────
    private readonly GestorArchivos _gestorArchivos = new();
    private readonly GestorIndice _gestorIndice = new();

    // ── Estado interno ────────────────────────────────────────────────────────
    private string _connString = @"Server=.\SQLEXPRESS;Database=LabDatos;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";
    private int? _posicionEditando = null;   // null = modo "nuevo registro"

    // ─────────────────────────────────────────────────────────────────────────
    public Form1()
    {
        InitializeComponent();

        // Configurar columnas del DataGridView de registros
        ConfigurarDgvRegistros1();

        // Mostrar info inicial
        Log1("════════════════════════════════════════", LogCat.Separador);
        Log1("  Lab: Arquitecto de Datos  —  Nivel 1 ", LogCat.Separador);
        Log1("════════════════════════════════════════", LogCat.Separador);
        Log1($"Registro: {Ciudadano.Size} bytes  (Id:4 + Nombre:50 + Edad:4)", LogCat.Detalle);
        Log1($"Archivo : {Path.GetFullPath(_gestorArchivos.ArchivoPath)}", LogCat.Detalle);

        ActualizarIdAuto();
        ActualizarNextPos();
        ActualizarListaRegistros();
    }

    // ═════════════════════════════════════════════════════════════════════════
    //  NIVEL 1 – El Escriba
    // ═════════════════════════════════════════════════════════════════════════

    // ── Guardar (también funciona como Modificar en modo edición) ─────────────
    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtEdad.Text.Trim(), out int edad))
        {
            MessageBox.Show("La Edad debe ser un número entero.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (!int.TryParse(txtPosicion.Text.Trim(), out int posicion) || posicion < 0)
        {
            MessageBox.Show("La Posición debe ser un número entero ≥ 0.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("El nombre no puede estar vacío.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // El ID: en modo edición se conserva el original; en modo nuevo es el auto-ID
        int id = int.Parse(lblIdAuto.Text);
        var ciudadano = new Ciudadano(id, txtNombre.Text.Trim(), edad);
        long offset = (long)posicion * Ciudadano.Size;

        if (_posicionEditando.HasValue)
        {
            // ── MODIFICAR ───────────────────────────────────────────────────
            bool ok = _gestorArchivos.ModificarCiudadano(ciudadano, posicion);
            if (ok)
            {
                Log1("", LogCat.Separador);
                Log1($"✅ Registro modificado exitosamente", LogCat.Exito);
                Log1($"   {ciudadano}", LogCat.Detalle);
                Log1($"   Posición #{posicion}  →  Offset = {offset} bytes  (0x{offset:X4})", LogCat.Detalle);
            }
            else
            {
                Log1("❌ No se pudo modificar: posición fuera del archivo.", LogCat.Error);
            }
            SalirModoEdicion();
        }
        else
        {
            // ── GUARDAR NUEVO ───────────────────────────────────────────────
            _gestorArchivos.GuardarCiudadano(ciudadano, posicion);

            Log1("", LogCat.Separador);
            Log1($"✅ Registro guardado exitosamente", LogCat.Exito);
            Log1($"   {ciudadano}", LogCat.Detalle);
            Log1($"   Posición #{posicion}  →  Offset = {posicion} × {Ciudadano.Size} = {offset} bytes  (0x{offset:X4})", LogCat.Detalle);
            Log1($"   Slots en archivo: {_gestorArchivos.ContarSlots()}  |  Registros activos: {_gestorArchivos.ContarRegistros()}", LogCat.Detalle);
        }

        ActualizarIdAuto();
        ActualizarNextPos();
        ActualizarListaRegistros();
    }

    // ── Cancelar edición ─────────────────────────────────────────────────────
    private void btnCancelarEdicion_Click(object sender, EventArgs e)
    {
        SalirModoEdicion();
        Log1("ℹ️  Edición cancelada. Modo: Nuevo registro.", LogCat.Info);
    }

    // ── Leer por posición (seek directo) ─────────────────────────────────────
    private void btnLeer_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtPosLectura.Text.Trim(), out int posicion))
        {
            MessageBox.Show("La posición debe ser un número entero.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        long offset = (long)posicion * Ciudadano.Size;
        var ciudadano = _gestorArchivos.LeerCiudadano(posicion);

        Log1("", LogCat.Separador);
        if (ciudadano is null)
        {
            lblResultado1.Text = "❌  Posición vacía, eliminada o fuera del archivo.";
            Log1($"⚠️  Seek a posición #{posicion}  (offset {offset} bytes)  →  sin registro activo", LogCat.Aviso);
        }
        else
        {
            lblResultado1.Text = ciudadano.Value.ToString();
            Log1($"📂  Seek a posición #{posicion}  (offset {offset} bytes)", LogCat.Accion);
            Log1($"   {ciudadano.Value}", LogCat.Detalle);
        }
    }

    // ── Cargar registro para editar (desde el grupo de edición) ──────────────
    private void btnCargarEditar_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtPosEditar.Text.Trim(), out int posicion))
        {
            MessageBox.Show("La posición debe ser un número entero.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        CargarRegistroParaEditar(posicion);
    }

    // ── Eliminar registro ─────────────────────────────────────────────────────
    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtPosEditar.Text.Trim(), out int posicion))
        {
            MessageBox.Show("Ingresa una posición válida.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var c = _gestorArchivos.LeerCiudadano(posicion);
        string desc = c.HasValue
            ? $"Posición #{posicion}  —  {c.Value}"
            : $"Posición #{posicion}  (vacía)";

        var confirm = MessageBox.Show(
            $"¿Eliminar el siguiente registro?\n\n{desc}\n\n" +
            "La posición quedará marcada como eliminada (bytes en cero).",
            "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (confirm != DialogResult.Yes) return;

        bool ok = _gestorArchivos.EliminarCiudadano(posicion);

        Log1("", LogCat.Separador);
        if (ok)
        {
            Log1($"🗑️  Registro en posición #{posicion} eliminado.", LogCat.Accion);
            Log1($"   Registros activos restantes: {_gestorArchivos.ContarRegistros()}", LogCat.Detalle);
        }
        else
        {
            Log1($"❌ No se pudo eliminar: posición #{posicion} fuera del archivo.", LogCat.Error);
        }

        if (_posicionEditando == posicion) SalirModoEdicion();
        ActualizarIdAuto();
        ActualizarNextPos();
        ActualizarListaRegistros();
    }

    // ── Agregar 1 000 registros masivos ──────────────────────────────────────
    private async void btnAgregar1000_Click(object sender, EventArgs e)
    {
        btnAgregar1000.Enabled = false;
        btnGuardar.Enabled = false;
        btnAgregar1000.Text = "⏳  Insertando...";

        int nextId = _gestorArchivos.GetNextId();
        int startPos = _gestorArchivos.ContarSlots();

        Log1("", LogCat.Separador);
        Log1($"🚀  Iniciando inserción masiva de 1 000 registros...", LogCat.Accion);
        Log1($"   ID inicial: {nextId}  |  Posición inicial: {startPos}", LogCat.Detalle);

        var progreso = new Progress<(int Hechos, int Total)>(p =>
        {
            if (p.Hechos % 200 == 0 || p.Hechos == p.Total)
                Log1($"   → {p.Hechos} / {p.Total} registros insertados...", LogCat.Detalle);
        });

        int total = await _gestorArchivos.AgregarMasivoAsync(1000, progreso);

        Log1($"✅  Inserción masiva completada: {total} registros.", LogCat.Exito);
        Log1($"   Slots totales: {_gestorArchivos.ContarSlots()}  |  Registros activos: {_gestorArchivos.ContarRegistros()}", LogCat.Detalle);

        ActualizarIdAuto();
        ActualizarNextPos();
        ActualizarListaRegistros();

        btnAgregar1000.Text = "🚀  Agregar 1 000 registros aleatorios";
        btnAgregar1000.Enabled = true;
        btnGuardar.Enabled = true;
    }

    // ── Actualizar lista de registros ─────────────────────────────────────────
    private void btnActualizarLista1_Click(object sender, EventArgs e)
    {
        ActualizarListaRegistros();
    }

    // ── Doble clic en la lista para editar ────────────────────────────────────
    private void dgvRegistros1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var row = dgvRegistros1.Rows[e.RowIndex];
        if (row.Cells["Pos"] == null) return;
        int posicion = (int)row.Cells["Pos"].Value;
        CargarRegistroParaEditar(posicion);
    }

    // ═════════════════════════════════════════════════════════════════════════
    //  NIVEL 2 – El Indexador
    // ═════════════════════════════════════════════════════════════════════════

    private void btnConstruirIndice_Click(object sender, EventArgs e)
    {
        try
        {
            int total = _gestorIndice.ConstruirIndice();
            lblInfoIndice.Text = $"✅ {total} entradas";

            Log2("", LogCat.Separador);
            Log2($"🔨  Índice construido exitosamente", LogCat.Exito);
            Log2($"   Registros mapeados: {total}", LogCat.Detalle);
            Log2($"   Archivo: {Path.GetFullPath(_gestorIndice.IndexPath)}", LogCat.Detalle);
            Log2($"   Estructura: Id(4 bytes) + Posición(4 bytes) = 8 bytes/entrada", LogCat.Detalle);
            Log2($"   Tamaño total del índice: {total * 8} bytes", LogCat.Detalle);
        }
        catch (Exception ex)
        {
            Log2($"❌  {ex.Message}", LogCat.Error);
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnBuscarSec_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtBuscarId.Text.Trim(), out int id))
        {
            MessageBox.Show("El ID debe ser un número entero.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var sw = Stopwatch.StartNew();
        var resultado = _gestorArchivos.BuscarSecuencial(id);
        sw.Stop();

        lblTiempoSec.Text = $"{sw.Elapsed.TotalMilliseconds:F4} ms";
        ActualizarResultado2(resultado, id, "Secuencial");

        Log2("", LogCat.Separador);
        Log2($"🔁  Búsqueda SECUENCIAL — ID = {id}", LogCat.Accion);
        Log2($"   Recorrió hasta {_gestorArchivos.ContarSlots()} slots  |  Tiempo: {sw.Elapsed.TotalMilliseconds:F4} ms", LogCat.Detalle);
        Log2($"   → {(resultado is null ? "No encontrado" : resultado.Value.ToString())}", resultado is null ? LogCat.Aviso : LogCat.Exito);
    }

    private void btnBuscarIdx_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtBuscarId.Text.Trim(), out int id))
        {
            MessageBox.Show("El ID debe ser un número entero.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!_gestorIndice.IndiceExiste)
        {
            MessageBox.Show("Primero construye el índice.", "Índice no existe",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var sw = Stopwatch.StartNew();
        var (resultado, posicion) = _gestorIndice.BuscarPorIndice(id, _gestorArchivos);
        sw.Stop();

        lblTiempoIdx.Text = $"{sw.Elapsed.TotalMilliseconds:F4} ms";
        ActualizarResultado2(resultado, id, "Indexada");

        Log2("", LogCat.Separador);
        Log2($"⚡  Búsqueda INDEXADA — ID = {id}", LogCat.Accion);
        Log2($"   Seek directo a posición #{posicion}  |  Tiempo: {sw.Elapsed.TotalMilliseconds:F4} ms", LogCat.Detalle);
        Log2($"   → {(resultado is null ? "No encontrado" : resultado.Value.ToString())}", resultado is null ? LogCat.Aviso : LogCat.Exito);
    }

    private void ActualizarResultado2(Ciudadano? c, int id, string metodo)
    {
        lblResultado2.Text = c is null
            ? $"[{metodo}]  ID {id}  →  No encontrado"
            : $"[{metodo}]  {c.Value}";
    }

    // ═════════════════════════════════════════════════════════════════════════
    //  NIVEL 3 – SQL Server
    // ═════════════════════════════════════════════════════════════════════════

    private void btnConfigurarConexion_Click(object sender, EventArgs e)
    {
        using var dlg = new DialogConexion(_connString);
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        _connString = dlg.ConnectionString;
        txtConnStr.Text = dlg.MaskedConnectionString;   // muestra contraseña enmascarada
        txtConnStr.ForeColor = System.Drawing.Color.DimGray;

        Log3("", LogCat.Separador);
        Log3("⚙️  Cadena de conexión actualizada.", LogCat.Accion);
        Log3($"   {dlg.MaskedConnectionString}", LogCat.Detalle);
    }

    private async void btnMigrar_Click(object sender, EventArgs e)
    {
        if (!File.Exists(_gestorArchivos.ArchivoPath))
        {
            MessageBox.Show("Primero guarda registros en el Nivel 1.", "Archivo no existe",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnMigrar.Enabled = false;
        lblEstadoMig.Text = "⏳ Migrando...";

        try
        {
            var migrador = new MigradorSql(_connString);

            Log3("", LogCat.Separador);
            Log3("🔗  Conectando a SQL Server...", LogCat.Accion);
            await migrador.CrearTablaAsync();
            Log3("📋  Tabla 'Ciudadanos' verificada / creada.", LogCat.Info);

            var progreso = new Progress<string>(msg =>
            {
                var cat = msg.StartsWith("⚠") ? LogCat.Aviso :
                          msg.Contains("completa") ? LogCat.Exito : LogCat.Detalle;
                Log3("   " + msg, cat);
            });

            int total = await migrador.MigrarDesdeArchivoAsync(_gestorArchivos.ArchivoPath, progreso);

            lblEstadoMig.Text = $"✅ {total} registros";
            Log3($"🎉  Migración completa: {total} registros insertados en SQL Server.", LogCat.Exito);
        }
        catch (Exception ex)
        {
            lblEstadoMig.Text = "❌ Error";
            Log3($"❌  Error de conexión: {ex.Message}", LogCat.Error);
            MessageBox.Show($"No se pudo conectar a SQL Server:\n\n{ex.Message}",
                            "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnMigrar.Enabled = true;
        }
    }

    private async void btnSelect_Click(object sender, EventArgs e)
    {
        btnSelect.Enabled = false;

        try
        {
            var migrador = new MigradorSql(_connString);
            var lista = await migrador.ConsultarTodosAsync();

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Edad", typeof(int));
            foreach (var c in lista)
                dt.Rows.Add(c.Id, c.Nombre.TrimEnd(), c.Edad);

            dgvResultados.DataSource = dt;

            Log3("", LogCat.Separador);
            Log3($"📊  SELECT * FROM Ciudadanos  →  {lista.Count} registros obtenidos.", LogCat.Exito);
        }
        catch (Exception ex)
        {
            Log3($"❌  Error al consultar: {ex.Message}", LogCat.Error);
            MessageBox.Show($"Error al ejecutar SELECT:\n\n{ex.Message}",
                            "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSelect.Enabled = true;
        }
    }

    // ═════════════════════════════════════════════════════════════════════════
    //  Helpers de estado (modo edición / modo nuevo)
    // ═════════════════════════════════════════════════════════════════════════

    private void CargarRegistroParaEditar(int posicion)
    {
        var c = _gestorArchivos.LeerCiudadano(posicion);
        if (c is null)
        {
            MessageBox.Show($"La posición #{posicion} está vacía o eliminada.", "Sin registro",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Rellenar campos
        lblIdAuto.Text = c.Value.Id.ToString();
        txtNombre.Text = c.Value.Nombre;
        txtEdad.Text = c.Value.Edad.ToString();
        txtPosicion.Text = posicion.ToString();
        txtPosEditar.Text = posicion.ToString();

        _posicionEditando = posicion;

        // Actualizar UI para modo edición
        lblModoActual.Text = $"✏️  Editando posición #{posicion}  (ID: {c.Value.Id})";
        lblModoActual.ForeColor = System.Drawing.Color.DarkOrange;
        btnGuardar.Text = "💾  Guardar Cambios";
        btnCancelarEdicion.Visible = true;

        Log1("", LogCat.Separador);
        Log1($"✏️  Cargado para editar — posición #{posicion}", LogCat.Accion);
        Log1($"   {c.Value}", LogCat.Detalle);
    }

    private void SalirModoEdicion()
    {
        _posicionEditando = null;

        lblModoActual.Text = "➕  Nuevo registro";
        lblModoActual.ForeColor = System.Drawing.Color.SteelBlue;
        btnGuardar.Text = "💾  Guardar Registro";
        btnCancelarEdicion.Visible = false;

        txtNombre.Text = "Juan Pérez";
        txtEdad.Text = "25";

        ActualizarIdAuto();
        ActualizarNextPos();
    }

    // ═════════════════════════════════════════════════════════════════════════
    //  Helpers de actualización de controles
    // ═════════════════════════════════════════════════════════════════════════

    private void ActualizarIdAuto()
    {
        int next = _gestorArchivos.GetNextId();
        lblIdAuto.Text = next.ToString();
    }

    private void ActualizarNextPos()
    {
        // Solo actualizamos si no estamos en modo edición
        if (!_posicionEditando.HasValue)
            txtPosicion.Text = _gestorArchivos.ContarSlots().ToString();
    }

    private void ActualizarListaRegistros()
    {
        var todos = _gestorArchivos.LeerTodos();

        var dt = new DataTable();
        dt.Columns.Add("Pos", typeof(int));
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Nombre", typeof(string));
        dt.Columns.Add("Edad", typeof(int));

        foreach (var (pos, c) in todos)
            dt.Rows.Add(pos, c.Id, c.Nombre.TrimEnd(), c.Edad);

        dgvRegistros1.DataSource = dt;
        lblTotalReg1.Text = $"Total: {todos.Count} registro{(todos.Count != 1 ? "s" : "")}  " +
                            $"({_gestorArchivos.ContarSlots()} slots en archivo)";

        // Ajustar anchos: Pos y Edad más estrecho, Nombre ancho
        if (dgvRegistros1.Columns.Count >= 4)
        {
            dgvRegistros1.Columns["Pos"].FillWeight = 8;
            dgvRegistros1.Columns["ID"].FillWeight = 10;
            dgvRegistros1.Columns["Nombre"].FillWeight = 60;
            dgvRegistros1.Columns["Edad"].FillWeight = 10;
        }
    }

    private void ConfigurarDgvRegistros1()
    {
        dgvRegistros1.RowHeadersVisible = false;
        dgvRegistros1.EnableHeadersVisualStyles = false;
        dgvRegistros1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
        dgvRegistros1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        dgvRegistros1.ColumnHeadersDefaultCellStyle.Font =
            new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        dgvRegistros1.AlternatingRowsDefaultCellStyle.BackColor =
            System.Drawing.Color.FromArgb(240, 245, 255);
    }

    // ═════════════════════════════════════════════════════════════════════════
    //  Log con colores
    // ═════════════════════════════════════════════════════════════════════════

    private enum LogCat { Info, Exito, Error, Aviso, Separador, Accion, Detalle }

    private void Log1(string msg, LogCat cat = LogCat.Info) => AppendLog(rtbLog1, msg, cat);
    private void Log2(string msg, LogCat cat = LogCat.Info) => AppendLog(rtbLog2, msg, cat);
    private void Log3(string msg, LogCat cat = LogCat.Info) => AppendLog(rtbLog3, msg, cat);

    private static void AppendLog(RichTextBox rtb, string msg, LogCat cat)
    {
        if (rtb.InvokeRequired)
        {
            rtb.Invoke(() => AppendLog(rtb, msg, cat));
            return;
        }

        // Colores por categoría
        System.Drawing.Color msgColor = cat switch
        {
            LogCat.Exito => System.Drawing.Color.FromArgb(0, 255, 128),
            LogCat.Error => System.Drawing.Color.FromArgb(255, 80, 80),
            LogCat.Aviso => System.Drawing.Color.FromArgb(255, 200, 50),
            LogCat.Separador => System.Drawing.Color.FromArgb(60, 60, 80),
            LogCat.Accion => System.Drawing.Color.FromArgb(80, 180, 255),
            LogCat.Detalle => System.Drawing.Color.FromArgb(140, 140, 160),
            _ => System.Drawing.Color.FromArgb(0, 215, 0),
        };

        bool esSeparador = cat == LogCat.Separador || msg.StartsWith("═") || msg.StartsWith("─");

        // Separadores: sin timestamp para no ensuciar
        if (!esSeparador)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;
            rtb.SelectionColor = System.Drawing.Color.FromArgb(70, 70, 90);  // timestamp dim
            rtb.AppendText($"[{DateTime.Now:HH:mm:ss}] ");
        }

        rtb.SelectionStart = rtb.TextLength;
        rtb.SelectionLength = 0;
        rtb.SelectionColor = msgColor;
        rtb.AppendText(msg + Environment.NewLine);

        rtb.ScrollToCaret();
    }
}