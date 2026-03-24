using System.Drawing;
using System.Windows.Forms;

namespace LabDatos;

/// <summary>
/// Diálogo simplificado para configurar la conexión a SQL Server.
///
/// Lógica de construcción del Server:
///   - Si se especifica Puerto → usa  IP,Puerto          (recomendado para PCs remotas)
///   - Si no hay Puerto        → usa  IP\Instancia       (requiere SQL Browser activo)
/// </summary>
public class DialogConexion : Form
{
    // ── controles ────────────────────────────────────────────────────────────
    private Label lblServidor, lblPuerto, lblInstancia, lblDatabase;
    private Label lblUsuario, lblPassword;
    private TextBox txtServidor, txtPuerto, txtInstancia, txtDatabase;
    private TextBox txtUsuario, txtPassword;
    private CheckBox chkWindowsAuth;
    private Label lblPreview, lblTip;
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
        this.ClientSize = new Size(500, 460);
        this.Font = new System.Drawing.Font("Segoe UI", 9F);

        // ── GroupBox conexión ────────────────────────────────────────────────
        grpConexion = new GroupBox
        {
            Text = "Datos del servidor",
            Location = new Point(12, 12),
            Size = new Size(476, 268)
        };

        int lx = 12;
        int tx = 170;
        int ty0 = 26;
        int step = 36;

        // Servidor / IP
        lblServidor = new Label
        {
            Text = "Servidor / IP:",
            AutoSize = true,
            Location = new Point(lx, ty0 + 4)
        };
        txtServidor = new TextBox
        {
            Location = new Point(tx, ty0),
            Size = new Size(180, 23),
            Text = "localhost"
        };

        // Puerto
        lblPuerto = new Label
        {
            Text = "Puerto:",
            AutoSize = true,
            Location = new Point(lx, ty0 + step + 4)
        };
        txtPuerto = new TextBox
        {
            Location = new Point(tx, ty0 + step),
            Size = new Size(70, 23),
            Text = "1433"
        };

        var lblPuertoHint = new Label
        {
            //Text = "Error 26",
            AutoSize = true,
            ForeColor = Color.SeaGreen,
            Font = new System.Drawing.Font("Segoe UI", 8F),
            Location = new Point(tx + 76, ty0 + step + 5)
        };

        // Instancia
        lblInstancia = new Label
        {
            Text = "Instancia:",
            AutoSize = true,
            Location = new Point(lx, ty0 + step * 2 + 4)
        };
        txtInstancia = new TextBox
        {
            Location = new Point(tx, ty0 + step * 2),
            Size = new Size(120, 23),
            Text = "SQLEXPRESS",
            ForeColor = Color.Gray
        };

        var lblInstHint = new Label
        {
            Text = "Se ignora si hay Puerto",
            AutoSize = true,
            ForeColor = Color.Gray,
            Font = new System.Drawing.Font("Segoe UI", 8F),
            Location = new Point(tx + 126, ty0 + step * 2 + 5)
        };

        // Base de datos
        lblDatabase = new Label
        {
            Text = "Base de datos:",
            AutoSize = true,
            Location = new Point(lx, ty0 + step * 3 + 4)
        };
        txtDatabase = new TextBox
        {
            Location = new Point(tx, ty0 + step * 3),
            Size = new Size(170, 23),
            Text = "LabDatos"
        };

        // Windows Auth
        chkWindowsAuth = new CheckBox
        {
            Text = "Usar autenticación de Windows",
            Location = new Point(lx, ty0 + step * 4 + 4),
            AutoSize = true,
            Checked = false    // default: SQL Auth (más común en red)
        };
        chkWindowsAuth.CheckedChanged += (s, e) =>
        {
            pnlSqlAuth.Visible = !chkWindowsAuth.Checked;
            UpdatePreview();
        };

        // Panel SQL Auth
        pnlSqlAuth = new Panel
        {
            Location = new Point(0, ty0 + step * 5 + 2),
            Size = new Size(470, 66),
            Visible = true     // visible por defecto (SQL Auth)
        };

        lblUsuario = new Label { Text = "Usuario:", AutoSize = true, Location = new Point(lx, 8) };
        txtUsuario = new TextBox { Location = new Point(tx - 12, 5), Size = new Size(120, 23), Text = "sa" };
        lblPassword = new Label { Text = "Contraseña:", AutoSize = true, Location = new Point(lx, 38) };
        txtPassword = new TextBox
        {
            Location = new Point(tx - 12, 35),
            Size = new Size(170, 23),
            UseSystemPasswordChar = true
        };

        pnlSqlAuth.Controls.AddRange(new Control[] { lblUsuario, txtUsuario, lblPassword, txtPassword });

        // Suscribir eventos
        txtServidor.TextChanged += (s, e) => UpdatePreview();
        txtPuerto.TextChanged += (s, e) => { UpdateInstanciaHint(); UpdatePreview(); };
        txtInstancia.TextChanged += (s, e) => UpdatePreview();
        txtDatabase.TextChanged += (s, e) => UpdatePreview();
        txtUsuario.TextChanged += (s, e) => UpdatePreview();
        txtPassword.TextChanged += (s, e) => UpdatePreview();

        grpConexion.Controls.AddRange(new Control[]
        {
            lblServidor,  txtServidor,
            lblPuerto,    txtPuerto,    lblPuertoHint,
            lblInstancia, txtInstancia, lblInstHint,
            lblDatabase,  txtDatabase,
            chkWindowsAuth, pnlSqlAuth
        });

        // Tip
        lblTip = new Label
        {
            Text = "💡 Con Puerto=1433 la app usa IP,1433 directamente, sin necesitar SQL Browser.",
            Location = new Point(12, 288),
            Size = new Size(476, 18),
            ForeColor = Color.SteelBlue,
            Font = new System.Drawing.Font("Segoe UI", 8F)
        };

        // GroupBox preview
        grpPreview = new GroupBox
        {
            Text = "Vista previa de la cadena de conexión",
            Location = new Point(12, 312),
            Size = new Size(476, 86)
        };

        lblPreview = new Label
        {
            Location = new Point(10, 20),
            Size = new Size(456, 56),
            ForeColor = Color.DarkGreen,
            Font = new System.Drawing.Font("Consolas", 7.8F),
            AutoSize = false
        };
        grpPreview.Controls.Add(lblPreview);

        // Botones
        btnOk = new Button
        {
            Text = "✔  Conectar",
            Location = new Point(296, 410),
            Size = new Size(128, 36),
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
        };
        btnCancelar = new Button
        {
            Text = "Cancelar",
            Location = new Point(160, 410),
            Size = new Size(128, 36),
            DialogResult = DialogResult.Cancel
        };

        btnOk.Click += BtnOk_Click;
        this.AcceptButton = btnOk;
        this.CancelButton = btnCancelar;

        this.Controls.AddRange(new Control[] { grpConexion, lblTip, grpPreview, btnOk, btnCancelar });
    }

    // ─────────────────────────────────────────────────────────────────────────
    private void UpdateInstanciaHint()
    {
        bool tienePuerto = !string.IsNullOrWhiteSpace(txtPuerto.Text);
        txtInstancia.ForeColor = tienePuerto ? Color.LightGray : Color.Black;
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
        if (!chkWindowsAuth.Checked && string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            var r = MessageBox.Show("La contraseña está vacía. ¿Continuar de todas formas?",
                                    "Contraseña vacía", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;
        }

        ConnectionString = BuildConnectionString(masked: false);
        MaskedConnectionString = BuildConnectionString(masked: true);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    // ─────────────────────────────────────────────────────────────────────────
    private void UpdatePreview() => lblPreview.Text = BuildConnectionString(masked: true);

    // ─────────────────────────────────────────────────────────────────────────
    /// <summary>
    /// Puerto relleno  →  Server=IP,Puerto     (sin instancia — evita Error 26)
    /// Puerto vacío    →  Server=IP\Instancia  (requiere SQL Browser)
    /// </summary>
    private string BuildConnectionString(bool masked)
    {
        string srv = txtServidor.Text.Trim();
        string puerto = txtPuerto.Text.Trim();
        string inst = txtInstancia.Text.Trim();
        string db = txtDatabase.Text.Trim();

        string serverPart = !string.IsNullOrEmpty(puerto)
            ? $"{srv},{puerto}"
            : (!string.IsNullOrEmpty(inst) ? $@"{srv}\{inst}" : srv);

        string common = $"Database={db};TrustServerCertificate=True;Encrypt=False;";

        if (chkWindowsAuth.Checked)
            return $"Server={serverPart};{common}Trusted_Connection=True;";

        string pwd = masked ? "***" : txtPassword.Text;
        string usr = txtUsuario.Text.Trim();
        return $"Server={serverPart};{common}User Id={usr};Password={pwd};";
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
                    // Formato  IP,puerto  o  IP\instancia
                    if (val.Contains(','))
                    {
                        var p = val.Split(',');
                        txtServidor.Text = p[0];
                        txtPuerto.Text = p[1];
                    }
                    else
                    {
                        var p = val.Split('\\');
                        txtServidor.Text = p[0] == "." ? "localhost" : p[0];
                        txtPuerto.Text = "";
                        if (p.Length > 1) txtInstancia.Text = p[1];
                    }
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
        UpdateInstanciaHint();
    }
}