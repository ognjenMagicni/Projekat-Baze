using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Takmicenje.AdditionalClasses;
using Takmicenje.Models;
using Takmicenje.Repository;

namespace Takmicenje
{
    public partial class AdministratorRoom : Form
    {
        int ID_Room;
        DataTable roomData;
        DataTable taskData;
        string username="FFFFFFF";
        int ID_Task = -1;
        public AdministratorRoom(int ID_Room,string name,string surname)
        {
            this.ID_Room = ID_Room;
            InitializeComponent();
            this.name.Text += name;
            this.surname.Text += surname;
            InitData(this.ID_Room);
        }

        public void InitData(int r)
        {
            this.roomData = StudentRepository.getAllStudentsOfRoom(r);
            this.dataGridView1.DataSource = this.roomData;

            this.taskData = RepositoryForAll.getAllById(new[] { "ID_Task", "Title" }, new[] { "Task", "RoomTask"}, new[] {"ID_Task","FK_Task"},new[] { "FK_Room" },new object[] { this.ID_Room });
            this.dataGridView2.DataSource = this.taskData;

        }

        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            AddStudentForm aSF = new AddStudentForm(this.ID_Room,this);
            aSF.ShowDialog();
        }



        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            AttachTaskForm aTF = new AttachTaskForm(ID_Room, this);
            aTF.ShowDialog();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.username = Convert.ToString(CellClick.CellClickExecute(sender, e, dataGridView1, this.roomData, 0, ""));
            
        }

        private void deleteStudentBtn_Click(object sender, EventArgs e)
        {
            if (this.username == "FFFFFFF")
                MessageBox.Show("You have to choose a student");
            else
            {
                string[] table = { "StudentRoom" };
                string[] column = { "FK_Student" };
                bool result = RepositoryForAll.deleteById(new[] { "StudentRoom" }, null, new[] {"FK_Student"},new[]{ this.username });
                if (result)
                {
                    MessageBox.Show("Student has been removed");
                    InitData(this.ID_Room);
                }
                else
                    MessageBox.Show("Error occured");
            }
        }

        private void deleteTaskBtn_Click(object sender, EventArgs e)
        {
            if (this.ID_Task == -1)
                MessageBox.Show("You have to choose a task");
            else
            {
                bool result = RepositoryForAll.deleteById(new[] {"RoomTask"}, null, new[] {"FK_Task","FK_Room"}, new Object[] { this.ID_Task, this.ID_Room });
                if (result)
                {
                    MessageBox.Show("Task has been removed");
                    InitData(this.ID_Room);
                }
                else
                    MessageBox.Show("Error occured");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
            this.ID_Task = Convert.ToInt32(CellClick.CellClickExecute(sender,e,this.dataGridView2,this.taskData,0,5));
        }

        private void checkStudentBtn_Click(object sender, EventArgs e)
        {
            if (this.username == "FFFFFFF")
            {
                MessageBox.Show("You have to choose a student");
                return;
            }
            InputOutputForm iOF = new InputOutputForm(this.ID_Room, this.username);
            iOF.ShowDialog();
            /*studentRportWin SRW = new studentRportWin(this.username, this.ID_Room);
            SRW.ShowDialog();*/
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            ReportWindow rw = new ReportWindow(this.ID_Room);
            rw.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExamPaper EP = new ExamPaper(this.ID_Room);
            EP.ShowDialog();
        }
    }
}
