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
    public partial class ExamPaper : Form
    {
        public int ID_Room;

        public ExamPaper(int ID_Room)
        {
            this.ID_Room = ID_Room;
            InitializeComponent();
            InitData();
        }

        public void InitData()
        {
            DataTable ds = new DataTable();
            ds = RepositoryForAll.report3(this.ID_Room);
            exam r1 = new exam();
            r1.SetDataSource(ds);
            this.cR.ReportSource = r1;
            this.cR.Refresh();

        }
    }
}
