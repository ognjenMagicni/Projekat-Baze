using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takmicenje.Repository;

namespace Takmicenje
{
    public partial class TaskForm : Form
    {
        public int ID_Task;
        public TaskForm(int id)
        {
            this.ID_Task = id;
            InitializeComponent();
            InitData(this.ID_Task);
        }

        public void InitData(int id)
        {
            string[] select = { "Title", "Description" };
            DataTable dt = RepositoryForAll.getAllById(select,new[] { "Task" },null, new[] { "ID_Task" },new object[] { ID_Task });
            titleBox.Text = Convert.ToString(dt.Rows[0].ItemArray[0]);
            descriptionBox.Text = Convert.ToString(dt.Rows[0].ItemArray[1]);

            string[] select1 = { "Input", "Output" };
            DataTable dt1 = RepositoryForAll.getAllById(select1,new[] { "InputOutput" },null, new[] { "FK_Task" }, new object[] { ID_Task });
            foreach(DataRow row in dt1.Rows)
            {
                ioBox.Text += "Test Sample\n";
                ioBox.Text += row.ItemArray[0]+"\n";
                ioBox.Text += row.ItemArray[1] + "\n";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void descriptionBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
