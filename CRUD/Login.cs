
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;


namespace CRUD
{
    public partial class Login : Form
    {
        private string connectionString;
        private TextBox txtpass;

        public Login()
        {
            InitializeComponent();

            connectionString = "Data Source=DESKTOP-2GMFMFD\\SQLEXPRESS;Initial Catalog=CRUD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            txtpass = new TextBox
            {
                UseSystemPasswordChar = true
            };
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SignUP form = new SignUP();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string pass = txtpass.Text;

            if (string.IsNullOrWhiteSpace(username) || username == "Enter Your Username")
            {
                MessageBox.Show("Enter Your Username", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(pass) || pass == "Enter Your Password")
            {
                MessageBox.Show("Enter Your Password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ValidateUser(username, pass);
        }

        private void ValidateUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM crud WHERE USERNAME = @username AND PASSWORD = @password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dtbl = new DataTable();
                            sda.Fill(dtbl);

                            if (dtbl.Rows.Count == 1)
                            {
                                MessageBox.Show("Login successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SignUP form = new SignUP();
                                form.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
