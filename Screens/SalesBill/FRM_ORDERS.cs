using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterDemo.Screens.SalesBill
{
    public partial class FRM_ORDERS : Form
    {
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();

        DataTable Dt = new DataTable();

        void CreateDataTable()
        {
            Dt.Columns.Add("معرف المنتج");
            Dt.Columns.Add("اسم المنتج");
            Dt.Columns.Add("السعر ");
            Dt.Columns.Add("معرف المنتج");
            Dt.Columns.Add("معرف المنتج");
            Dt.Columns.Add("معرف المنتج");
            Dt.Columns.Add("معرف المنتج");
            Dt.Columns.Add("معرف المنتج");
            Dt.Columns.Add("معرف المنتج");

        }


        public FRM_ORDERS()
        {
            InitializeComponent();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txtOrderID.Text = order.GET_LAST_ORDER_ID().Rows[0][0].ToString();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
        }

       

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

    }
}
