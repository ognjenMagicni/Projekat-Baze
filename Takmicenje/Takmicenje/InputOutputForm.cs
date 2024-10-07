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
    public partial class InputOutputForm : Form
    {
        int ID_Room;
        string username;
        DataTable dataTask = new DataTable();
        public InputOutputForm(int iD_Room, string username)
        {
            InitializeComponent();
            ID_Room = iD_Room;
            this.username = username;
            DataTable name = RepositoryForAll.getAllById(new[] { "Name","Surname" }, new[] { "Student"}, null, new[] {"Username"}, new[] { this.username });
            DataTable room = RepositoryForAll.getAllById(new[] { "Name" }, new[] { "Room" }, null, new[] { "ID_Room" }, new object[] { this.ID_Room });
            this.nameSurname.Text = name.Rows[0].ItemArray[0] + " " + name.Rows[0].ItemArray[1];
            this.roomName.Text = room.Rows[0].ItemArray[0]+" ";
            InitData();
        }

        public void InitData()
        {
            dataTask = RepositoryForAll.getAllById(new[] {"Submit.FK_Student", "Submit.FK_Task","InputOutput.Input", "InputOutput.Output","SubmitIO.UserOutput", "SubmitIO.Correct" }, new[] { "Submit", "SubmitIO", "InputOutput"}, new[] { "ID_Submit", "FK_Submit", "FK_IO", "ID_IO" }, new[] { "Submit.FK_Room","Submit.FK_Student" }, new Object[] {ID_Room, username });
            iOGrid.DataSource = dataTask;
        }
    }
}
