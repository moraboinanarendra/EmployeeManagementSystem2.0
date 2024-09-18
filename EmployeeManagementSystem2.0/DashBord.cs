using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem2._0
{
    public partial class DashBord : Form
    {
        public DashBord()
        {
            InitializeComponent();
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            DashBord obj=new DashBord();
            obj.Show();
        }

        private void empListbtn_Click(object sender, EventArgs e)
        {
         EmployeeList obj=new EmployeeList();   
            obj.Show();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            Login obj=new Login();
            obj.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
