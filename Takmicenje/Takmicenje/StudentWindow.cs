using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Takmicenje.AdditionalClasses;
using Takmicenje.Models;
using Takmicenje.Repository;

namespace Takmicenje
{

    public partial class StudentWindow : Form
    {
        protected DataTable data;
        protected Student student;
        protected int ID_Room = -1;
        public StudentWindow(Student student)
        {
            this.student = student;
            InitializeComponent();
            label1.Text += student.name;
            label2.Text += student.surname;
            InitData(student);

        }
        public StudentWindow()
        {
            InitializeComponent();
        }

        public virtual void InitData(Student student)
        {
            this.data = RoomRepository.getAllRoomsOfStudent(student);
            roomDataGrid.DataSource = this.data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected virtual void button1_Click(object sender, EventArgs e)
        {
            if (this.ID_Room != -1)
            {
                StudentTasks sW = new StudentTasks(this.student, this.ID_Room);
                sW.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to choose a room");
            }
        }

        protected virtual void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ID_Room = Convert.ToInt32( CellClick.CellClickExecute(sender, e, this.roomDataGrid, this.data, 0, 5));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            InitData(this.student);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StudentResult SR = new StudentResult(this.student.username);
            SR.ShowDialog();
        }
    }
}
