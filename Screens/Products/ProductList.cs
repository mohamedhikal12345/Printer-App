﻿using PrinterDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterDemo.Screens.Products
{
    public partial class ProductList : Form
    {
        PrinterEntities db = new PrinterEntities();
        int id;
        PrinterDemo.DB.Product result;
        string imagePath = "";
        public ProductList()
        {
            InitializeComponent();

            // viewing the data in grid view from  database ;
            //  db.Products.ToList();
            dataGridView1.DataSource = db.Products.ToList();
        }





        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNamep.Text == "")
            {
             dataGridView1.DataSource = db.Products.Where(x => x.Code == txtBarcode1.Text ).ToList();

            }else
            {
                dataGridView1.DataSource = db.Products.Where(x => x.Code == txtBarcode1.Text || x.Name.Contains(txtNamep.Text)).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  db.Products.ToList();
            dataGridView1.DataSource = db.Products.ToList();
        }


        private void ProductList_Load(object sender, EventArgs e)
        {

        }

       

        private void txtBarcode1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
             id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
             result = db.Products.SingleOrDefault(x => x.id == id);

            txtFormBarcode.Text = result.Code;
            txtFormName.Text = result.Name;
            txtNotes.Text = result.Notes;
            txtPrice.Text =result.Price.ToString();
            txtQuantity.Text = result.Quantity.ToString();
            txtPicture.ImageLocation = result.Image;
            }
            catch { }
        }
        private void button_Click(object sender, EventArgs e)
        {
            
             
            result.Name = txtFormName.Text;
            result.Notes = txtNotes.Text;
            result.Code = txtFormBarcode.Text;
            result.Price = decimal.Parse(txtPrice.Text);
            result.Quantity = int.Parse(txtQuantity.Text);

            if (imagePath != "")
            {

                string newPath = Environment.CurrentDirectory + "\\Products\\" + result.id + ".jpg";
                File.Copy(imagePath, newPath, true);

                result.Image = newPath;

                db.SaveChanges();


            }
            db.SaveChanges();

            MessageBox.Show("تم الحفظ");

            dataGridView1.DataSource = db.Products.ToList();
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = dialog.FileName;
                txtPicture.ImageLocation = dialog.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            var r = MessageBox.Show("هل تريد الحذف" , "تاكيد الحذف", MessageBoxButtons.YesNo );

            if (r == DialogResult.Yes) { 
            
            
            

             var result = db.Products.Find(id);
            db.Products.Remove(result);

            db.SaveChanges();

            dataGridView1.DataSource = db.Products.ToList();
            MessageBox.Show("تم الحذف");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewProduct p = new NewProduct();
            p.Show();
        }
    }
}
