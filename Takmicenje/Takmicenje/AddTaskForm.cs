using System;
using System.Collections;
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
    
    public partial class AddTaskForm : Form
    {
        Queue<string> input = new Queue<string>();
        Queue<string> output = new Queue<string>();
        Administrator admin;
        AdministratorWindow parent;
        public AddTaskForm(Administrator admin,AdministratorWindow parent)
        {
            this.admin = admin;
            InitializeComponent();
            this.parent = parent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(inputBox.Text=="" && outputBox.Text == "")
            {
                MessageBox.Show("You have to enter dato to input and output");
            }
            else
            {
                input.Enqueue(inputBox.Text);
                output.Enqueue(outputBox.Text);
                showBox.Text += "Test Sample:\n";
                showBox.Text += inputBox.Text + "\n";
                showBox.Text += outputBox.Text + "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] attributes = { "Title", "Description","FK_Admin" };
            Object[] values = { titleBox.Text, descriptionBox.Text, this.admin.Username };
            int result = Convert.ToInt32(RepositoryForAll.insert(attributes, "Task", values, 5,true));
            parent.InitData(this.admin);


            while (input.Count > 0)
            {
                string[] attributes1 = { "FK_Task", "Input", "Output" };
                Object[] values1 = { result, input.Dequeue(), output.Dequeue() };
                RepositoryForAll.insert(attributes1,"InputOutput" ,values1, 5);
            }

            MessageBox.Show("It should have saved all records");




            /*while (input.Count != 0)
            {
                string
                bool result1 = RepositoryForAll.insert(attributes,) 
            }*/
        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void outputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddTaskForm_Load(object sender, EventArgs e)
        {

        }
    }
}
