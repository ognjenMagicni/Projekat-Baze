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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sifra_Click(object sender, EventArgs e)
        {

        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            Administrator admin = AdministratorRepository.getHashPasswordByUsername(username, password);
            Student st = StudentRepository.getHashPasswordByUsername(username, password);
            if (admin != null)
            {
                AdministratorWindow aW = new AdministratorWindow(admin);
                this.Hide();
                aW.Closed += (s, args) => this.Close();
                aW.Show();
            }else if(st != null)
            {
                StudentWindow sW = new StudentWindow(st);
                this.Hide();
                sW.FormClosed += (s, args) => this.Close();
                sW.Show();
            }
            else
            {
                MessageBox.Show("Wrong password or username");
            }
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            StudentSignUpForm ssuf = new StudentSignUpForm();
            ssuf.ShowDialog();
        }
    }
}
