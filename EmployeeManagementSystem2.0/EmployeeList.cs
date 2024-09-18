using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace EmployeeManagementSystem2._0
{
    public partial class EmployeeList : Form
    {
        public EmployeeList()
        {
            InitializeComponent();
        }
        SqlDataAdapter dataAdapter;
        private void showw()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.HeaderText = "Edit";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            editButton.Name = "Edit";
            dataGridView1.Columns.Add(editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Name = "Delete";
            dataGridView1.Columns.Add(deleteButton);
        }

        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            CreateEmploye obj = new CreateEmploye();
            obj.Show();
          

        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loginDBDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.loginDBDataSet.Employee);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection("Data source=DESKTOP-QDUVD0V;database=LoginDB;integrated security=true");
                con.Open();
                //string qq = "update Employee set Name=@Name,Email=@email,Mobile=@Mobile ,Designation=@Designation, Gender=@Gender ,Course=@Course where Id=@id";

                //SqlCommand cmd = new SqlCommand(qq, con);

                //// Add parameters to prevent SQL injection
                //cmd.Parameters.AddWithValue("@Id", id);
                //cmd.Parameters.AddWithValue("@Name", name);
                //cmd.Parameters.AddWithValue("@Email", email);
                //cmd.Parameters.AddWithValue("@Mobile", mobile);
                //cmd.Parameters.AddWithValue("@Designation", designation);
                //cmd.Parameters.AddWithValue("@Gender", gender);
                //cmd.Parameters.AddWithValue("@Course", course);

                //// Execute the update
                //// Apply the changes made in the DataGridView to the database
                //dataAdapter.Update((DataTable)dataGridView1.DataSource);

                //con.Close();
                //MessageBox.Show("Update successful!");
                dataGridView1.EndEdit();

                // Apply the changes made in the DataGridView to the database
             //   con.Open();
                dataAdapter.Update((DataTable)dataGridView1.DataSource);
                con.Close();

                MessageBox.Show("Update successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Update obj = new Update();
            obj.Show();

            //Update form2 = new Update(id, name, email, mobile, designation, gender, course);
            //form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
