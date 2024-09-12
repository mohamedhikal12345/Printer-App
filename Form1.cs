
using PrinterDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterDemo
{
    public partial class Form1 : Form
    {

        PrinterEntities1 db = new PrinterEntities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // x=>x to find all users name on db
            var result = db.Users.FirstOrDefault(x => x.UserName == txtUser.Text && x.Password == txtPassword.Text);

            //MessageBox.Show(result.Count().ToString());

            if (result!= null)
            {

                // to close my form 
                this.Close();
                // for open new form as a new process 
                Thread th = new Thread(openForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

                Users.Name = result.UserName;
                Users.id = result.Id;

            }
            else
            {
                MessageBox.Show("User name or password are invalid");
            }
        }


        // showing the main form page 
        void openForm()
        {
            Application.Run(new MainForm());
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        static class Users
        {
            static public string Name { get; set; }
            static public int id { get; set; }

        }
    }
}
