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
    class clsSaleDetail
    {
        public int SID { get; set; }
        public int MENUID { get; set; }
        public int SQTY { get; set; }
        public int SPRICE { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DatatBaseConn();
                SqlCommand sql = new SqlCommand("SP_Insert_SaleDetail", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@SaleID", SID);
                sql.Parameters.AddWithValue("@MenuID", MENUID);
                sql.Parameters.AddWithValue("@SaleQty", SQTY);
                sql.Parameters.AddWithValue("@SalePrice", SPRICE);
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
