//using PrinterDemo.DB;
using PrinterDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterDemo.Screens.Users
{
    public partial class NewUser : Form
    {
        // creating instance from my db
          PrinterEntities db = new PrinterEntities();
        public NewUser()
        {
            InitializeComponent();
            // when changing the files pathes it will be dynamic path ; no errors

          //  MessageBox.Show(Environment.CurrentDirectory);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            // create instance from my table and use the obj for acssesing the data 
           User obj = new User();
            obj.UserName = txtUser.Text;
            obj.Password = txtPassword.Text;
            // to add the data to the obj 
            db.Users.Add(obj);
            // to save data on db
            db.SaveChanges();

           MessageBox.Show("تم الحفظ");
        }

       private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
