using System.Data;
using System.Diagnostics;

namespace LabDatos;

public partial class Form1 : Form
{
    private readonly GestorArchivos _gestorArchivos = new();
    private readonly GestorIndice   _gestorIndice   = new();

    public Form1()
    {
        InitializeComponent();
        Log1($"Tamaño de registro (Ciudadano.Size): {Ciudadano.Size} bytes");
        Log1($"  → Id(4) + Nombre(50) + Edad(4) = 58 bytes");
        Log1($"Archivo de datos: {Path.GetFullPath(_gestorArchivos.ArchivoPath)}");
        Log1("─────────────────────────────────────────");
    }

    // ===========================================================
    //  NIVEL 1 – El Escriba
    // ===========================================================

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtId.Text.Trim(), out int id)      ||
            !int.TryParse(txtEdad.Text.Trim(), out int edad)  ||
            !int.TryParse(txtPosicion.Text.Trim(), out int posicion))
        {
            MessageBox.Show("ID, Edad y Posición deben ser números enteros.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("El nombre no puede estar vacío.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var ciudadano = new Ciudadano(id, txtNombre.Text.Trim(), edad);
        long offset   = (long)posicion * Ciudadano.Size;

        _gestorArchivos.GuardarCiudadano(ciudadano, posicion);

        Log1($"✅ Guardado exitoso:");
        Log1($"   {ciudadano}");
        Log1($"   Posición #{posicion}  →  Offset = {posicion} × {Ciudadano.Size} = {offset} bytes  (0x{offset:X4})");
        Log1($"   Total en archivo: {_gestorArchivos.ContarRegistros()} reg  |  {_gestorArchivos.TamanioArchivo()} bytes");
        Log1("─────────────────────────────────────────");
    }

    private void btnLeer_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtPosLectura.Text.Trim(), out int posicion))
        {
            MessageBox.Show("La posición debe ser un número entero.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        long offset       = (long)posicion * Ciudadano.Size;
        var  ciudadano    = _gestorArchivos.LeerCiudadano(posicion);

        if (ciudadano is null)
        {
            lblResultado1.Text = "❌ Posición vacía o fuera del archivo.";
            Log1($"⚠  Posición #{posicion}  →  Offset {offset} bytes  →  sin registro");
        }
        else
        {
            lblResultado1.Text = ciudadano.Value.ToString();
            Log1($"📂 Leído en posición #{posicion}  (offset {offset} bytes):");
            Log1($"   {ciudadano.Value}");
        }
        Log1("─────────────────────────────────────────");
    }

    // ===========================================================
    //  NIVEL 2 – El Indexador
    // ===========================================================

    private void btnConstruirIndice_Click(object sender, EventArgs e)
    {
        try
        {
            int total         = _gestorIndice.ConstruirIndice();
            lblInfoIndice.Text = $"✅ {total} entradas";

            Log2($"✅ Índice construido: {total} registros mapeados");
            Log2($"   Archivo: {Path.GetFullPath(_gestorIndice.IndexPath)}");
            Log2($"   Cada entrada del índice: Id(4 bytes) + Posición(4 bytes) = 8 bytes");
            Log2($"   Tamaño total del índice: {total * 8} bytes");
            Log2("─────────────────────────────────────────");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log2($"❌ {ex.Message}");
        }
    }

    private void btnBuscarSec_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtBuscarId.Text.Trim(), out int id))
        {
            MessageBox.Show("El ID debe ser un número entero.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var sw        = Stopwatch.StartNew();
        var resultado = _gestorArchivos.BuscarSecuencial(id);
        sw.Stop();

        lblTiempoSec.Text = $"{sw.Elapsed.TotalMilliseconds:F4} ms";
        ActualizarResultado2(resultado, id, "Secuencial");

        int  total = _gestorArchivos.ContarRegistros();
        Log2($"🔁 Búsqueda secuencial  ID={id}");
        Log2($"   Recorrió hasta {total} registros  |  Tiempo: {sw.Elapsed.TotalMilliseconds:F4} ms");
        Log2($"   → {(resultado is null ? "No encontrado" : resultado.Value.ToString())}");
        Log2("─────────────────────────────────────────");
    }

    private void btnBuscarIdx_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtBuscarId.Text.Trim(), out int id))
        {
            MessageBox.Show("El ID debe ser un número entero.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!_gestorIndice.IndiceExiste)
        {
            MessageBox.Show("Primero construye el índice con el botón de arriba.",
                            "Índice no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var sw = Stopwatch.StartNew();
        var (resultado, posicion) = _gestorIndice.BuscarPorIndice(id, _gestorArchivos);
        sw.Stop();

        lblTiempoIdx.Text = $"{sw.Elapsed.TotalMilliseconds:F4} ms";
        ActualizarResultado2(resultado, id, "Indexada");

        Log2($"⚡ Búsqueda indexada    ID={id}");
        Log2($"   Seek directo a posición #{posicion}  |  Tiempo: {sw.Elapsed.TotalMilliseconds:F4} ms");
        Log2($"   → {(resultado is null ? "No encontrado" : resultado.Value.ToString())}");
        Log2("─────────────────────────────────────────");
    }

    private void ActualizarResultado2(Ciudadano? c, int id, string metodo)
    {
        lblResultado2.Text = c is null
            ? $"[{metodo}] ID {id} → No encontrado"
            : $"[{metodo}] {c.Value}";
    }

    // ===========================================================
    //  NIVEL 3 – SQL Server
    // ===========================================================

    private async void btnMigrar_Click(object sender, EventArgs e)
    {
        if (!File.Exists(_gestorArchivos.ArchivoPath))
        {
            MessageBox.Show("Primero guarda registros en el Nivel 1.",
                            "Archivo no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnMigrar.Enabled  = false;
        lblEstadoMig.Text  = "Migrando...";

        try
        {
            var migrador = new MigradorSql(txtConnStr.Text.Trim());

            Log3("🔗 Conectando a SQL Server...");
            await migrador.CrearTablaAsync();
            Log3("📋 Tabla 'Ciudadanos' verificada / creada.");

            var progreso = new Progress<string>(msg => Log3("   " + msg));
            int total    = await migrador.MigrarDesdeArchivoAsync(
                               _gestorArchivos.ArchivoPath, progreso);

            lblEstadoMig.Text = $"✅ {total} registros";
            Log3($"🎉 Listo: {total} registros migrados a SQL Server.");
        }
        catch (Exception ex)
        {
            lblEstadoMig.Text = "❌ Error";
            Log3($"❌ Error de conexión: {ex.Message}");
            MessageBox.Show($"No se pudo conectar a SQL Server:\n\n{ex.Message}",
                            "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnMigrar.Enabled = true;
        }

        Log3("─────────────────────────────────────────");
    }

    private async void btnSelect_Click(object sender, EventArgs e)
    {
        btnSelect.Enabled = false;

        try
        {
            var migrador = new MigradorSql(txtConnStr.Text.Trim());
            var lista    = await migrador.ConsultarTodosAsync();

            // Llenar DataGridView con los resultados
            var dt = new DataTable();
            dt.Columns.Add("Id",     typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Edad",   typeof(int));

            foreach (var c in lista)
                dt.Rows.Add(c.Id, c.Nombre.TrimEnd(), c.Edad);

            dgvResultados.DataSource = dt;

            Log3($"📊 SELECT * FROM Ciudadanos  →  {lista.Count} registros obtenidos.");
        }
        catch (Exception ex)
        {
            Log3($"❌ Error al consultar: {ex.Message}");
            MessageBox.Show($"Error al ejecutar SELECT:\n\n{ex.Message}",
                            "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSelect.Enabled = true;
        }

        Log3("─────────────────────────────────────────");
    }

    // ===========================================================
    //  Helpers de log
    // ===========================================================
    private void Log1(string msg) => AppendLog(rtbLog1, msg);
    private void Log2(string msg) => AppendLog(rtbLog2, msg);
    private void Log3(string msg) => AppendLog(rtbLog3, msg);

    private static void AppendLog(RichTextBox rtb, string msg)
    {
        rtb.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}{Environment.NewLine}");
        rtb.ScrollToCaret();
    }
}
