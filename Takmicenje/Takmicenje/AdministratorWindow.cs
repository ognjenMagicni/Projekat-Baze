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
    public partial class AdministratorWindow : Form
    {
        DataTable data;
        DataTable dataTask;
        Administrator admin;
        int id = -1;
        int idTask = -1;
        public AdministratorWindow(Administrator admin)
        {
           
            this.admin = admin;
            InitializeComponent();
            name.Text += admin.Name;
            surname.Text += admin.Surname;
            InitData(admin);

        }

        public void InitData(Administrator admin)
        {
            string[] select = {"ID_Task","Title" };
            this.dataTask = RepositoryForAll.getAllById(select,new[] { "Task" },null,new[] { "FK_Admin" }, new[] { admin.Username });
            this.data = RoomRepository.getAllRoomsOfAdmin(admin);
            roomDataGrid.DataSource = this.data;
            taskGridView.DataSource = this.dataTask;
        }

        private void roomDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void roomDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr = this.data.Rows[e.RowIndex];
            id = Convert.ToInt32(dr.ItemArray[0]);
            

        }

        private void addRoomBtn_Click(object sender, EventArgs e)
        {
            Insert i = new Insert(this.admin,this);
            i.ShowDialog();
        }

        private void deleteRoomBtn_Click(object sender, EventArgs e)
        {
            if (this.id == -1)
                MessageBox.Show("You have to choose a room");
            else
            {
                bool result = RoomRepository.deleteRoomById(this.id);
                if (result)
                {
                    MessageBox.Show("Room was successfully deleted");
                    InitData(this.admin);
                }
                else
                {
                    MessageBox.Show("Error, program did not erase room");
                }
            }
        }

        private void openBtn_Click(object sender, EventArgs e)

        {
            if (this.id == -1)
                MessageBox.Show("You have to choose a room");
            else
            {
                AdministratorRoom aR = new AdministratorRoom(this.id,this.admin.Name,this.admin.Surname);
                aR.ShowDialog();
            }
        }

        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            AddTaskForm aDF = new AddTaskForm(this.admin, this);
            aDF.ShowDialog();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.idTask == -1)
            {
                MessageBox.Show("You have to choose record");
                return;
            }
            bool result1 = RepositoryForAll.deleteById(new[] { "StudentTask" }, null, new[] { "FK_Task" }, new Object[] { this.idTask });
            bool result2 = RepositoryForAll.deleteById(new[] { "RoomTask" }, null, new[] { "FK_Task" }, new Object[] { this.idTask });
            bool result36 = RepositoryForAll.deleteById(new[] { "SubmitIO" }, null, new[] { "FK_Task" }, new Object[] { this.idTask });
            bool result3 = RepositoryForAll.deleteById(new[] { "InputOutput" }, null, new[] { "FK_Task" }, new Object[] { this.idTask });
            bool result35 = RepositoryForAll.deleteById(new[] { "Submit" }, null, new[] { "FK_Task" }, new Object[] { this.idTask });
            bool result4 = RepositoryForAll.deleteById(new[] { "Task" }, null, new[] { "ID_Task" }, new Object[] { this.idTask });

            if (result1 && result2 && result3 && result4)
            {
                MessageBox.Show("Record has been deleted");
                InitData(this.admin);
            }
            else
                MessageBox.Show("Error has occured");
        }

        private void taskGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.idTask = Convert.ToInt32(CellClick.CellClickExecute(sender, e, taskGridView, this.dataTask, 0, 5));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.idTask == -1)
            {
                MessageBox.Show("You have to choose record");
                return;
            }

            TaskForm tF = new TaskForm( this.idTask);
            tF.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
