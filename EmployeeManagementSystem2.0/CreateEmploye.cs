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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeManagementSystem2._0
{
    public partial class CreateEmploye : Form
    {
        public CreateEmploye()
        {
            InitializeComponent();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtid.Text);
            string name = txtname.Text;
            string mobile = txtmobile.Text;
            string email=txtemail.Text;
            string designation = comboBox2.SelectedItem.ToString();
            string gender = string.Empty;
            string course = checkedListBox1.SelectedItem?.ToString(); // Use null-conditional operator
            DateTime selectedDate = dateTimePicker1.Value;

            // Determine gender
            if (radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                gender = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                gender = radioButton3.Text;
            }

            // Create SQL connection
            using (SqlConnection con = new SqlConnection("data source=DESKTOP-QDUVD0V;database=LoginDB;integrated security=yes"))
            {
                try
                {
                    con.Open();

                    // Prepare the SQL command with parameters
                    string qq = "INSERT INTO Employee (Id, Name, Email,Mobile, Designation, Gender, Course) " +
                                 "VALUES (@Id, @Name,@Email, @Mobile, @Designation, @Gender, @Course)";
                    using (SqlCommand cmd = new SqlCommand(qq, con))
                    {
                        // Add parameters with values
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Mobile", mobile);
                        cmd.Parameters.AddWithValue("@Designation", designation);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Course", course);
                      //  cmd.Parameters.AddWithValue("@DateOfJoining", selectedDate);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                        
                    }

                    // Show success message
                    MessageBox.Show("Data inserted successfully");
                    EmployeeList obj = new EmployeeList();
                    obj.Show();
                }
                catch (Exception ex)
                {
                    // Handle any errors
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
