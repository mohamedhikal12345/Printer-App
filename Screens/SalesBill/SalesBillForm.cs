using PrinterDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterDemo.Screens.SalesBill
{
    public partial class SalesBillForm : Form
    {
        PrinterEntities1 db = new PrinterEntities1();
        public SalesBillForm()
        {
            InitializeComponent();
            // txtQty.Text = "1";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SalesBillForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'printerDataSet10.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.printerDataSet10.Product);
            txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

            Dictionary<int, string> itemsData = new Dictionary<int, string>();
            itemsData.Add(10, "Item1");
            itemsData.Add(20, "Item2");
            itemsData.Add(30, "Item3");

            cbxItem.DataSource = new BindingSource(itemsData, null);
            cbxItem.DisplayMember = "Value";
            cbxItem.ValueMember = "Key";

            txtPrice.Text = cbxItem.SelectedValue.ToString();



            txtName.Focus();
            txtName.Select();
            txtName.SelectAll();


        }
        //private void SalesBillForm_Load(object sender, EventArgs e)
        //{
        //    // TODO: This line of code loads data into the 'printerDataSet10.Product' table. You can move, or remove it, as needed.
        //    this.productTableAdapter.Fill(this.printerDataSet10.Product);
        //    txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

        //    Dictionary<int , string> itemsData = new Dictionary<int , string>();
        //    itemsData.Add(10, "Item1");
        //    itemsData.Add(20, "Item2");
        //    itemsData.Add(30, "Item3");

        //    cbxItem.DataSource = new BindingSource(itemsData,null);
        //    cbxItem.DisplayMember = "Value";
        //    cbxItem.ValueMember = "Key";

        //    txtPrice.Text = cbxItem.SelectedValue.ToString();



        //    txtName.Focus();
        //    txtName.Select();
        //    txtName.SelectAll();


        //} //private void salesbillform_load(object sender, eventargs e)
        //    {
        //        // todo: this line of code loads data into the 'printerdataset10.product' table. you can move, or remove it, as needed.
        //        this.producttableadapter.fill(this.printerdataset10.product);
        //txtdate.text = datetime.now.tostring("yyyy/mm/dd");

        //dictionary<int , string> itemsdata = new dictionary<int, string>();
        //        itemsdata.add(10, "item1");
        //        itemsdata.add(20, "item2");
        //        itemsdata.add(30, "item3");

        //        cbxitem.datasource = new bindingsource(itemsdata,null);
        //cbxitem.displaymember = "value";
        //        cbxitem.valuemember = "key";

        //        txtprice.text = cbxitem.selectedvalue.tostring();



        //        txtname.focus();
        //        txtname.select();
        //        txtname.selectall();


        //    }
        //private void SalesBillForm_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Load data into the Product table
        //        this.productTableAdapter.Fill(this.printerDataSet10.Product);
        //        txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

        //        // Fetch items from the database
        //        var itemsData = db.Product
        //            .ToDictionary(p => p.ProductId, p => p.ProductName);

        //        // Bind the fetched data to the combo box
        //        cbxItem.DataSource = new BindingSource(itemsData, null);
        //        cbxItem.DisplayMember = "Value";
        //        cbxItem.ValueMember = "Key";

        //        // Set the price textbox to display the selected item's price
        //        UpdatePriceTextBox();

        //        // Focus and select the name textbox
        //        txtName.Focus();
        //        txtName.Select();
        //        txtName.SelectAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading data: " + ex.Message);
        //    }
        //}

        //private void UpdatePriceTextBox()
        //{
        //    if (cbxItem.SelectedValue != null)
        //    {
        //        int selectedItemId = (int)cbxItem.SelectedValue;
        //        var selectedItem = db.Product.FirstOrDefault(p => p.ProductId == selectedItemId);

        //        if (selectedItem != null)
        //        {
        //            txtPrice.Text = selectedItem.Price.ToString();
        //        }
        //    }
        //}


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void txtDate_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                txtDate.ContextMenu = new ContextMenu();
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;


        }

        private void txtTotal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                txtDate.ContextMenu = new ContextMenu();
            }

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                cbxItem.Focus();

            }
        }

        private void cbxItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                txtPrice.Focus();
                txtPrice.SelectAll();
            }
        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{

        //    if (cbxItem.SelectedIndex <= -1)return;




        //    // Item and quantity parsing should be straightforward as long as the input is valid
        //    string item = cbxItem.Text;

        //    // Parse quantity and price, with added validation using int.TryParse to avoid exceptions
        //    if (!int.TryParse(txtQty.Text, out int qty))
        //    {
        //        MessageBox.Show("ادخل كميه صحيحة");
        //        return;
        //    }

        //    if (!int.TryParse(txtPrice.Text, out int price))
        //    {
        //        MessageBox.Show("ادخل سعر صحيح");
        //        return;
        //    }

        //    int subTotal = qty * price;

        //    // Add a new row to the DataGridView
        //    object[] row = { item, qty, price, subTotal };
        //    dgvInvoice.Rows.Add(row);

        //    // Handle the txtTotal.Text safely
        //    int total;
        //    if (string.IsNullOrEmpty(txtTotal.Text) || !int.TryParse(txtTotal.Text, out total))
        //    {
        //        total = 0; // Initialize to 0 if the text is empty or invalid
        //    }

        //    // Update the total with the new subtotal
        //    total += subTotal;
        //    txtTotal.Text = total.ToString();
        //}
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (cbxItem.SelectedIndex <= -1) return;

        //    // Item and quantity parsing should be straightforward as long as the input is valid
        //    string item = cbxItem.Text;

        //    // Ensure the quantity is set to 1 if it hasn't been modified
        //    if (string.IsNullOrEmpty(txtQty.Text))
        //    {
        //        txtQty.Text = "1";
        //    }

        //    // Parse quantity and price, with added validation using int.TryParse to avoid exceptions
        //    if (!int.TryParse(txtQty.Text, out int qty))
        //    {
        //        MessageBox.Show("ادخل كميه صحيحة");
        //        return;
        //    }

        //    if (!int.TryParse(txtPrice.Text, out int price))
        //    {
        //        MessageBox.Show("ادخل سعر صحيح");
        //        return;
        //    }

        //    int subTotal = qty * price;

        //    // Add a new row to the DataGridView
        //    object[] row = { item, qty, price, subTotal };
        //    dgvInvoice.Rows.Add(row);

        //    // Handle the txtTotal.Text safely
        //    int total;
        //    if (string.IsNullOrEmpty(txtTotal.Text) || !int.TryParse(txtTotal.Text, out total))
        //    {
        //        total = 0; // Initialize to 0 if the text is empty or invalid
        //    }

        //    // Update the total with the new subtotal
        //    total += subTotal;
        //    txtTotal.Text = total.ToString();
        //}
        //
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (cbxItem.SelectedIndex <= -1) return;

        //    // Item and quantity parsing should be straightforward as long as the input is valid
        //    string item = cbxItem.Text;

        //    // Ensure the quantity is set to 1 if it hasn't been modified
        //    if (string.IsNullOrEmpty(txtQty.Text))
        //    {
        //        txtQty.Text = "1";
        //    }

        //    // Parse quantity and price, with added validation using int.TryParse to avoid exceptions
        //    if (!int.TryParse(txtQty.Text, out int qty))
        //    {
        //        MessageBox.Show("ادخل كميه صحيحة");
        //        return;
        //    }

        //    if (!int.TryParse(txtPrice.Text, out int price))
        //    {
        //        MessageBox.Show("ادخل سعر صحيح");
        //        return;
        //    }

        //    int subTotal = qty * price;

        //    // Add a new row to the DataGridView
        //    object[] row = { item, qty, price, subTotal };
        //    dgvInvoice.Rows.Add(row);

        //    // Handle the txtTotal.Text safely
        //    int total;
        //    if (string.IsNullOrEmpty(txtTotal.Text) || !int.TryParse(txtTotal.Text, out total))
        //    {
        //        total = 0; // Initialize to 0 if the text is empty or invalid
        //    }

        //    // Update the total with the new subtotal
        //    total += subTotal;
        //    txtTotal.Text = total.ToString();

        //    // Reset quantity field to 1 after adding the item
        //    txtQty.Text = "1";
        //}
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxItem.SelectedIndex <= -1) return;

            // Parse quantity and price, with added validation using int.TryParse to avoid exceptions
            if (!int.TryParse(txtQty.Text, out int qty))
            {
                MessageBox.Show("Enter a valid quantity.");
                return;
            }

            if (!int.TryParse(txtPrice.Text, out int price))
            {
                MessageBox.Show("Enter a valid price.");
                return;
            }

            int subTotal = qty * price;

            // Add a new row to the DataGridView
            object[] row = { cbxItem.Text, qty, price, subTotal };
            dgvInvoice.Rows.Add(row);

            // Update the total amount
            int total;
            if (string.IsNullOrEmpty(txtTotal.Text) || !int.TryParse(txtTotal.Text, out total))
            {
                total = 0;
            }
            total += subTotal;
            txtTotal.Text = total.ToString();

            // You can leave saving to the database here, or add it separately when the user finishes the invoice
        }

        //private void SaveInvoiceToDatabase()
        //{
        //    try
        //    {
        //        // Create a new SalesBill object to insert into the SalesBill table
        //        var salesBill = new SalesBill
        //        {
        //            CustomerName = txtName.Text,
        //            BillDate = DateTime.Now, // or you can parse from txtDate.Text
        //            TotalAmount = decimal.Parse(txtTotal.Text)
        //        };

        //        // Add the SalesBill object to the PrinterEntities context
        //        db.SalesBill.Add(salesBill);
        //        db.SaveChanges(); // Save the sales bill to the database and get the new SalesBillId

        //        // Now add each item in the DataGridView to the SalesBillItems table
        //        foreach (DataGridViewRow row in dgvInvoice.Rows)
        //        {
        //            // Get product details from the DataGridView
        //            string productName = row.Cells[0].Value.ToString();
        //            int quantity = Convert.ToInt32(row.Cells[1].Value);
        //            int price = Convert.ToInt32(row.Cells[2].Value);
        //            int subTotal = Convert.ToInt32(row.Cells[3].Value);

        //            // Get the product from the database by name
        //            var product = db.Product.FirstOrDefault(p => p.ProductName == productName);

        //            if (product != null)
        //            {
        //                // Create a new SalesBillItems object
        //                var salesBillItem = new SalesBillItem
        //                {
        //                    SalesBillId = salesBill.SalesBillId, // Use the ID of the saved SalesBill
        //                    ProductId = product.ProductId,
        //                    Quantity = quantity,
        //                    Price = price,
        //                    SubTotal = subTotal
        //                };

        //                // Add the SalesBillItems object to the PrinterEntities context
        //                db.SalesBillItems.Add(salesBillItem);
        //            }
        //        }

        //        // Save all the SalesBillItems to the database
        //        db.SaveChanges();

        //        MessageBox.Show("Invoice saved successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error saving invoice: " + ex.Message);
        //    }
        //}


        //
        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                txtQty.Focus();
                txtQty.SelectAll();
            }
        }
        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                btnAdd.PerformClick();
                cbxItem.Focus();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Text = cbxItem.SelectedValue.ToString();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }
        string oldQty = "1";
        private float preHeights;

        private void dgvInvoice_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvInvoice.CurrentRow != null)
            {
                oldQty = dgvInvoice.CurrentRow.Cells["colQty"].Value + "";

            }
        }

        private void dgvInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInvoice.CurrentRow != null)
            {

                string newQty = dgvInvoice.CurrentRow.Cells["colQty"].Value.ToString();

                if (oldQty == newQty) return;


                if (!Regex.IsMatch(newQty, "^\\d+$"))
                {
                    dgvInvoice.CurrentRow.Cells["colQty"].Value = oldQty;
                }
                else
                {
                    int q = int.Parse(newQty);
                    int p = (int)dgvInvoice.CurrentRow.Cells["colPrice"].Value;
                    dgvInvoice.CurrentRow.Cells["colSubTotal"].Value = (q * p);

                    int newTotal = 0;

                    foreach (DataGridViewRow r in dgvInvoice.Rows)
                    {

                        newTotal += Convert.ToInt32(r.Cells["colSubTotal"].Value);
                    }
                    txtTotal.Text = newTotal.ToString();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {//for photo
         // e.Graphics.DrawImage(Properties.Resources.Google_docs_logo, 5, 5, 200, 20);
         //for txt
            Font f = new Font("Arial", 18, FontStyle.Bold);
            string strNo = "NO" + textNum.Text;
            string strDate = "التاريخ : " + txtDate.Text;
            string strName = "مطلوب من السيد : " + txtName.Text;


            SizeF FontSizeNO = e.Graphics.MeasureString(strNo, f);
            SizeF FontSizeDate = e.Graphics.MeasureString(strDate, f);
            SizeF FontSizeName = e.Graphics.MeasureString(strName, f);

            float margin = 40;
            e.Graphics.DrawString("#NO" + textNum.Text, f, Brushes.Red, (e.PageBounds.Width - FontSizeNO.Width) / 2, margin);

            e.Graphics.DrawString(strDate, f, Brushes.Black, e.PageBounds.Width - FontSizeDate.Width - margin, margin + FontSizeNO.Height);

            e.Graphics.DrawString(strName, f, Brushes.Navy, e.PageBounds.Width - FontSizeName.Width - margin, margin + FontSizeNO.Height + FontSizeDate.Height);


            float preHeights = margin + FontSizeNO.Height + FontSizeDate.Height + 70;


            e.Graphics.DrawRectangle(Pens.Black, margin, preHeights, e.PageBounds.Width - margin * 2, e.PageBounds.Height - margin - preHeights);

            float colHeight = 50;

            float col1width = 300;

            float col2width = 125 + col1width;
            float col3width = 125 + col2width;
            float col4width = 125 + col3width;


            e.Graphics.DrawLine(Pens.Black, margin, preHeights + colHeight, e.PageBounds.Width - margin, preHeights + colHeight);


            e.Graphics.DrawString("الصنف", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col1width, preHeights);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col1width, preHeights, e.PageBounds.Width - margin * 2 - col1width, e.PageBounds.Height - margin);

            e.Graphics.DrawString("الكمية", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col2width, preHeights);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col2width, preHeights, e.PageBounds.Width - margin * 2 - col2width, e.PageBounds.Height - margin);


            e.Graphics.DrawString("السعر", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col3width, preHeights);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col3width, preHeights, e.PageBounds.Width - margin * 2 - col3width, e.PageBounds.Height - margin);

            e.Graphics.DrawString("اجمالي", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col4width, preHeights);


            //////////////////////////////Invoice  content///////////////////////////////////

            float rowsHeight = 50;

            for (int x = 0; x < dgvInvoice.Rows.Count; x += 1)
            {
                e.Graphics.DrawString(dgvInvoice.Rows[x].Cells[0].Value.ToString(), f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col1width, preHeights + rowsHeight);
                e.Graphics.DrawString(dgvInvoice.Rows[x].Cells[1].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - col2width, preHeights + rowsHeight);
                e.Graphics.DrawString(dgvInvoice.Rows[x].Cells[2].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - col3width, preHeights + rowsHeight);
                e.Graphics.DrawString(dgvInvoice.Rows[x].Cells[3].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - col4width, preHeights + rowsHeight);


                e.Graphics.DrawLine(Pens.Black, margin, preHeights + rowsHeight + colHeight, e.PageBounds.Width - margin, preHeights + rowsHeight + colHeight);



                rowsHeight += 50;
            }
            e.Graphics.DrawString("الاجمالي", f, Brushes.Red, e.PageBounds.Width - margin * 2 - col3width, preHeights + rowsHeight);
            e.Graphics.DrawString(txtTotal.Text, f, Brushes.Blue, e.PageBounds.Width - margin * 2 - col4width, preHeights + rowsHeight);
            e.Graphics.DrawLine(Pens.Black, margin, preHeights + rowsHeight + colHeight, e.PageBounds.Width - margin, preHeights + rowsHeight + colHeight);


        }
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }

}
