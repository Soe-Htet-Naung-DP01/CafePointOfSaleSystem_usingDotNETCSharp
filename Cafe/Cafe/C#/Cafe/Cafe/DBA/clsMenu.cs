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
    class clsMenu
    {
        public int MENUID { get; set; }
        public string MENUNAME { get; set; }
        public int QTY { get; set; }
        public int PRICE { get; set; }
        public string UPDATE { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DatatBaseConn();
                SqlCommand sql = new SqlCommand("SP_Insert_Menu", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@MenuID", MENUID);
                sql.Parameters.AddWithValue("@MenuName", MENUNAME);
                sql.Parameters.AddWithValue("@Qty", QTY);
                sql.Parameters.AddWithValue("@Price", PRICE);
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
