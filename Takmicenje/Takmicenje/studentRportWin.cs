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
    public partial class studentRportWin : Form
    {
        public int ID_Room;
        public string username;
        public studentRportWin(string username, int ID_Room)
        {
            InitializeComponent();
            this.ID_Room = ID_Room;
            this.username = username;
            InitData();
        }

        public void InitData()
        {
            DataTable dt = new DataTable();
            dt = RepositoryForAll.report2(this.username, this.ID_Room);
            if (dt == null)
                return;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                MessageBox.Show(Convert.ToString(dt.Rows[i].ItemArray[1]));
            }
            studentReport r = new studentReport();
            r.SetDataSource(dt);
            cR.ReportSource = r;
            cR.Refresh();
        }
    }
}
