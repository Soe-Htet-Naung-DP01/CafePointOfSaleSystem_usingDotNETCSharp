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
    class clsOrderVoucherDetail
    {
        public int ORDERID { get; set; }
        public int MENUID {get; set;}
        public int ORDERQTY {get; set;}
        public int ORDERPRICE { get; set;}
        public string UPDATE { get; set; }
        public int ACTION { get; set; }
        

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DatatBaseConn();
                SqlCommand sql = new SqlCommand("SP_Insert_OrderVoucherDetail", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@OrderID", ORDERID);
                sql.Parameters.AddWithValue("@MenuId", MENUID);
                sql.Parameters.AddWithValue("@OrderQty", ORDERQTY);
                sql.Parameters.AddWithValue("@ORDERPRICE", ORDERPRICE);
                sql.Parameters.AddWithValue("@UpdateDate", UPDATE);
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
