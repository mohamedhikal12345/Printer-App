//using PrinterDemo.DB;
using MySqlX.XDevAPI.Common;
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
        PrinterEntities1 db = new PrinterEntities1();
        int id;
        PrinterDemo.DB.Product result;
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
            dataGridView1.DataSource = db.Users.ToList();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Show confirmation dialog
            var r = MessageBox.Show("هل تريد الحذف", "تاكيد الحذف", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                // Assuming you're using username to delete the user, find the user
                var username = txtUser.Text;

                // Find the user based on the entered username
                var userToDelete = db.Users.FirstOrDefault(u => u.UserName == username);

                if (userToDelete != null)
                {
                    // Remove the user from the database
                    db.Users.Remove(userToDelete);
                    db.SaveChanges();
                    MessageBox.Show("تم الحذف بنجاح");
                }
                else
                {
                    // Show a message if the user was not found
                    MessageBox.Show("المستخدم غير موجود");
                }
                dataGridView1.DataSource = db.Users.ToList();

            }
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'printerDataSet11.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.printerDataSet11.Users);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                result = db.Products.SingleOrDefault(x => x.id == id);
            }
            catch
            {

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Users.ToList();

        }
    }
}
