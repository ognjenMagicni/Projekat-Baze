using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takmicenje.Repository;

namespace Takmicenje
{
    public partial class ReportWindow : Form
    {
        public int ID_Room;
        
        public ReportWindow(int ID_Room)
        {
            this.ID_Room = ID_Room;
            InitializeComponent();
            InitData();
        }

        public void InitData()
        {  
            DataTable ds = new DataTable();
            ds = RepositoryForAll.report(this.ID_Room);
            report r1 = new report();
            r1.SetDataSource(ds);
            this.cR.ReportSource = r1;
            this.cR.Refresh();

        }


    }
}
