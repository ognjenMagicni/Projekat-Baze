using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takmicenje.Models;
using Takmicenje.Repository;

namespace Takmicenje
{
    public partial class Insert : Form
    {
        Administrator admin;
        AdministratorWindow parent;
        public Insert(Administrator admin, AdministratorWindow parent)
        {
            this.parent = parent;
            this.admin = admin;
            InitializeComponent();
            this.parent = parent;
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            Room r = new Room();
            r.Name = nameBox.Text;
            if (RoomRepository.insertRoom(r, this.admin))
                MessageBox.Show("Uspesno dodata soba");
           
                
            parent.InitData(this.admin);
        }
    }
}
