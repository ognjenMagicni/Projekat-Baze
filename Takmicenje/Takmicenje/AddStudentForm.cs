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
    public partial class AddStudentForm : Form
    {
        protected int ID_Room;
        protected DataTable data;
        protected AdministratorRoom parent;
        protected string username = "FFFFFFF";
        public AddStudentForm(int ID_Room, AdministratorRoom parent)
        {
            this.parent = parent;
            this.ID_Room = ID_Room;
            InitializeComponent();
            this.textBox1.Text = "";
            InitData("");
        }
        public AddStudentForm()
        {
            InitializeComponent();
        }

        public virtual void InitData(string username)
        {
            this.data = StudentRepository.getAllStudentByUsername(username,this.ID_Room);
            this.dataGridView1.DataSource = this.data;
        }

        protected virtual void searchBtn_Click(object sender, EventArgs e)
        {
            InitData(textBox1.Text);
        }

        protected virtual void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1 && index < dataGridView1.RowCount)
            {
                this.username = Convert.ToString(this.data.Rows[index].ItemArray[0]);
            }
        }

        protected virtual void addBtn_Click(object sender, EventArgs e)
        {
            if(username!= "FFFFFFF")

            {
                bool result = StudentRepository.insertStudentRoom( this.ID_Room, this.username);
                if (result)
                {
                    parent.InitData(ID_Room);
                    MessageBox.Show("Student has been added");
                    this.InitData(textBox1.Text);
                }
                else
                    MessageBox.Show("Error while adding a student");
            }
        }

       
    }
}
