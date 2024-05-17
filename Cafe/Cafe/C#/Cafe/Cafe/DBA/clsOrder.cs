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
    class clsOrder
    {
        public int ORDERID { get; set; }
        public string ORDERVOUCHERID { get; set; }
        public string ORDERDATE { get; set; }
        public int ORDERTOTALAMOUNT { get; set; }
        public int ORDERTAX {get; set;}
        public int ORDERGRANDTOTAL {get; set;}
        public int USERID { get; set;}
        public int DELIVERYFEES {get; set;}
        public int ACTION { get; set; }
        

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DatatBaseConn();
                SqlCommand sql = new SqlCommand("SP_Insert_OrderVoucher", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@OrderID", ORDERID);
                sql.Parameters.AddWithValue("@OrderVoucherID", ORDERVOUCHERID);
                sql.Parameters.AddWithValue("@OrderDate", ORDERDATE);
                sql.Parameters.AddWithValue("@OrderTotalAmount", ORDERTOTALAMOUNT);
                sql.Parameters.AddWithValue("@OrderTax", ORDERTAX);
                sql.Parameters.AddWithValue("@OrderGrandTotal", ORDERGRANDTOTAL );
                sql.Parameters.AddWithValue("@UserID", USERID);
                sql.Parameters.AddWithValue("@DeliveryFees", DELIVERYFEES);
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
