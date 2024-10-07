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
    public partial class StudentSignUpForm : Form
    {
        public StudentSignUpForm()
        {
            InitializeComponent();
        }

        private void StudentSignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void passwordBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void surnameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.username = usernameBox.Text;
            s.name = nameBox.Text;
            s.surname = surnameBox.Text;

            if (passwordBox.Text == passwordBox2.Text)
            {
                s.setPassword(passwordBox.Text);
                if (StudentRepository.insertStudent(s))
                {
                    MessageBox.Show("Sign up is successfull");
                    this.Close();
                }
                else
                    MessageBox.Show("Error occured during sign up process");
            }
            else
                MessageBox.Show("Passwords do not match");
        }
    }
}
