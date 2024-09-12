using PrinterDemo.DB;
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
    public partial class NewProduct : Form
    {
        PrinterEntities1 db = new PrinterEntities1();
        string imagePath ="";
        public NewProduct()
        {
            InitializeComponent();
          //  comboBox1.SelectedValue =
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

            //PrinterDemo.DB  using this name space for using the data base table product not using the product form ;
         // PrinterDemo.DB.Product x = new PrinterDemo.DB.Product();
        private void button_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtBarcode.Text == "" || txtPrice.Text == "" || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("برجاء اكمال البيانات المطلوبه اولا");
            } else
            {
                int price;
                int quantity;
                if (!int.TryParse(txtPrice.Text, out price))
                {
                    MessageBox.Show("برجاء إدخال سعر صحيح (أرقام فقط)");
                    return; // Stop further execution if validation fails
                }

                // Check if the quantity is a valid integer
                if (!int.TryParse(txtQuantity.Text, out quantity))
                {
                    MessageBox.Show("برجاء إدخال كمية صحيحة (أرقام فقط)");
                    return; // Stop further execution if validation fails
                }
                Product product = new Product();
            product.Name = txtName.Text;
                product.Code = txtBarcode.Text;
                product.Name = txtName.Text;
                product.Notes = txtNotes.Text;
                product.CategoryId = int.Parse( comboBox1.SelectedValue.ToString());
                
                

                product.Price = price;
                product.Quantity = quantity;

                db.Products.Add(product);
                db.SaveChanges();
                MessageBox.Show("تم حفظ المنتج");

                if (imagePath != "")
                {

                string newPath = Environment.CurrentDirectory +"\\Products\\" + product.id + ".jpg";
                File.Copy(imagePath, newPath);

                product.Image = newPath;

                db.SaveChanges();


                }
                else
                {
                    
                }
                txtBarcode.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";
                txtNotes.Text = "";
                txtPicture.ImageLocation = "";
            }

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

        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'printerDataSet2.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.printerDataSet2.Category);

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductList  p = new ProductList();
            p.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
