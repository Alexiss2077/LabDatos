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
            this.tabControl         = new System.Windows.Forms.TabControl();
            this.tabNivel1          = new System.Windows.Forms.TabPage();
            this.tabNivel2          = new System.Windows.Forms.TabPage();
            this.tabNivel3          = new System.Windows.Forms.TabPage();

            // Nivel 1
            this.grpGuardar         = new System.Windows.Forms.GroupBox();
            this.lblId              = new System.Windows.Forms.Label();
            this.txtId              = new System.Windows.Forms.TextBox();
            this.lblNombre          = new System.Windows.Forms.Label();
            this.txtNombre          = new System.Windows.Forms.TextBox();
            this.lblEdad            = new System.Windows.Forms.Label();
            this.txtEdad            = new System.Windows.Forms.TextBox();
            this.lblPosicion        = new System.Windows.Forms.Label();
            this.txtPosicion        = new System.Windows.Forms.TextBox();
            this.lblOffsetHint      = new System.Windows.Forms.Label();
            this.btnGuardar         = new System.Windows.Forms.Button();
            this.grpLeer            = new System.Windows.Forms.GroupBox();
            this.lblPosLectura      = new System.Windows.Forms.Label();
            this.txtPosLectura      = new System.Windows.Forms.TextBox();
            this.btnLeer            = new System.Windows.Forms.Button();
            this.lblResultado1      = new System.Windows.Forms.Label();
            this.grpLog1            = new System.Windows.Forms.GroupBox();
            this.rtbLog1            = new System.Windows.Forms.RichTextBox();

            // Nivel 2
            this.grpIndice          = new System.Windows.Forms.GroupBox();
            this.btnConstruirIndice = new System.Windows.Forms.Button();
            this.lblInfoIndice      = new System.Windows.Forms.Label();
            this.grpBusqueda        = new System.Windows.Forms.GroupBox();
            this.lblBuscarId        = new System.Windows.Forms.Label();
            this.txtBuscarId        = new System.Windows.Forms.TextBox();
            this.btnBuscarSec       = new System.Windows.Forms.Button();
            this.btnBuscarIdx       = new System.Windows.Forms.Button();
            this.lblTiempoSecLabel  = new System.Windows.Forms.Label();
            this.lblTiempoSec       = new System.Windows.Forms.Label();
            this.lblTiempoIdxLabel  = new System.Windows.Forms.Label();
            this.lblTiempoIdx       = new System.Windows.Forms.Label();
            this.lblResultado2      = new System.Windows.Forms.Label();
            this.grpLog2            = new System.Windows.Forms.GroupBox();
            this.rtbLog2            = new System.Windows.Forms.RichTextBox();

            // Nivel 3
            this.grpConexion        = new System.Windows.Forms.GroupBox();
            this.lblConnStr         = new System.Windows.Forms.Label();
            this.txtConnStr         = new System.Windows.Forms.TextBox();
            this.grpMigracion       = new System.Windows.Forms.GroupBox();
            this.btnMigrar          = new System.Windows.Forms.Button();
            this.lblEstadoMig       = new System.Windows.Forms.Label();
            this.grpConsulta        = new System.Windows.Forms.GroupBox();
            this.btnSelect          = new System.Windows.Forms.Button();
            this.dgvResultados      = new System.Windows.Forms.DataGridView();
            this.grpLog3            = new System.Windows.Forms.GroupBox();
            this.rtbLog3            = new System.Windows.Forms.RichTextBox();

            // ── SuspendLayout ──────────────────────────────────────
            this.tabControl.SuspendLayout();
            this.tabNivel1.SuspendLayout();
            this.tabNivel2.SuspendLayout();
            this.tabNivel3.SuspendLayout();
            this.grpGuardar.SuspendLayout();
            this.grpLeer.SuspendLayout();
            this.grpLog1.SuspendLayout();
            this.grpIndice.SuspendLayout();
            this.grpBusqueda.SuspendLayout();
            this.grpLog2.SuspendLayout();
            this.grpConexion.SuspendLayout();
            this.grpMigracion.SuspendLayout();
            this.grpConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvResultados).BeginInit();
            this.grpLog3.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════
            //  tabControl
            // ══════════════════════════════════════════════════════
            this.tabControl.Controls.Add(this.tabNivel1);
            this.tabControl.Controls.Add(this.tabNivel2);
            this.tabControl.Controls.Add(this.tabNivel3);
            this.tabControl.Dock          = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location      = new System.Drawing.Point(0, 0);
            this.tabControl.Name          = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size          = new System.Drawing.Size(814, 571);
            this.tabControl.TabIndex      = 0;

            // ══════════════════════════════════════════════════════
            //  TAB 1 – Nivel 1: El Escriba
            // ══════════════════════════════════════════════════════
            this.tabNivel1.Controls.Add(this.grpGuardar);
            this.tabNivel1.Controls.Add(this.grpLeer);
            this.tabNivel1.Controls.Add(this.grpLog1);
            this.tabNivel1.Location          = new System.Drawing.Point(4, 24);
            this.tabNivel1.Name              = "tabNivel1";
            this.tabNivel1.Padding           = new System.Windows.Forms.Padding(3);
            this.tabNivel1.Size              = new System.Drawing.Size(806, 543);
            this.tabNivel1.TabIndex          = 0;
            this.tabNivel1.Text              = "Nivel 1: El Escriba";
            this.tabNivel1.UseVisualStyleBackColor = true;

            // ── grpGuardar ─────────────────────────────────────────
            this.grpGuardar.Controls.Add(this.lblId);
            this.grpGuardar.Controls.Add(this.txtId);
            this.grpGuardar.Controls.Add(this.lblNombre);
            this.grpGuardar.Controls.Add(this.txtNombre);
            this.grpGuardar.Controls.Add(this.lblEdad);
            this.grpGuardar.Controls.Add(this.txtEdad);
            this.grpGuardar.Controls.Add(this.lblPosicion);
            this.grpGuardar.Controls.Add(this.txtPosicion);
            this.grpGuardar.Controls.Add(this.lblOffsetHint);
            this.grpGuardar.Controls.Add(this.btnGuardar);
            this.grpGuardar.Location  = new System.Drawing.Point(10, 10);
            this.grpGuardar.Name      = "grpGuardar";
            this.grpGuardar.Size      = new System.Drawing.Size(370, 218);
            this.grpGuardar.TabIndex  = 0;
            this.grpGuardar.TabStop   = false;
            this.grpGuardar.Text      = "Guardar Ciudadano";

            this.lblId.AutoSize  = true;
            this.lblId.Location  = new System.Drawing.Point(12, 32);
            this.lblId.Name      = "lblId";
            this.lblId.TabIndex  = 0;
            this.lblId.Text      = "ID:";

            this.txtId.Location  = new System.Drawing.Point(130, 29);
            this.txtId.Name      = "txtId";
            this.txtId.Size      = new System.Drawing.Size(80, 23);
            this.txtId.TabIndex  = 1;
            this.txtId.Text      = "1";

            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 62);
            this.lblNombre.Name     = "lblNombre";
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text     = "Nombre:";

            this.txtNombre.Location = new System.Drawing.Point(130, 59);
            this.txtNombre.Name     = "txtNombre";
            this.txtNombre.Size     = new System.Drawing.Size(225, 23);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.Text     = "Juan Perez";

            this.lblEdad.AutoSize  = true;
            this.lblEdad.Location  = new System.Drawing.Point(12, 92);
            this.lblEdad.Name      = "lblEdad";
            this.lblEdad.TabIndex  = 4;
            this.lblEdad.Text      = "Edad:";

            this.txtEdad.Location  = new System.Drawing.Point(130, 89);
            this.txtEdad.Name      = "txtEdad";
            this.txtEdad.Size      = new System.Drawing.Size(80, 23);
            this.txtEdad.TabIndex  = 5;
            this.txtEdad.Text      = "25";

            this.lblPosicion.AutoSize = true;
            this.lblPosicion.Location = new System.Drawing.Point(12, 122);
            this.lblPosicion.Name     = "lblPosicion";
            this.lblPosicion.TabIndex = 6;
            this.lblPosicion.Text     = "Posición en archivo:";

            this.txtPosicion.Location = new System.Drawing.Point(165, 119);
            this.txtPosicion.Name     = "txtPosicion";
            this.txtPosicion.Size     = new System.Drawing.Size(80, 23);
            this.txtPosicion.TabIndex = 7;
            this.txtPosicion.Text     = "0";

            this.lblOffsetHint.AutoSize  = true;
            this.lblOffsetHint.ForeColor = System.Drawing.Color.Gray;
            this.lblOffsetHint.Location  = new System.Drawing.Point(12, 152);
            this.lblOffsetHint.Name      = "lblOffsetHint";
            this.lblOffsetHint.TabIndex  = 8;
            this.lblOffsetHint.Text      = "Offset = posición × 58 bytes";

            this.btnGuardar.Location = new System.Drawing.Point(12, 177);
            this.btnGuardar.Name     = "btnGuardar";
            this.btnGuardar.Size     = new System.Drawing.Size(140, 30);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text     = "💾 Guardar Registro";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // ── grpLeer ────────────────────────────────────────────
            this.grpLeer.Controls.Add(this.lblPosLectura);
            this.grpLeer.Controls.Add(this.txtPosLectura);
            this.grpLeer.Controls.Add(this.btnLeer);
            this.grpLeer.Controls.Add(this.lblResultado1);
            this.grpLeer.Location = new System.Drawing.Point(10, 238);
            this.grpLeer.Name     = "grpLeer";
            this.grpLeer.Size     = new System.Drawing.Size(370, 120);
            this.grpLeer.TabIndex = 1;
            this.grpLeer.TabStop  = false;
            this.grpLeer.Text     = "Leer Ciudadano (Seek directo)";

            this.lblPosLectura.AutoSize = true;
            this.lblPosLectura.Location = new System.Drawing.Point(12, 32);
            this.lblPosLectura.Name     = "lblPosLectura";
            this.lblPosLectura.TabIndex = 0;
            this.lblPosLectura.Text     = "Posición:";

            this.txtPosLectura.Location = new System.Drawing.Point(130, 29);
            this.txtPosLectura.Name     = "txtPosLectura";
            this.txtPosLectura.Size     = new System.Drawing.Size(80, 23);
            this.txtPosLectura.TabIndex = 1;
            this.txtPosLectura.Text     = "0";

            this.btnLeer.Location = new System.Drawing.Point(12, 62);
            this.btnLeer.Name     = "btnLeer";
            this.btnLeer.Size     = new System.Drawing.Size(140, 30);
            this.btnLeer.TabIndex = 2;
            this.btnLeer.Text     = "📂 Leer Registro";
            this.btnLeer.UseVisualStyleBackColor = true;
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);

            this.lblResultado1.AutoSize = false;
            this.lblResultado1.Location = new System.Drawing.Point(12, 98);
            this.lblResultado1.Name     = "lblResultado1";
            this.lblResultado1.Size     = new System.Drawing.Size(348, 18);
            this.lblResultado1.TabIndex = 3;
            this.lblResultado1.Text     = "Resultado: -";

            // ── grpLog1 ────────────────────────────────────────────
            this.grpLog1.Controls.Add(this.rtbLog1);
            this.grpLog1.Location = new System.Drawing.Point(392, 10);
            this.grpLog1.Name     = "grpLog1";
            this.grpLog1.Size     = new System.Drawing.Size(402, 520);
            this.grpLog1.TabIndex = 2;
            this.grpLog1.TabStop  = false;
            this.grpLog1.Text     = "Log / Consola";

            this.rtbLog1.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            this.rtbLog1.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog1.Font      = new System.Drawing.Font("Consolas", 9F);
            this.rtbLog1.ForeColor = System.Drawing.Color.FromArgb(0, 215, 0);
            this.rtbLog1.Location  = new System.Drawing.Point(3, 19);
            this.rtbLog1.Name      = "rtbLog1";
            this.rtbLog1.ReadOnly  = true;
            this.rtbLog1.Size      = new System.Drawing.Size(396, 498);
            this.rtbLog1.TabIndex  = 0;
            this.rtbLog1.Text      = "";

            // ══════════════════════════════════════════════════════
            //  TAB 2 – Nivel 2: El Indexador
            // ══════════════════════════════════════════════════════
            this.tabNivel2.Controls.Add(this.grpIndice);
            this.tabNivel2.Controls.Add(this.grpBusqueda);
            this.tabNivel2.Controls.Add(this.grpLog2);
            this.tabNivel2.Location          = new System.Drawing.Point(4, 24);
            this.tabNivel2.Name              = "tabNivel2";
            this.tabNivel2.Padding           = new System.Windows.Forms.Padding(3);
            this.tabNivel2.Size              = new System.Drawing.Size(806, 543);
            this.tabNivel2.TabIndex          = 1;
            this.tabNivel2.Text              = "Nivel 2: El Indexador";
            this.tabNivel2.UseVisualStyleBackColor = true;

            // ── grpIndice ──────────────────────────────────────────
            this.grpIndice.Controls.Add(this.btnConstruirIndice);
            this.grpIndice.Controls.Add(this.lblInfoIndice);
            this.grpIndice.Location = new System.Drawing.Point(10, 10);
            this.grpIndice.Name     = "grpIndice";
            this.grpIndice.Size     = new System.Drawing.Size(370, 82);
            this.grpIndice.TabIndex = 0;
            this.grpIndice.TabStop  = false;
            this.grpIndice.Text     = "Gestión de Índice (.idx)";

            this.btnConstruirIndice.Location = new System.Drawing.Point(12, 28);
            this.btnConstruirIndice.Name     = "btnConstruirIndice";
            this.btnConstruirIndice.Size     = new System.Drawing.Size(220, 38);
            this.btnConstruirIndice.TabIndex = 0;
            this.btnConstruirIndice.Text     = "🔨 Construir Archivo Índice";
            this.btnConstruirIndice.UseVisualStyleBackColor = true;
            this.btnConstruirIndice.Click += new System.EventHandler(this.btnConstruirIndice_Click);

            this.lblInfoIndice.AutoSize = true;
            this.lblInfoIndice.Location = new System.Drawing.Point(240, 40);
            this.lblInfoIndice.Name     = "lblInfoIndice";
            this.lblInfoIndice.TabIndex = 1;
            this.lblInfoIndice.Text     = "";

            // ── grpBusqueda ────────────────────────────────────────
            this.grpBusqueda.Controls.Add(this.lblBuscarId);
            this.grpBusqueda.Controls.Add(this.txtBuscarId);
            this.grpBusqueda.Controls.Add(this.btnBuscarSec);
            this.grpBusqueda.Controls.Add(this.btnBuscarIdx);
            this.grpBusqueda.Controls.Add(this.lblTiempoSecLabel);
            this.grpBusqueda.Controls.Add(this.lblTiempoSec);
            this.grpBusqueda.Controls.Add(this.lblTiempoIdxLabel);
            this.grpBusqueda.Controls.Add(this.lblTiempoIdx);
            this.grpBusqueda.Controls.Add(this.lblResultado2);
            this.grpBusqueda.Location = new System.Drawing.Point(10, 102);
            this.grpBusqueda.Name     = "grpBusqueda";
            this.grpBusqueda.Size     = new System.Drawing.Size(370, 220);
            this.grpBusqueda.TabIndex = 1;
            this.grpBusqueda.TabStop  = false;
            this.grpBusqueda.Text     = "Búsqueda Comparativa";

            this.lblBuscarId.AutoSize = true;
            this.lblBuscarId.Location = new System.Drawing.Point(12, 32);
            this.lblBuscarId.Name     = "lblBuscarId";
            this.lblBuscarId.TabIndex = 0;
            this.lblBuscarId.Text     = "Buscar ID:";

            this.txtBuscarId.Location = new System.Drawing.Point(130, 29);
            this.txtBuscarId.Name     = "txtBuscarId";
            this.txtBuscarId.Size     = new System.Drawing.Size(80, 23);
            this.txtBuscarId.TabIndex = 1;
            this.txtBuscarId.Text     = "1";

            this.btnBuscarSec.Location = new System.Drawing.Point(12, 66);
            this.btnBuscarSec.Name     = "btnBuscarSec";
            this.btnBuscarSec.Size     = new System.Drawing.Size(168, 38);
            this.btnBuscarSec.TabIndex = 2;
            this.btnBuscarSec.Text     = "🔁 Buscar Secuencial";
            this.btnBuscarSec.UseVisualStyleBackColor = true;
            this.btnBuscarSec.Click += new System.EventHandler(this.btnBuscarSec_Click);

            this.btnBuscarIdx.Location = new System.Drawing.Point(188, 66);
            this.btnBuscarIdx.Name     = "btnBuscarIdx";
            this.btnBuscarIdx.Size     = new System.Drawing.Size(168, 38);
            this.btnBuscarIdx.TabIndex = 3;
            this.btnBuscarIdx.Text     = "⚡ Buscar Indexado";
            this.btnBuscarIdx.UseVisualStyleBackColor = true;
            this.btnBuscarIdx.Click += new System.EventHandler(this.btnBuscarIdx_Click);

            this.lblTiempoSecLabel.AutoSize  = true;
            this.lblTiempoSecLabel.Location  = new System.Drawing.Point(12, 120);
            this.lblTiempoSecLabel.Name      = "lblTiempoSecLabel";
            this.lblTiempoSecLabel.TabIndex  = 4;
            this.lblTiempoSecLabel.Text      = "Tiempo Secuencial:";

            this.lblTiempoSec.AutoSize  = true;
            this.lblTiempoSec.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTiempoSec.Font      = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblTiempoSec.Location  = new System.Drawing.Point(165, 120);
            this.lblTiempoSec.Name      = "lblTiempoSec";
            this.lblTiempoSec.TabIndex  = 5;
            this.lblTiempoSec.Text      = "-";

            this.lblTiempoIdxLabel.AutoSize = true;
            this.lblTiempoIdxLabel.Location = new System.Drawing.Point(12, 148);
            this.lblTiempoIdxLabel.Name     = "lblTiempoIdxLabel";
            this.lblTiempoIdxLabel.TabIndex = 6;
            this.lblTiempoIdxLabel.Text     = "Tiempo Indexado:";

            this.lblTiempoIdx.AutoSize  = true;
            this.lblTiempoIdx.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTiempoIdx.Font      = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.lblTiempoIdx.Location  = new System.Drawing.Point(165, 148);
            this.lblTiempoIdx.Name      = "lblTiempoIdx";
            this.lblTiempoIdx.TabIndex  = 7;
            this.lblTiempoIdx.Text      = "-";

            this.lblResultado2.AutoSize = false;
            this.lblResultado2.Location = new System.Drawing.Point(12, 180);
            this.lblResultado2.Name     = "lblResultado2";
            this.lblResultado2.Size     = new System.Drawing.Size(348, 32);
            this.lblResultado2.TabIndex = 8;
            this.lblResultado2.Text     = "Resultado: -";

            // ── grpLog2 ────────────────────────────────────────────
            this.grpLog2.Controls.Add(this.rtbLog2);
            this.grpLog2.Location = new System.Drawing.Point(392, 10);
            this.grpLog2.Name     = "grpLog2";
            this.grpLog2.Size     = new System.Drawing.Size(402, 520);
            this.grpLog2.TabIndex = 2;
            this.grpLog2.TabStop  = false;
            this.grpLog2.Text     = "Log / Consola";

            this.rtbLog2.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            this.rtbLog2.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog2.Font      = new System.Drawing.Font("Consolas", 9F);
            this.rtbLog2.ForeColor = System.Drawing.Color.FromArgb(0, 215, 0);
            this.rtbLog2.Location  = new System.Drawing.Point(3, 19);
            this.rtbLog2.Name      = "rtbLog2";
            this.rtbLog2.ReadOnly  = true;
            this.rtbLog2.Size      = new System.Drawing.Size(396, 498);
            this.rtbLog2.TabIndex  = 0;
            this.rtbLog2.Text      = "";

            // ══════════════════════════════════════════════════════
            //  TAB 3 – Nivel 3: SQL Server
            // ══════════════════════════════════════════════════════
            this.tabNivel3.Controls.Add(this.grpConexion);
            this.tabNivel3.Controls.Add(this.grpMigracion);
            this.tabNivel3.Controls.Add(this.grpConsulta);
            this.tabNivel3.Controls.Add(this.dgvResultados);
            this.tabNivel3.Controls.Add(this.grpLog3);
            this.tabNivel3.Location          = new System.Drawing.Point(4, 24);
            this.tabNivel3.Name              = "tabNivel3";
            this.tabNivel3.Padding           = new System.Windows.Forms.Padding(3);
            this.tabNivel3.Size              = new System.Drawing.Size(806, 543);
            this.tabNivel3.TabIndex          = 2;
            this.tabNivel3.Text              = "Nivel 3: SQL Server";
            this.tabNivel3.UseVisualStyleBackColor = true;

            // ── grpConexion ────────────────────────────────────────
            this.grpConexion.Controls.Add(this.lblConnStr);
            this.grpConexion.Controls.Add(this.txtConnStr);
            this.grpConexion.Location = new System.Drawing.Point(10, 10);
            this.grpConexion.Name     = "grpConexion";
            this.grpConexion.Size     = new System.Drawing.Size(783, 65);
            this.grpConexion.TabIndex = 0;
            this.grpConexion.TabStop  = false;
            this.grpConexion.Text     = "Conexión SQL Server (instancia SQLEXPRESS)";

            this.lblConnStr.AutoSize = true;
            this.lblConnStr.Location = new System.Drawing.Point(12, 32);
            this.lblConnStr.Name     = "lblConnStr";
            this.lblConnStr.TabIndex = 0;
            this.lblConnStr.Text     = "Cadena de Conexión:";

            this.txtConnStr.Location = new System.Drawing.Point(155, 29);
            this.txtConnStr.Name     = "txtConnStr";
            this.txtConnStr.Size     = new System.Drawing.Size(614, 23);
            this.txtConnStr.TabIndex = 1;
            this.txtConnStr.Text     = @"Server=.\SQLEXPRESS;Database=LabDatos;Trusted_Connection=True;TrustServerCertificate=True;";

            // ── grpMigracion ───────────────────────────────────────
            this.grpMigracion.Controls.Add(this.btnMigrar);
            this.grpMigracion.Controls.Add(this.lblEstadoMig);
            this.grpMigracion.Location = new System.Drawing.Point(10, 85);
            this.grpMigracion.Name     = "grpMigracion";
            this.grpMigracion.Size     = new System.Drawing.Size(385, 82);
            this.grpMigracion.TabIndex = 1;
            this.grpMigracion.TabStop  = false;
            this.grpMigracion.Text     = "Migración Archivo Binario → SQL Server";

            this.btnMigrar.Location = new System.Drawing.Point(12, 28);
            this.btnMigrar.Name     = "btnMigrar";
            this.btnMigrar.Size     = new System.Drawing.Size(235, 38);
            this.btnMigrar.TabIndex = 0;
            this.btnMigrar.Text     = "🚀 Migrar Archivo → SQL Server";
            this.btnMigrar.UseVisualStyleBackColor = true;
            this.btnMigrar.Click += new System.EventHandler(this.btnMigrar_Click);

            this.lblEstadoMig.AutoSize = true;
            this.lblEstadoMig.Location = new System.Drawing.Point(258, 40);
            this.lblEstadoMig.Name     = "lblEstadoMig";
            this.lblEstadoMig.TabIndex = 1;
            this.lblEstadoMig.Text     = "";

            // ── grpConsulta ────────────────────────────────────────
            this.grpConsulta.Controls.Add(this.btnSelect);
            this.grpConsulta.Location = new System.Drawing.Point(10, 177);
            this.grpConsulta.Name     = "grpConsulta";
            this.grpConsulta.Size     = new System.Drawing.Size(385, 75);
            this.grpConsulta.TabIndex = 2;
            this.grpConsulta.TabStop  = false;
            this.grpConsulta.Text     = "Consultar con SqlDataReader";

            this.btnSelect.Location = new System.Drawing.Point(12, 28);
            this.btnSelect.Name     = "btnSelect";
            this.btnSelect.Size     = new System.Drawing.Size(358, 35);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text     = "📊 Ejecutar SELECT * FROM Ciudadanos";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);

            // ── dgvResultados ──────────────────────────────────────
            this.dgvResultados.AllowUserToAddRows    = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location  = new System.Drawing.Point(10, 262);
            this.dgvResultados.Name      = "dgvResultados";
            this.dgvResultados.ReadOnly  = true;
            this.dgvResultados.Size      = new System.Drawing.Size(783, 268);
            this.dgvResultados.TabIndex  = 3;

            // ── grpLog3 ────────────────────────────────────────────
            this.grpLog3.Controls.Add(this.rtbLog3);
            this.grpLog3.Location = new System.Drawing.Point(405, 85);
            this.grpLog3.Name     = "grpLog3";
            this.grpLog3.Size     = new System.Drawing.Size(388, 170);
            this.grpLog3.TabIndex = 4;
            this.grpLog3.TabStop  = false;
            this.grpLog3.Text     = "Log / Consola";

            this.rtbLog3.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            this.rtbLog3.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog3.Font      = new System.Drawing.Font("Consolas", 9F);
            this.rtbLog3.ForeColor = System.Drawing.Color.FromArgb(0, 215, 0);
            this.rtbLog3.Location  = new System.Drawing.Point(3, 19);
            this.rtbLog3.Name      = "rtbLog3";
            this.rtbLog3.ReadOnly  = true;
            this.rtbLog3.Size      = new System.Drawing.Size(382, 148);
            this.rtbLog3.TabIndex  = 0;
            this.rtbLog3.Text      = "";

            // ══════════════════════════════════════════════════════
            //  Form1
            // ══════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(814, 571);
            this.Controls.Add(this.tabControl);
            this.MinimumSize         = new System.Drawing.Size(830, 610);
            this.Name                = "Form1";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Lab: El Arquitecto de Datos – Del Archivo a la Nube";

            // ── ResumeLayout ───────────────────────────────────────
            this.grpGuardar.ResumeLayout(false);
            this.grpGuardar.PerformLayout();
            this.grpLeer.ResumeLayout(false);
            this.grpLeer.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)this.dgvResultados).EndInit();
            this.grpLog3.ResumeLayout(false);
            this.tabNivel3.ResumeLayout(false);

            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Declaraciones de controles ─────────────────────────────
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabNivel1;
        private System.Windows.Forms.TabPage tabNivel2;
        private System.Windows.Forms.TabPage tabNivel3;

        // Nivel 1
        private System.Windows.Forms.GroupBox  grpGuardar;
        private System.Windows.Forms.Label     lblId;
        private System.Windows.Forms.TextBox   txtId;
        private System.Windows.Forms.Label     lblNombre;
        private System.Windows.Forms.TextBox   txtNombre;
        private System.Windows.Forms.Label     lblEdad;
        private System.Windows.Forms.TextBox   txtEdad;
        private System.Windows.Forms.Label     lblPosicion;
        private System.Windows.Forms.TextBox   txtPosicion;
        private System.Windows.Forms.Label     lblOffsetHint;
        private System.Windows.Forms.Button    btnGuardar;
        private System.Windows.Forms.GroupBox  grpLeer;
        private System.Windows.Forms.Label     lblPosLectura;
        private System.Windows.Forms.TextBox   txtPosLectura;
        private System.Windows.Forms.Button    btnLeer;
        private System.Windows.Forms.Label     lblResultado1;
        private System.Windows.Forms.GroupBox  grpLog1;
        private System.Windows.Forms.RichTextBox rtbLog1;

        // Nivel 2
        private System.Windows.Forms.GroupBox  grpIndice;
        private System.Windows.Forms.Button    btnConstruirIndice;
        private System.Windows.Forms.Label     lblInfoIndice;
        private System.Windows.Forms.GroupBox  grpBusqueda;
        private System.Windows.Forms.Label     lblBuscarId;
        private System.Windows.Forms.TextBox   txtBuscarId;
        private System.Windows.Forms.Button    btnBuscarSec;
        private System.Windows.Forms.Button    btnBuscarIdx;
        private System.Windows.Forms.Label     lblTiempoSecLabel;
        private System.Windows.Forms.Label     lblTiempoSec;
        private System.Windows.Forms.Label     lblTiempoIdxLabel;
        private System.Windows.Forms.Label     lblTiempoIdx;
        private System.Windows.Forms.Label     lblResultado2;
        private System.Windows.Forms.GroupBox  grpLog2;
        private System.Windows.Forms.RichTextBox rtbLog2;

        // Nivel 3
        private System.Windows.Forms.GroupBox    grpConexion;
        private System.Windows.Forms.Label       lblConnStr;
        private System.Windows.Forms.TextBox     txtConnStr;
        private System.Windows.Forms.GroupBox    grpMigracion;
        private System.Windows.Forms.Button      btnMigrar;
        private System.Windows.Forms.Label       lblEstadoMig;
        private System.Windows.Forms.GroupBox    grpConsulta;
        private System.Windows.Forms.Button      btnSelect;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.GroupBox    grpLog3;
        private System.Windows.Forms.RichTextBox rtbLog3;
    }
}
