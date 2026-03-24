namespace LabDatos
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ── TabControl ───────────────────────────────────────────────────────
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabNivel1 = new System.Windows.Forms.TabPage();
            this.tabNivel2 = new System.Windows.Forms.TabPage();
            this.tabNivel3 = new System.Windows.Forms.TabPage();

            // ── TAB 1 controls ───────────────────────────────────────────────────
            this.grpGuardar = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblIdAuto = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblPosicion = new System.Windows.Forms.Label();
            this.txtPosicion = new System.Windows.Forms.TextBox();
            this.lblOffsetHint = new System.Windows.Forms.Label();
            this.lblModoActual = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelarEdicion = new System.Windows.Forms.Button();
            this.btnAgregar1000 = new System.Windows.Forms.Button();

            this.grpLeer = new System.Windows.Forms.GroupBox();
            this.lblPosLectura = new System.Windows.Forms.Label();
            this.txtPosLectura = new System.Windows.Forms.TextBox();
            this.btnLeer = new System.Windows.Forms.Button();
            this.lblResultado1 = new System.Windows.Forms.Label();

            this.grpEditar = new System.Windows.Forms.GroupBox();
            this.lblHintEditar = new System.Windows.Forms.Label();
            this.lblPosEditar = new System.Windows.Forms.Label();
            this.txtPosEditar = new System.Windows.Forms.TextBox();
            this.btnCargarEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();

            this.grpRegistros1 = new System.Windows.Forms.GroupBox();
            this.btnActualizarLista1 = new System.Windows.Forms.Button();
            this.lblTotalReg1 = new System.Windows.Forms.Label();
            this.dgvRegistros1 = new System.Windows.Forms.DataGridView();

            this.grpLog1 = new System.Windows.Forms.GroupBox();
            this.rtbLog1 = new System.Windows.Forms.RichTextBox();

            // ── TAB 2 controls ───────────────────────────────────────────────────
            this.grpIndice = new System.Windows.Forms.GroupBox();
            this.btnConstruirIndice = new System.Windows.Forms.Button();
            this.lblInfoIndice = new System.Windows.Forms.Label();
            this.grpBusqueda = new System.Windows.Forms.GroupBox();
            this.lblBuscarId = new System.Windows.Forms.Label();
            this.txtBuscarId = new System.Windows.Forms.TextBox();
            this.btnBuscarSec = new System.Windows.Forms.Button();
            this.btnBuscarIdx = new System.Windows.Forms.Button();
            this.lblTiempoSecLabel = new System.Windows.Forms.Label();
            this.lblTiempoSec = new System.Windows.Forms.Label();
            this.lblTiempoIdxLabel = new System.Windows.Forms.Label();
            this.lblTiempoIdx = new System.Windows.Forms.Label();
            this.lblResultado2 = new System.Windows.Forms.Label();
            this.grpLog2 = new System.Windows.Forms.GroupBox();
            this.rtbLog2 = new System.Windows.Forms.RichTextBox();

            // ── TAB 3 controls ───────────────────────────────────────────────────
            this.grpConexion = new System.Windows.Forms.GroupBox();
            this.lblConnStr = new System.Windows.Forms.Label();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.btnConfigurarConexion = new System.Windows.Forms.Button();
            this.grpMigracion = new System.Windows.Forms.GroupBox();
            this.btnMigrar = new System.Windows.Forms.Button();
            this.lblEstadoMig = new System.Windows.Forms.Label();
            this.grpConsulta = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.grpLog3 = new System.Windows.Forms.GroupBox();
            this.rtbLog3 = new System.Windows.Forms.RichTextBox();
            this.dgvResultados = new System.Windows.Forms.DataGridView();

            // ── SuspendLayout ────────────────────────────────────────────────────
            this.tabControl.SuspendLayout();
            this.tabNivel1.SuspendLayout();
            this.tabNivel2.SuspendLayout();
            this.tabNivel3.SuspendLayout();
            this.grpGuardar.SuspendLayout();
            this.grpLeer.SuspendLayout();
            this.grpEditar.SuspendLayout();
            this.grpRegistros1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvRegistros1).BeginInit();
            this.grpLog1.SuspendLayout();
            this.grpIndice.SuspendLayout();
            this.grpBusqueda.SuspendLayout();
            this.grpLog2.SuspendLayout();
            this.grpConexion.SuspendLayout();
            this.grpMigracion.SuspendLayout();
            this.grpConsulta.SuspendLayout();
            this.grpLog3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvResultados).BeginInit();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════════════
            //  tabControl
            // ════════════════════════════════════════════════════════════════════
            this.tabControl.Controls.Add(this.tabNivel1);
            this.tabControl.Controls.Add(this.tabNivel2);
            this.tabControl.Controls.Add(this.tabNivel3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1020, 720);
            this.tabControl.TabIndex = 0;

            // ════════════════════════════════════════════════════════════════════
            //  TAB 1 – Nivel 1: El Escriba
            // ════════════════════════════════════════════════════════════════════
            this.tabNivel1.Controls.Add(this.grpGuardar);
            this.tabNivel1.Controls.Add(this.grpLeer);
            this.tabNivel1.Controls.Add(this.grpEditar);
            this.tabNivel1.Controls.Add(this.grpRegistros1);
            this.tabNivel1.Controls.Add(this.grpLog1);
            this.tabNivel1.Location = new System.Drawing.Point(4, 24);
            this.tabNivel1.Name = "tabNivel1";
            this.tabNivel1.Padding = new System.Windows.Forms.Padding(3);
            this.tabNivel1.Size = new System.Drawing.Size(1012, 692);
            this.tabNivel1.TabIndex = 0;
            this.tabNivel1.Text = "  Nivel 1: El Escriba  ";
            this.tabNivel1.UseVisualStyleBackColor = true;

            // ── grpGuardar (left, top) ───────────────────────────────────────────
            this.grpGuardar.Controls.Add(this.lblId);
            this.grpGuardar.Controls.Add(this.lblIdAuto);
            this.grpGuardar.Controls.Add(this.lblNombre);
            this.grpGuardar.Controls.Add(this.txtNombre);
            this.grpGuardar.Controls.Add(this.lblEdad);
            this.grpGuardar.Controls.Add(this.txtEdad);
            this.grpGuardar.Controls.Add(this.lblPosicion);
            this.grpGuardar.Controls.Add(this.txtPosicion);
            this.grpGuardar.Controls.Add(this.lblOffsetHint);
            this.grpGuardar.Controls.Add(this.lblModoActual);
            this.grpGuardar.Controls.Add(this.btnGuardar);
            this.grpGuardar.Controls.Add(this.btnCancelarEdicion);
            this.grpGuardar.Controls.Add(this.btnAgregar1000);
            this.grpGuardar.Location = new System.Drawing.Point(10, 10);
            this.grpGuardar.Name = "grpGuardar";
            this.grpGuardar.Size = new System.Drawing.Size(340, 272);
            this.grpGuardar.TabIndex = 0;
            this.grpGuardar.TabStop = false;
            this.grpGuardar.Text = "Guardar / Editar Ciudadano";

            // ID (auto)
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 32);
            this.lblId.Text = "ID (auto):";

            this.lblIdAuto.AutoSize = false;
            this.lblIdAuto.Location = new System.Drawing.Point(120, 30);
            this.lblIdAuto.Size = new System.Drawing.Size(200, 20);
            this.lblIdAuto.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIdAuto.ForeColor = System.Drawing.Color.DimGray;
            this.lblIdAuto.Text = "1";

            // Nombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 64);
            this.lblNombre.Text = "Nombre:";

            this.txtNombre.Location = new System.Drawing.Point(120, 61);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(205, 23);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Text = "Juan Pérez";

            // Edad
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(12, 96);
            this.lblEdad.Text = "Edad:";

            this.txtEdad.Location = new System.Drawing.Point(120, 93);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(70, 23);
            this.txtEdad.TabIndex = 1;
            this.txtEdad.Text = "25";

            // Posición
            this.lblPosicion.AutoSize = true;
            this.lblPosicion.Location = new System.Drawing.Point(12, 128);
            this.lblPosicion.Text = "Posición en archivo:";

            this.txtPosicion.Location = new System.Drawing.Point(172, 125);
            this.txtPosicion.Name = "txtPosicion";
            this.txtPosicion.Size = new System.Drawing.Size(70, 23);
            this.txtPosicion.TabIndex = 2;
            this.txtPosicion.Text = "0";

            this.lblOffsetHint.AutoSize = true;
            this.lblOffsetHint.ForeColor = System.Drawing.Color.Gray;
            this.lblOffsetHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblOffsetHint.Location = new System.Drawing.Point(12, 155);
            this.lblOffsetHint.Text = "Offset en bytes = posición × 58";

            // Modo actual
            this.lblModoActual.AutoSize = true;
            this.lblModoActual.Location = new System.Drawing.Point(12, 175);
            this.lblModoActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblModoActual.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblModoActual.Text = "➕  Nuevo registro";

            // Botones guardar / cancelar
            this.btnGuardar.Location = new System.Drawing.Point(12, 200);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(155, 32);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "💾  Guardar Registro";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelarEdicion.Location = new System.Drawing.Point(173, 200);
            this.btnCancelarEdicion.Name = "btnCancelarEdicion";
            this.btnCancelarEdicion.Size = new System.Drawing.Size(153, 32);
            this.btnCancelarEdicion.TabIndex = 4;
            this.btnCancelarEdicion.Text = "✖  Cancelar edición";
            this.btnCancelarEdicion.Visible = false;
            this.btnCancelarEdicion.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancelarEdicion.UseVisualStyleBackColor = false;
            this.btnCancelarEdicion.Click += new System.EventHandler(this.btnCancelarEdicion_Click);

            // Agregar 1000
            this.btnAgregar1000.Location = new System.Drawing.Point(12, 238);
            this.btnAgregar1000.Name = "btnAgregar1000";
            this.btnAgregar1000.Size = new System.Drawing.Size(315, 26);
            this.btnAgregar1000.TabIndex = 5;
            this.btnAgregar1000.Text = "🚀  Agregar 1 000 registros aleatorios";
            this.btnAgregar1000.UseVisualStyleBackColor = true;
            this.btnAgregar1000.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnAgregar1000.Click += new System.EventHandler(this.btnAgregar1000_Click);

            // ── grpLeer (left, middle) ───────────────────────────────────────────
            this.grpLeer.Controls.Add(this.lblPosLectura);
            this.grpLeer.Controls.Add(this.txtPosLectura);
            this.grpLeer.Controls.Add(this.btnLeer);
            this.grpLeer.Controls.Add(this.lblResultado1);
            this.grpLeer.Location = new System.Drawing.Point(10, 290);
            this.grpLeer.Name = "grpLeer";
            this.grpLeer.Size = new System.Drawing.Size(340, 108);
            this.grpLeer.TabIndex = 1;
            this.grpLeer.TabStop = false;
            this.grpLeer.Text = "Leer Ciudadano (Seek directo)";

            this.lblPosLectura.AutoSize = true;
            this.lblPosLectura.Location = new System.Drawing.Point(12, 32);
            this.lblPosLectura.Text = "Posición:";

            this.txtPosLectura.Location = new System.Drawing.Point(120, 29);
            this.txtPosLectura.Name = "txtPosLectura";
            this.txtPosLectura.Size = new System.Drawing.Size(70, 23);
            this.txtPosLectura.TabIndex = 0;
            this.txtPosLectura.Text = "0";

            this.btnLeer.Location = new System.Drawing.Point(12, 60);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(140, 28);
            this.btnLeer.TabIndex = 1;
            this.btnLeer.Text = "📂  Leer Registro";
            this.btnLeer.UseVisualStyleBackColor = true;
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);

            this.lblResultado1.AutoSize = false;
            this.lblResultado1.Location = new System.Drawing.Point(12, 92);
            this.lblResultado1.Name = "lblResultado1";
            this.lblResultado1.Size = new System.Drawing.Size(316, 18);
            this.lblResultado1.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lblResultado1.Text = "Resultado: —";

            // ── grpEditar (left, bottom) ─────────────────────────────────────────
            this.grpEditar.Controls.Add(this.lblHintEditar);
            this.grpEditar.Controls.Add(this.lblPosEditar);
            this.grpEditar.Controls.Add(this.txtPosEditar);
            this.grpEditar.Controls.Add(this.btnCargarEditar);
            this.grpEditar.Controls.Add(this.btnEliminar);
            this.grpEditar.Location = new System.Drawing.Point(10, 406);
            this.grpEditar.Name = "grpEditar";
            this.grpEditar.Size = new System.Drawing.Size(340, 120);
            this.grpEditar.TabIndex = 2;
            this.grpEditar.TabStop = false;
            this.grpEditar.Text = "Editar / Eliminar Registro";

            this.lblHintEditar.AutoSize = true;
            this.lblHintEditar.ForeColor = System.Drawing.Color.Gray;
            this.lblHintEditar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHintEditar.Location = new System.Drawing.Point(12, 22);
            this.lblHintEditar.Text = "💡 Haz doble clic en la lista de registros, o ingresa la posición:";

            this.lblPosEditar.AutoSize = true;
            this.lblPosEditar.Location = new System.Drawing.Point(12, 50);
            this.lblPosEditar.Text = "Posición:";

            this.txtPosEditar.Location = new System.Drawing.Point(120, 47);
            this.txtPosEditar.Name = "txtPosEditar";
            this.txtPosEditar.Size = new System.Drawing.Size(70, 23);
            this.txtPosEditar.TabIndex = 0;
            this.txtPosEditar.Text = "0";

            this.btnCargarEditar.Location = new System.Drawing.Point(12, 82);
            this.btnCargarEditar.Name = "btnCargarEditar";
            this.btnCargarEditar.Size = new System.Drawing.Size(155, 30);
            this.btnCargarEditar.TabIndex = 1;
            this.btnCargarEditar.Text = "✏️  Cargar para editar";
            this.btnCargarEditar.UseVisualStyleBackColor = true;
            this.btnCargarEditar.Click += new System.EventHandler(this.btnCargarEditar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(173, 82);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(155, 30);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "🗑️  Eliminar Registro";
            this.btnEliminar.BackColor = System.Drawing.Color.MistyRose;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // ── grpRegistros1 (right, top) ───────────────────────────────────────
            this.grpRegistros1.Controls.Add(this.btnActualizarLista1);
            this.grpRegistros1.Controls.Add(this.lblTotalReg1);
            this.grpRegistros1.Controls.Add(this.dgvRegistros1);
            this.grpRegistros1.Location = new System.Drawing.Point(358, 10);
            this.grpRegistros1.Name = "grpRegistros1";
            this.grpRegistros1.Size = new System.Drawing.Size(644, 338);
            this.grpRegistros1.TabIndex = 3;
            this.grpRegistros1.TabStop = false;
            this.grpRegistros1.Text = "Lista de Registros (doble clic para editar)";

            this.btnActualizarLista1.Location = new System.Drawing.Point(12, 22);
            this.btnActualizarLista1.Name = "btnActualizarLista1";
            this.btnActualizarLista1.Size = new System.Drawing.Size(170, 26);
            this.btnActualizarLista1.TabIndex = 0;
            this.btnActualizarLista1.Text = "🔄  Actualizar Lista";
            this.btnActualizarLista1.UseVisualStyleBackColor = true;
            this.btnActualizarLista1.Click += new System.EventHandler(this.btnActualizarLista1_Click);

            this.lblTotalReg1.AutoSize = true;
            this.lblTotalReg1.Location = new System.Drawing.Point(195, 27);
            this.lblTotalReg1.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotalReg1.Text = "Total: 0 registros";

            this.dgvRegistros1.AllowUserToAddRows = false;
            this.dgvRegistros1.AllowUserToDeleteRows = false;
            this.dgvRegistros1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistros1.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistros1.Location = new System.Drawing.Point(12, 53);
            this.dgvRegistros1.Name = "dgvRegistros1";
            this.dgvRegistros1.ReadOnly = true;
            this.dgvRegistros1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistros1.MultiSelect = false;
            this.dgvRegistros1.Size = new System.Drawing.Size(620, 275);
            this.dgvRegistros1.TabIndex = 1;
            this.dgvRegistros1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRegistros1.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvRegistros1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistros1_CellDoubleClick);

            // ── grpLog1 (right, bottom) ──────────────────────────────────────────
            this.grpLog1.Controls.Add(this.rtbLog1);
            this.grpLog1.Location = new System.Drawing.Point(358, 356);
            this.grpLog1.Name = "grpLog1";
            this.grpLog1.Size = new System.Drawing.Size(644, 326);
            this.grpLog1.TabIndex = 4;
            this.grpLog1.TabStop = false;
            this.grpLog1.Text = "Consola de eventos";

            this.rtbLog1.BackColor = System.Drawing.Color.FromArgb(20, 20, 30);
            this.rtbLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog1.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbLog1.ForeColor = System.Drawing.Color.FromArgb(0, 215, 0);
            this.rtbLog1.Location = new System.Drawing.Point(3, 19);
            this.rtbLog1.Name = "rtbLog1";
            this.rtbLog1.ReadOnly = true;
            this.rtbLog1.Size = new System.Drawing.Size(638, 304);
            this.rtbLog1.TabIndex = 0;
            this.rtbLog1.Text = "";
            this.rtbLog1.WordWrap = false;

            // ════════════════════════════════════════════════════════════════════
            //  TAB 2 – Nivel 2: El Indexador
            // ════════════════════════════════════════════════════════════════════
            this.tabNivel2.Controls.Add(this.grpIndice);
            this.tabNivel2.Controls.Add(this.grpBusqueda);
            this.tabNivel2.Controls.Add(this.grpLog2);
            this.tabNivel2.Location = new System.Drawing.Point(4, 24);
            this.tabNivel2.Name = "tabNivel2";
            this.tabNivel2.Padding = new System.Windows.Forms.Padding(3);
            this.tabNivel2.Size = new System.Drawing.Size(1012, 692);
            this.tabNivel2.TabIndex = 1;
            this.tabNivel2.Text = "  Nivel 2: El Indexador  ";
            this.tabNivel2.UseVisualStyleBackColor = true;

            // ── grpIndice ────────────────────────────────────────────────────────
            this.grpIndice.Controls.Add(this.btnConstruirIndice);
            this.grpIndice.Controls.Add(this.lblInfoIndice);
            this.grpIndice.Location = new System.Drawing.Point(10, 10);
            this.grpIndice.Name = "grpIndice";
            this.grpIndice.Size = new System.Drawing.Size(380, 82);
            this.grpIndice.TabIndex = 0;
            this.grpIndice.TabStop = false;
            this.grpIndice.Text = "Gestión de Índice (.idx)";

            this.btnConstruirIndice.Location = new System.Drawing.Point(12, 28);
            this.btnConstruirIndice.Name = "btnConstruirIndice";
            this.btnConstruirIndice.Size = new System.Drawing.Size(220, 38);
            this.btnConstruirIndice.TabIndex = 0;
            this.btnConstruirIndice.Text = "🔨  Construir Archivo Índice";
            this.btnConstruirIndice.UseVisualStyleBackColor = true;
            this.btnConstruirIndice.Click += new System.EventHandler(this.btnConstruirIndice_Click);

            this.lblInfoIndice.AutoSize = true;
            this.lblInfoIndice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblInfoIndice.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblInfoIndice.Location = new System.Drawing.Point(240, 42);
            this.lblInfoIndice.Text = "";

            // ── grpBusqueda ──────────────────────────────────────────────────────
            this.grpBusqueda.Controls.Add(this.lblBuscarId);
            this.grpBusqueda.Controls.Add(this.txtBuscarId);
            this.grpBusqueda.Controls.Add(this.btnBuscarSec);
            this.grpBusqueda.Controls.Add(this.btnBuscarIdx);
            this.grpBusqueda.Controls.Add(this.lblTiempoSecLabel);
            this.grpBusqueda.Controls.Add(this.lblTiempoSec);
            this.grpBusqueda.Controls.Add(this.lblTiempoIdxLabel);
            this.grpBusqueda.Controls.Add(this.lblTiempoIdx);
            this.grpBusqueda.Controls.Add(this.lblResultado2);
            this.grpBusqueda.Location = new System.Drawing.Point(10, 100);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(380, 220);
            this.grpBusqueda.TabIndex = 1;
            this.grpBusqueda.TabStop = false;
            this.grpBusqueda.Text = "Búsqueda Comparativa";

            this.lblBuscarId.AutoSize = true;
            this.lblBuscarId.Location = new System.Drawing.Point(12, 32);
            this.lblBuscarId.Text = "Buscar ID:";

            this.txtBuscarId.Location = new System.Drawing.Point(120, 29);
            this.txtBuscarId.Name = "txtBuscarId";
            this.txtBuscarId.Size = new System.Drawing.Size(80, 23);
            this.txtBuscarId.TabIndex = 0;
            this.txtBuscarId.Text = "1";

            this.btnBuscarSec.Location = new System.Drawing.Point(12, 65);
            this.btnBuscarSec.Name = "btnBuscarSec";
            this.btnBuscarSec.Size = new System.Drawing.Size(168, 38);
            this.btnBuscarSec.TabIndex = 1;
            this.btnBuscarSec.Text = "🔁  Buscar Secuencial";
            this.btnBuscarSec.UseVisualStyleBackColor = true;
            this.btnBuscarSec.Click += new System.EventHandler(this.btnBuscarSec_Click);

            this.btnBuscarIdx.Location = new System.Drawing.Point(188, 65);
            this.btnBuscarIdx.Name = "btnBuscarIdx";
            this.btnBuscarIdx.Size = new System.Drawing.Size(168, 38);
            this.btnBuscarIdx.TabIndex = 2;
            this.btnBuscarIdx.Text = "⚡  Buscar Indexado";
            this.btnBuscarIdx.UseVisualStyleBackColor = true;
            this.btnBuscarIdx.Click += new System.EventHandler(this.btnBuscarIdx_Click);

            this.lblTiempoSecLabel.AutoSize = true;
            this.lblTiempoSecLabel.Location = new System.Drawing.Point(12, 120);
            this.lblTiempoSecLabel.Text = "Tiempo Secuencial:";

            this.lblTiempoSec.AutoSize = true;
            this.lblTiempoSec.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTiempoSec.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTiempoSec.Location = new System.Drawing.Point(160, 120);
            this.lblTiempoSec.Text = "—";

            this.lblTiempoIdxLabel.AutoSize = true;
            this.lblTiempoIdxLabel.Location = new System.Drawing.Point(12, 150);
            this.lblTiempoIdxLabel.Text = "Tiempo Indexado:";

            this.lblTiempoIdx.AutoSize = true;
            this.lblTiempoIdx.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTiempoIdx.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTiempoIdx.Location = new System.Drawing.Point(160, 150);
            this.lblTiempoIdx.Text = "—";

            this.lblResultado2.AutoSize = false;
            this.lblResultado2.Location = new System.Drawing.Point(12, 182);
            this.lblResultado2.Size = new System.Drawing.Size(355, 32);
            this.lblResultado2.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lblResultado2.Text = "Resultado: —";

            // ── grpLog2 ──────────────────────────────────────────────────────────
            this.grpLog2.Controls.Add(this.rtbLog2);
            this.grpLog2.Location = new System.Drawing.Point(400, 10);
            this.grpLog2.Name = "grpLog2";
            this.grpLog2.Size = new System.Drawing.Size(602, 672);
            this.grpLog2.TabIndex = 2;
            this.grpLog2.TabStop = false;
            this.grpLog2.Text = "Consola de eventos";

            this.rtbLog2.BackColor = System.Drawing.Color.FromArgb(20, 20, 30);
            this.rtbLog2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog2.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbLog2.ForeColor = System.Drawing.Color.FromArgb(0, 215, 0);
            this.rtbLog2.Location = new System.Drawing.Point(3, 19);
            this.rtbLog2.Name = "rtbLog2";
            this.rtbLog2.ReadOnly = true;
            this.rtbLog2.Size = new System.Drawing.Size(596, 650);
            this.rtbLog2.TabIndex = 0;
            this.rtbLog2.Text = "";
            this.rtbLog2.WordWrap = false;

            // ════════════════════════════════════════════════════════════════════
            //  TAB 3 – Nivel 3: SQL Server
            // ════════════════════════════════════════════════════════════════════
            this.tabNivel3.Controls.Add(this.grpConexion);
            this.tabNivel3.Controls.Add(this.grpMigracion);
            this.tabNivel3.Controls.Add(this.grpConsulta);
            this.tabNivel3.Controls.Add(this.grpLog3);
            this.tabNivel3.Controls.Add(this.dgvResultados);
            this.tabNivel3.Location = new System.Drawing.Point(4, 24);
            this.tabNivel3.Name = "tabNivel3";
            this.tabNivel3.Padding = new System.Windows.Forms.Padding(3);
            this.tabNivel3.Size = new System.Drawing.Size(1012, 692);
            this.tabNivel3.TabIndex = 2;
            this.tabNivel3.Text = "  Nivel 3: SQL Server  ";
            this.tabNivel3.UseVisualStyleBackColor = true;

            // ── grpConexion (full width) ─────────────────────────────────────────
            this.grpConexion.Controls.Add(this.lblConnStr);
            this.grpConexion.Controls.Add(this.txtConnStr);
            this.grpConexion.Controls.Add(this.btnConfigurarConexion);
            this.grpConexion.Location = new System.Drawing.Point(10, 10);
            this.grpConexion.Name = "grpConexion";
            this.grpConexion.Size = new System.Drawing.Size(990, 78);
            this.grpConexion.TabIndex = 0;
            this.grpConexion.TabStop = false;
            this.grpConexion.Text = "Conexión SQL Server";

            this.lblConnStr.AutoSize = true;
            this.lblConnStr.Location = new System.Drawing.Point(12, 32);
            this.lblConnStr.Text = "Cadena activa:";

            this.txtConnStr.Location = new System.Drawing.Point(120, 29);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(710, 23);
            this.txtConnStr.TabIndex = 0;
            this.txtConnStr.ReadOnly = true;
            this.txtConnStr.BackColor = System.Drawing.SystemColors.Control;
            this.txtConnStr.ForeColor = System.Drawing.Color.DimGray;
            this.txtConnStr.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.txtConnStr.Text = @"Server=.\SQLEXPRESS;Database=LabDatos;Trusted_Connection=True;TrustServerCertificate=True;";

            this.btnConfigurarConexion.Location = new System.Drawing.Point(840, 26);
            this.btnConfigurarConexion.Name = "btnConfigurarConexion";
            this.btnConfigurarConexion.Size = new System.Drawing.Size(140, 30);
            this.btnConfigurarConexion.TabIndex = 1;
            this.btnConfigurarConexion.Text = "⚙️  Configurar...";
            this.btnConfigurarConexion.UseVisualStyleBackColor = true;
            this.btnConfigurarConexion.Click += new System.EventHandler(this.btnConfigurarConexion_Click);

            // ── grpMigracion (left, row 2) ───────────────────────────────────────
            this.grpMigracion.Controls.Add(this.btnMigrar);
            this.grpMigracion.Controls.Add(this.lblEstadoMig);
            this.grpMigracion.Location = new System.Drawing.Point(10, 96);
            this.grpMigracion.Name = "grpMigracion";
            this.grpMigracion.Size = new System.Drawing.Size(490, 82);
            this.grpMigracion.TabIndex = 1;
            this.grpMigracion.TabStop = false;
            this.grpMigracion.Text = "Migración  Archivo Binario → SQL Server";

            this.btnMigrar.Location = new System.Drawing.Point(12, 28);
            this.btnMigrar.Name = "btnMigrar";
            this.btnMigrar.Size = new System.Drawing.Size(245, 38);
            this.btnMigrar.TabIndex = 0;
            this.btnMigrar.Text = "🚀  Migrar Archivo → SQL Server";
            this.btnMigrar.UseVisualStyleBackColor = true;
            this.btnMigrar.Click += new System.EventHandler(this.btnMigrar_Click);

            this.lblEstadoMig.AutoSize = true;
            this.lblEstadoMig.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstadoMig.Location = new System.Drawing.Point(265, 42);
            this.lblEstadoMig.Text = "";

            // ── grpConsulta (right, row 2) ───────────────────────────────────────
            this.grpConsulta.Controls.Add(this.btnSelect);
            this.grpConsulta.Location = new System.Drawing.Point(510, 96);
            this.grpConsulta.Name = "grpConsulta";
            this.grpConsulta.Size = new System.Drawing.Size(490, 82);
            this.grpConsulta.TabIndex = 2;
            this.grpConsulta.TabStop = false;
            this.grpConsulta.Text = "Consultar con SqlDataReader";

            this.btnSelect.Location = new System.Drawing.Point(12, 28);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(460, 38);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "📊  Ejecutar SELECT * FROM Ciudadanos";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);

            // ── grpLog3 (full width, row 3) ──────────────────────────────────────
            this.grpLog3.Controls.Add(this.rtbLog3);
            this.grpLog3.Location = new System.Drawing.Point(10, 186);
            this.grpLog3.Name = "grpLog3";
            this.grpLog3.Size = new System.Drawing.Size(990, 148);
            this.grpLog3.TabIndex = 3;
            this.grpLog3.TabStop = false;
            this.grpLog3.Text = "Consola de eventos";

            this.rtbLog3.BackColor = System.Drawing.Color.FromArgb(20, 20, 30);
            this.rtbLog3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog3.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbLog3.ForeColor = System.Drawing.Color.FromArgb(0, 215, 0);
            this.rtbLog3.Location = new System.Drawing.Point(3, 19);
            this.rtbLog3.Name = "rtbLog3";
            this.rtbLog3.ReadOnly = true;
            this.rtbLog3.Size = new System.Drawing.Size(984, 126);
            this.rtbLog3.TabIndex = 0;
            this.rtbLog3.Text = "";
            this.rtbLog3.WordWrap = false;

            // ── dgvResultados (full width, bottom) ───────────────────────────────
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(10, 342);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.Size = new System.Drawing.Size(990, 338);
            this.dgvResultados.TabIndex = 4;
            this.dgvResultados.GridColor = System.Drawing.Color.LightSteelBlue;

            // ════════════════════════════════════════════════════════════════════
            //  Form1
            // ════════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 720);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(1036, 759);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab: El Arquitecto de Datos — Del Archivo Binario a la Nube";

            // ── ResumeLayout ─────────────────────────────────────────────────────
            this.grpGuardar.ResumeLayout(false);
            this.grpGuardar.PerformLayout();
            this.grpLeer.ResumeLayout(false);
            this.grpLeer.PerformLayout();
            this.grpEditar.ResumeLayout(false);
            this.grpEditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvRegistros1).EndInit();
            this.grpRegistros1.ResumeLayout(false);
            this.grpRegistros1.PerformLayout();
            this.grpLog1.ResumeLayout(false);
            this.tabNivel1.ResumeLayout(false);

            this.grpIndice.ResumeLayout(false);
            this.grpIndice.PerformLayout();
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            this.grpLog2.ResumeLayout(false);
            this.tabNivel2.ResumeLayout(false);

            this.grpConexion.ResumeLayout(false);
            this.grpConexion.PerformLayout();
            this.grpMigracion.ResumeLayout(false);
            this.grpMigracion.PerformLayout();
            this.grpConsulta.ResumeLayout(false);
            this.grpLog3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvResultados).EndInit();
            this.tabNivel3.ResumeLayout(false);

            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Declaraciones de controles ───────────────────────────────────────────
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabNivel1, tabNivel2, tabNivel3;

        // Nivel 1
        private System.Windows.Forms.GroupBox grpGuardar;
        private System.Windows.Forms.Label lblId, lblIdAuto, lblNombre, lblEdad;
        private System.Windows.Forms.Label lblPosicion, lblOffsetHint, lblModoActual;
        private System.Windows.Forms.TextBox txtNombre, txtEdad, txtPosicion;
        private System.Windows.Forms.Button btnGuardar, btnCancelarEdicion, btnAgregar1000;

        private System.Windows.Forms.GroupBox grpLeer;
        private System.Windows.Forms.Label lblPosLectura, lblResultado1;
        private System.Windows.Forms.TextBox txtPosLectura;
        private System.Windows.Forms.Button btnLeer;

        private System.Windows.Forms.GroupBox grpEditar;
        private System.Windows.Forms.Label lblHintEditar, lblPosEditar;
        private System.Windows.Forms.TextBox txtPosEditar;
        private System.Windows.Forms.Button btnCargarEditar, btnEliminar;

        private System.Windows.Forms.GroupBox grpRegistros1;
        private System.Windows.Forms.Button btnActualizarLista1;
        private System.Windows.Forms.Label lblTotalReg1;
        private System.Windows.Forms.DataGridView dgvRegistros1;

        private System.Windows.Forms.GroupBox grpLog1;
        private System.Windows.Forms.RichTextBox rtbLog1;

        // Nivel 2
        private System.Windows.Forms.GroupBox grpIndice;
        private System.Windows.Forms.Button btnConstruirIndice;
        private System.Windows.Forms.Label lblInfoIndice;
        private System.Windows.Forms.GroupBox grpBusqueda;
        private System.Windows.Forms.Label lblBuscarId, lblTiempoSecLabel, lblTiempoSec;
        private System.Windows.Forms.Label lblTiempoIdxLabel, lblTiempoIdx, lblResultado2;
        private System.Windows.Forms.TextBox txtBuscarId;
        private System.Windows.Forms.Button btnBuscarSec, btnBuscarIdx;
        private System.Windows.Forms.GroupBox grpLog2;
        private System.Windows.Forms.RichTextBox rtbLog2;

        // Nivel 3
        private System.Windows.Forms.GroupBox grpConexion;
        private System.Windows.Forms.Label lblConnStr;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.Button btnConfigurarConexion;
        private System.Windows.Forms.GroupBox grpMigracion;
        private System.Windows.Forms.Button btnMigrar;
        private System.Windows.Forms.Label lblEstadoMig;
        private System.Windows.Forms.GroupBox grpConsulta;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.GroupBox grpLog3;
        private System.Windows.Forms.RichTextBox rtbLog3;
    }
}