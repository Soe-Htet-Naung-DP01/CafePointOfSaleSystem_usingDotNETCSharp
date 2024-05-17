using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Cafe.DBA
{
    class clsCustomer
    {
        public int CUSTOMERID { get; set; }
        public string CUSTOMERNAME { get; set; }
        public string CUSTOMERADDRESS { get; set; }
        public string CUSTOMERPHONE { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DatatBaseConn();
                SqlCommand sql = new SqlCommand("SP_Insert_Customer", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@CustomerID", CUSTOMERID);
                sql.Parameters.AddWithValue("@CustomerName", CUSTOMERNAME);
                sql.Parameters.AddWithValue("@CustomerAddress", CUSTOMERADDRESS);
                sql.Parameters.AddWithValue("@CustomerPhone", CUSTOMERPHONE);
                sql.Parameters.AddWithValue("@action", ACTION);
                sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in saving Data");
            }
            finally
            {
                obj_clsMainDB.con.Close();
            }
        }
    }
    
}
