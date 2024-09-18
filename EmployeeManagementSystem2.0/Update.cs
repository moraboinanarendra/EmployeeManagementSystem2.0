﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeManagementSystem2._0
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string searchId = txtid.Text.Trim();

            if (string.IsNullOrEmpty(searchId))
            {
                MessageBox.Show("Please enter an ID to search.");
                return;
            }

            try
            {
                // Create and open a database connection
                using (SqlConnection con = new SqlConnection("Data source=DESKTOP-QDUVD0V;database=LoginDB;integrated security=true"))
                {
                    con.Open();

                    // Create an SQL command to search for the employee by ID
                    string query = "SELECT Name, Email, Mobile, Designation, Gender, Course FROM Employee WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", searchId);

                        // Execute the query and get the result
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Display the details in the labels or text boxes
                                txtname.Text = reader["Name"].ToString();
                                txtemail.Text = reader["Email"].ToString();
                                txtmobile.Text = reader["Mobile"].ToString();
                                comboBox1.Text = reader["Designation"].ToString();
                                //radioButton1.Text = reader["Gender"].ToString();
                                string gender = reader["Gender"].ToString();
                                if (gender == "M")
                                {
                                    radioButton1.Checked = true;
                                }
                                else if (gender == "F")
                                {
                                    radioButton2.Checked = true;
                                }
                                else
                                {
                                    radioButton3.Checked = true;  // Assuming you have a third option
                                }
                                checkedListBox1.Text = reader["Course"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No employee found with the given ID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
         int id = Convert.ToInt32(txtid.Text);
            string name = txtname.Text;
            string mobile = txtmobile.Text;
            string email = txtemail.Text;
            string designation = comboBox1.SelectedItem?.ToString();
            string gender = string.Empty;
            string course = checkedListBox1.SelectedItem?.ToString(); // Use null-conditional operator
//DateTime selectedDate = dateTimePicker1.Value;

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
                    string qq = "UPDATE Employee SET  Name = @Name, Email = @Email, Mobile = @Mobile, " +
                          "Designation = @Designation, Gender = @Gender, Course = @Course WHERE Id = '"+id+"'";
                    using (SqlCommand cmd = new SqlCommand(qq, con))
                    {
                        // Add parameters with values
             //      cmd.Parameters.AddWithValue("@Id", id);
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