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
using Takmicenje.Repository;

namespace Takmicenje
{
    public partial class AttachTaskForm : AddStudentForm
    {
        public int ID_Task = -1;
        public AttachTaskForm(int ID_Room, AdministratorRoom parent) : base(ID_Room, parent)
        {
               
        }

        public override void InitData(string input)
        {
            /*string[] select = { "ID_Task", "Title" };
            if (input == "")
                this.data = RepositoryForAll.getAllById(select,new[] { "Task" },null, null,new[] { input });
            else
                this.data = RepositoryForAll.getAllById(select, new[] { "Task" },null, new[] { "Title" },new[] { input });

            this.dataGridView1.DataSource = this.data;*/

            this.data = TaskRepository.getAllTaskByTitle(this.textBox1.Text, this.ID_Room);
            this.dataGridView1.DataSource = data;
        }

        protected override void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ID_Task = Convert.ToInt32(CellClick.CellClickExecute(sender, e, this.dataGridView1, this.data, 0, 5));
        }

        protected override void addBtn_Click(object sender, EventArgs e)
        {
            RepositoryForAll.insert(new[] { "FK_Task", "FK_Room" }, "RoomTask", new object[] {this.ID_Task,this.ID_Room}, 5);
            this.parent.InitData(this.ID_Room);
            this.InitData("");
        }

        protected override void searchBtn_Click(object sender, EventArgs e)
        {
            this.InitData(textBox1.Text);
        }




    }
}
