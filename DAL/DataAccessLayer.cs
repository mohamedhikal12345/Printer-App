//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SqlClient;
//using System.Data;
//namespace PrinterDemo.DAL
//{
//    class DataAccessLayer
//    {
//        SqlConnection sqlconnection;
//        //this constructor inisialize the connection object 
//        public DataAccessLayer()
//        {
//            sqlconnection = new SqlConnection("Server=. ; Database = Printer ; Integrated Security = true");
//        }
//        // open connection 
//        public void Open()
//        {
//            if (sqlconnection.State != ConnectionState.Open)
//            {
//                sqlconnection.Open();

//            }
//        }
//        public void Close()
//        {
//            if (sqlconnection.State == ConnectionState.Open)
//            {
//                sqlconnection.Close();

//            }
//        }
//        public DataTable SelectData(string stored_procedure , SqlParameter[] param)
//        {
//            SqlCommand sqlcmd = new SqlCommand();   
//            sqlcmd.CommandType = CommandType.StoredProcedure;
//            sqlcmd.CommandText = stored_procedure;

//            if (param != null)
//            {
//                for (int i = 0 ; i < param.Length; i++)
//                {
//                    sqlcmd.Parameters.Add(param[i]);
//                }
//            }
//            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);

//            DataTable dt = new DataTable();

//            da.Fill(dt);
//            return dt;

//        }
//        public void ExecteCommand(string stored_procedure, SqlParameter[] param) 
//        {
//        SqlCommand sqlcmd = new SqlCommand();
//            sqlcmd.CommandType = CommandType.StoredProcedure;
//            sqlcmd.CommandText = stored_procedure;

//            if (param != null) 
//            {
//                sqlcmd.Parameters.AddRange(param);
//            }
//            sqlcmd.ExecuteNonQuery();
//        }



//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PrinterDemo.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;

        // Constructor to initialize the connection object
        public DataAccessLayer()
        {
            sqlconnection = new SqlConnection("Server=. ; Database = Printer ; Integrated Security = true");
        }

        // Open connection
        public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }

        // Close connection
        public void Close()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }

        // Method to select data using a stored procedure
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;  // Assign the connection to the command

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Method to execute non-query commands (like INSERT, UPDATE, DELETE)
        public void ExecteCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;  // Assign the connection to the command

            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }

            Open();  // Ensure the connection is open before executing the command
            sqlcmd.ExecuteNonQuery();
            Close(); // Close the connection after execution
        }
    }
}
