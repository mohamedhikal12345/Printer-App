using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PrinterDemo.BL
{
    internal class CLS_ORDERS
    {
        //public DataTable GET_LAST_ORDER_ID()

        public DataTable GET_LAST_ORDER_ID()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_LAST_ORDER_ID", null);
            DAL.Close();
            return Dt;

        }
    }
}
