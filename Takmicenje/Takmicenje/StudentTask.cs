using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takmicenje.AdditionalClasses;
using Takmicenje.Models;
using Takmicenje.Repository;

namespace Takmicenje
{
    public partial class StudentTask : Form
    {
        public int ID_Room;
        public Student student;
        public int ID_Task;
        string finishedTask = null;
        public StudentTask(Student student, int ID_Task,int ID_Room)
        {
            InitializeComponent();
            this.student = student;
            this.ID_Task = ID_Task;
            this.ID_Room = ID_Room;
            InitData();
        }

        public void InitData()
        {
            DataTable dt = RepositoryForAll.getAllById(new[] { "Title", "Description" }, new[] { "Task" }, null,new[] { "ID_Task" },new object[] { this.ID_Task });
            titleBox.Text = Convert.ToString(dt.Rows[0].ItemArray[0]);
            descriptionBox.Text = Convert.ToString(dt.Rows[0].ItemArray[1]);
        }

        protected void browse_Click(object sender, EventArgs e)
        {
            this.filePathBox.Text = "";

            OpenFileDialog oFD = new OpenFileDialog();
            oFD.ShowDialog();
            this.filePathBox.Text = oFD.FileName;
            if (this.filePathBox.Text == "")
                return;
            using(System.IO.StreamReader reader = new System.IO.StreamReader(this.filePathBox.Text))
            {
                this.finishedTask = reader.ReadToEnd();
            }
            
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if(this.finishedTask == null)
            {
                MessageBox.Show("You have to choose your task");
                return;
            }
            double result = ChekingTasks.Do(this.student.username, this.ID_Task, this.ID_Room, this.finishedTask);
            if (result != -1.0)
            {
                MessageBox.Show("You have submited successfully");
                this.resultBox.Text = Convert.ToString(result*100)+"%";
                return;
            }
            MessageBox.Show("Error happened");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
