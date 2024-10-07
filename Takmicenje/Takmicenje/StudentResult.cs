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
    public partial class StudentResult : Form
    {
            public string username;

            public StudentResult(string username)
            {
                this.username = username;
                InitializeComponent();
                InitData();
            }

            public void InitData()
            {
                DataTable ds = new DataTable();
                ds = RepositoryForAll.report4(this.username);
                results r1 = new results();
                r1.SetDataSource(ds);
                this.cR.ReportSource = r1;
                this.cR.Refresh();

            }
     }
    
}
