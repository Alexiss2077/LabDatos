using System.Drawing;
using System.Windows.Forms;

namespace LabDatos;

/// <summary>
/// Diálogo simplificado para configurar la conexión a SQL Server.
/// El usuario solo proporciona la IP/nombre del servidor y la contraseña.
/// Trusted Connection, TrustServerCertificate y base de datos van por defecto.
/// </summary>
public class DialogConexion : Form
{
    // ── controles ────────────────────────────────────────────────────────────
    private Label lblServidor, lblInstancia, lblUsuario, lblPassword, lblDatabase;
    private TextBox txtServidor, txtInstancia, txtUsuario, txtPassword, txtDatabase;
    private CheckBox chkWindowsAuth;
    private Label lblPreviewTitle, lblPreview;
    private Button btnOk, btnCancelar;
    private Panel pnlSqlAuth;
    private GroupBox grpConexion, grpPreview;

    public string ConnectionString { get; private set; } = "";
    public string MaskedConnectionString { get; private set; } = "";

    // ─────────────────────────────────────────────────────────────────────────
    public DialogConexion(string currentConnStr = "")
    {
        InitializeComponent();
        ParseConnectionString(currentConnStr);
        UpdatePreview();
    }

    // ─────────────────────────────────────────────────────────────────────────
    private void InitializeComponent()
    {
        this.Text = "Configurar Conexión — SQL Server";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;
        this.ClientSize = new Size(480, 420);
        this.Font = new System.Drawing.Font("Segoe UI", 9F);

        // ── GroupBox conexión ────────────────────────────────────────────────
        grpConexion = new GroupBox();
        grpConexion.Text = "Datos del servidor";
        grpConexion.Location = new Point(12, 12);
        grpConexion.Size = new Size(456, 230);

        int lx = 12, tx = 165, ty0 = 28, step = 34;

        // Servidor / IP
        lblServidor = new Label { Text = "Servidor / IP:", AutoSize = true, Location = new Point(lx, ty0 + 4) };
        txtServidor = new TextBox { Location = new Point(tx, ty0), Size = new Size(170, 23), Text = "." };

        // Instancia
        lblInstancia = new Label { Text = "Instancia:", AutoSize = true, Location = new Point(lx, ty0 + step + 4) };
        txtInstancia = new TextBox { Location = new Point(tx, ty0 + step), Size = new Size(120, 23), Text = "SQLEXPRESS" };
        var lblInstHint = new Label
        {
            Text = "(ej: SQLEXPRESS)",
            AutoSize = true,
            ForeColor = Color.Gray,
            Font = new System.Drawing.Font("Segoe UI", 8F),
            Location = new Point(tx + 126, ty0 + step + 5)
        };

        // Base de datos
        lblDatabase = new Label { Text = "Base de datos:", AutoSize = true, Location = new Point(lx, ty0 + step * 2 + 4) };
        txtDatabase = new TextBox { Location = new Point(tx, ty0 + step * 2), Size = new Size(170, 23), Text = "LabDatos" };

        // Windows Auth
        chkWindowsAuth = new CheckBox
        {
            Text = "Usar autenticación de Windows",
            Location = new Point(lx, ty0 + step * 3 + 4),
            AutoSize = true,
            Checked = true
        };
        chkWindowsAuth.CheckedChanged += (s, e) =>
        {
            pnlSqlAuth.Visible = !chkWindowsAuth.Checked;
            UpdatePreview();
        };

        // Panel SQL Auth
        pnlSqlAuth = new Panel { Location = new Point(0, ty0 + step * 4 + 8), Size = new Size(450, 65), Visible = false };

        lblUsuario = new Label { Text = "Usuario:", AutoSize = true, Location = new Point(lx, 8) };
        txtUsuario = new TextBox { Location = new Point(tx - 12, 5), Size = new Size(120, 23), Text = "sa" };
        lblPassword = new Label { Text = "Contraseña:", AutoSize = true, Location = new Point(lx, 38) };
        txtPassword = new TextBox
        {
            Location = new Point(tx - 12, 35),
            Size = new Size(170, 23),
            UseSystemPasswordChar = true
        };
        txtPassword.TextChanged += (s, e) => UpdatePreview();
        txtServidor.TextChanged += (s, e) => UpdatePreview();
        txtInstancia.TextChanged += (s, e) => UpdatePreview();
        txtDatabase.TextChanged += (s, e) => UpdatePreview();
        txtUsuario.TextChanged += (s, e) => UpdatePreview();

        pnlSqlAuth.Controls.AddRange(new Control[] { lblUsuario, txtUsuario, lblPassword, txtPassword });

        grpConexion.Controls.AddRange(new Control[]
        {
            lblServidor, txtServidor,
            lblInstancia, txtInstancia, lblInstHint,
            lblDatabase, txtDatabase,
            chkWindowsAuth, pnlSqlAuth
        });

        // ── GroupBox preview ─────────────────────────────────────────────────
        grpPreview = new GroupBox();
        grpPreview.Text = "Vista previa de la cadena de conexión";
        grpPreview.Location = new Point(12, 252);
        grpPreview.Size = new Size(456, 80);

        lblPreview = new Label
        {
            Location = new Point(10, 22),
            Size = new Size(436, 48),
            ForeColor = Color.DarkGreen,
            Font = new System.Drawing.Font("Consolas", 8F),
            AutoSize = false
        };
        grpPreview.Controls.Add(lblPreview);

        // ── botones ──────────────────────────────────────────────────────────
        btnOk = new Button
        {
            Text = "✔  Conectar",
            Location = new Point(280, 348),
            Size = new Size(120, 34),
            DialogResult = DialogResult.OK
        };
        btnCancelar = new Button
        {
            Text = "Cancelar",
            Location = new Point(148, 348),
            Size = new Size(120, 34),
            DialogResult = DialogResult.Cancel
        };
        btnOk.Click += BtnOk_Click;
        btnOk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

        this.AcceptButton = btnOk;
        this.CancelButton = btnCancelar;

        this.Controls.AddRange(new Control[] { grpConexion, grpPreview, btnOk, btnCancelar });
    }

    // ─────────────────────────────────────────────────────────────────────────
    private void BtnOk_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtServidor.Text))
        {
            MessageBox.Show("Ingresa la IP o nombre del servidor.", "Campo requerido",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        ConnectionString = BuildConnectionString(masked: false);
        MaskedConnectionString = BuildConnectionString(masked: true);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    // ─────────────────────────────────────────────────────────────────────────
    private void UpdatePreview()
    {
        lblPreview.Text = BuildConnectionString(masked: true);
    }

    // ─────────────────────────────────────────────────────────────────────────
    private string BuildConnectionString(bool masked)
    {
        string srv = txtServidor.Text.Trim();
        string inst = txtInstancia.Text.Trim();
        string db = txtDatabase.Text.Trim();
        string serverPart = string.IsNullOrEmpty(inst) ? srv : $@"{srv}\{inst}";

        if (chkWindowsAuth.Checked)
            return $"Server={serverPart};Database={db};Trusted_Connection=True;TrustServerCertificate=True;";

        string pwd = masked ? "***" : txtPassword.Text;
        string usr = txtUsuario.Text.Trim();
        return $"Server={serverPart};Database={db};User Id={usr};Password={pwd};TrustServerCertificate=True;";
    }

    // ─────────────────────────────────────────────────────────────────────────
    private void ParseConnectionString(string connStr)
    {
        if (string.IsNullOrWhiteSpace(connStr)) return;

        foreach (var part in connStr.Split(';', StringSplitOptions.RemoveEmptyEntries))
        {
            var kv = part.Split('=', 2);
            if (kv.Length != 2) continue;
            var key = kv[0].Trim().ToLowerInvariant();
            var val = kv[1].Trim();

            switch (key)
            {
                case "server":
                case "data source":
                    var srv = val.TrimStart('.');
                    var parts = val.Split('\\');
                    txtServidor.Text = parts[0] == "." ? "localhost" : parts[0];
                    if (parts.Length > 1) txtInstancia.Text = parts[1];
                    break;
                case "database":
                case "initial catalog":
                    txtDatabase.Text = val; break;
                case "trusted_connection":
                    chkWindowsAuth.Checked = val.ToLower() is "true" or "yes";
                    pnlSqlAuth.Visible = !chkWindowsAuth.Checked;
                    break;
                case "user id":
                case "uid":
                    txtUsuario.Text = val; break;
                case "password":
                case "pwd":
                    txtPassword.Text = val; break;
            }
        }
    }
}