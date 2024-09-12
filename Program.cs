using PrinterDemo.DB;
using PrinterDemo.Screens.Products;
using PrinterDemo.Screens.SalesBill;
using PrinterDemo.Screens.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterDemo
{
    internal static class Program
    {
        /// <summary> 
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProductList());
        }
    }
}
