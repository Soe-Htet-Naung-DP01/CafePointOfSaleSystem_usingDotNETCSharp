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
    class clsDelivery
    {
        public int DELIVERYMANID { get; set; }
        public string DELIVERYMANNAME { get; set; }
        public string DELIVERYMANPHONE { get; set; }
        public string DELIVERYMANNRC { get; set; }
        public string DELIVERYMANADDRESS { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DatatBaseConn();
                SqlCommand sql = new SqlCommand("SP_Insert_DeliveryMan", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@DeliveryManID", DELIVERYMANID);
                sql.Parameters.AddWithValue("@DeliveryManName", DELIVERYMANNAME);
                sql.Parameters.AddWithValue("@DeliveryManPhone", DELIVERYMANPHONE);
                sql.Parameters.AddWithValue("@DeliveryManNRC", DELIVERYMANNRC);
                sql.Parameters.AddWithValue("@DeliveryManAddress", DELIVERYMANADDRESS);
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
