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
    public partial class StudentTasks : StudentWindow
    {
        int ID_Room;
        int ID_Task = -1;
        public StudentTasks(Student student, int ID_Room) 
        {
            InitializeComponent();
            this.label3.Text = "Tasks";
            this.openRoomBtn.Text = "Open task";
            this.openRoomBtn.Location = new Point(450, 9);
            this.ID_Room = ID_Room;
            this.student = student;
            InitData(this.student);
        }

        public override void InitData(Student student)
        {
            this.data = RepositoryForAll.getAllById(new[] { "Task.ID_Task", "Task.Title" },new []{ "Task","RoomTask","StudentRoom"},new[] {"ID_Task","FK_Task","FK_Room","FK_Room"},new[] { "StudentRoom.FK_Student","StudentRoom.FK_Room" },new object[] { this.student.username,this.ID_Room });
            this.roomDataGrid.DataSource = this.data;
        }

        protected override void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ID_Task = Convert.ToInt32(CellClick.CellClickExecute(sender, e, this.roomDataGrid, this.data, 0, 5));
            StudentTask sT = new StudentTask(this.student, this.ID_Task, this.ID_Room);
            sT.ShowDialog();
        }

        protected override void button1_Click(object sender, EventArgs e)
        {
            StudentTask sT = new StudentTask(this.student, this.ID_Task,this.ID_Room);
            sT.ShowDialog();
        }
    }
}
