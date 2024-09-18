using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem2._0
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username=txtUsername.Text;
            string password=txtPassword.Text;
            SqlConnection con = new SqlConnection("Data source=DESKTOP-QDUVD0V;database=LoginDB;integrated security=true");
            con.Open();
            string qq = "select password from Login where username='" + username + "'";
            SqlCommand cmd=new SqlCommand(qq, con);
            object dbPassword = cmd.ExecuteScalar(); // Retrieve a single value

            if (dbPassword != null)
            {
                // Compare the retrieved password with the entered password
                if (dbPassword.ToString() == password)
                {
                    MessageBox.Show("Login successful");
                    DashBord obj=new DashBord();
                    obj.Show(); 
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }

        }

        private void butnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
