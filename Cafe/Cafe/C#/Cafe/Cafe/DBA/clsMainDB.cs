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
    class clsMainDB
    {
        public SqlConnection con;
        DataSet DS = new DataSet();

        public void DatatBaseConn()
        {
            try
            {
                con = new SqlConnection(Cafe.Properties.Settings.Default.Cafe);
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in Database connection");
            }
        }

        public DataTable SelectData(string SPString)
        {
            DataTable DT = new DataTable();
            try
            {
                DatatBaseConn();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in Selecting Data");
            }
            finally
            {
                con.Close();
            }
            return DT;
        }

        public void ToolStripTextBoxData(ref ToolStripTextBox tstToolStrip, string SPString, string FieldName)
        {
            DataTable DT = new DataTable();
            AutoCompleteStringCollection Source = new AutoCompleteStringCollection();
            try
            {
                DatatBaseConn();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
                if (DT.Rows.Count > 0)
                {
                    tstToolStrip.AutoCompleteCustomSource.Clear();
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        Source.Add(DT.Rows[i][FieldName].ToString());
                    }
                    tstToolStrip.AutoCompleteCustomSource = Source;
                    tstToolStrip.Text = "";
                    tstToolStrip.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in ToolStrip TextBox Data");
            }
            finally
            {
                con.Close();
            }
        }

        public void AddCombo(ref ComboBox cboCombo, string SPString, string Display, string Value)
        {
            DataTable DT = new DataTable();
            DataTable DTCombo = new DataTable();
            DataRow Dr;

            DTCombo.Columns.Add(Display);
            DTCombo.Columns.Add(Value);

            Dr = DTCombo.NewRow();
            Dr[Display] = "---Select---";
            Dr[Value] = 0;
            DTCombo.Rows.Add(Dr);

            try
            {
                DatatBaseConn();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    Dr = DTCombo.NewRow();
                    Dr[Display] = DT.Rows[i][Display];
                    Dr[Value] = DT.Rows[i][Value];
                    DTCombo.Rows.Add(Dr);
                }
                cboCombo.DisplayMember = Display;
                cboCombo.ValueMember = Value;
                cboCombo.DataSource = DTCombo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in adding Combo");
            }
            finally
            {
                con.Close();
            }
        }

        public void TextBoxData(ref TextBox txtTextBox, string SPString, string FieldName)
        {
            DataTable DT = new DataTable();
            AutoCompleteStringCollection Source = new AutoCompleteStringCollection();

            txtTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            try
            {
                DatatBaseConn();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
                if (DT.Rows.Count > 0)
                {
                    txtTextBox.AutoCompleteCustomSource.Clear();
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        Source.Add(DT.Rows[i][FieldName].ToString());
                    }
                    txtTextBox.AutoCompleteCustomSource = Source;
                    txtTextBox.Text = "";
                    txtTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in TextBox Data");
            }
            finally
            {
                con.Close();
            }
        }

        public String GetVoucher(string SPString, String Date)
        {
            DataTable DT = new DataTable();
            try
            {
                DatatBaseConn();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
                if (DT.Rows.Count > 0 && DT.Rows[0]["Voucher"].ToString() != string.Empty)
                {
                    int No = Convert.ToInt32(DT.Rows[0]["Voucher"]) + 1;
                    return (string.Format("S{0:D3}", No) + "-" + Date);
                }
                else
                {
                    return ("S001-" + Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in GetVoucher");
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public String GetMenuID(string SPString)
        {
            DataTable DT = new DataTable();
            try
            {
                DatatBaseConn();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
                if (DT.Rows.Count > 0 && DT.Rows[0]["MenuID"].ToString() != string.Empty)
                {
                    int No = Convert.ToInt32(DT.Rows[0]["MenuID"]) + 1;
                    return (string.Format("{0:D3}", No));
                }
                else
                {
                    return ("0001");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in MenuID");
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        
        public String GetCustomerID(string SPString)
        {
            DataTable DT = new DataTable();
            try
            {
                DatatBaseConn();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
                if (DT.Rows.Count > 0 && DT.Rows[0]["CustomerID"].ToString() != string.Empty)
                {
                    int No = Convert.ToInt32(DT.Rows[0]["CustomerID"]) + 1;
                    return (string.Format("C{0:D3}", No));
                }
                else
                {
                    return ("C001");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in CustomerID");
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public String GetDeliveryManID(string SPString)
        {
            DataTable DT = new DataTable();
            try
            {
                DatatBaseConn();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
                if (DT.Rows.Count > 0 && DT.Rows[0]["DeliveryManID"].ToString() != string.Empty)
                {
                    int No = Convert.ToInt32(DT.Rows[0]["DeliveryManID"]) + 1;
                    return (string.Format("D{0:D3}", No));
                }
                else
                {
                    return ("D001");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in DeliveryManID");
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public String GetOrderVoucher(string SPString, String Date)
        {
            DataTable DT = new DataTable();
            try
            {
                DatatBaseConn();
                SqlDataAdapter Adpt = new SqlDataAdapter(SPString, con);
                Adpt.Fill(DT);
                if (DT.Rows.Count > 0 && DT.Rows[0]["OrderVoucherID"].ToString() != string.Empty)
                {
                    int No = Convert.ToInt32(DT.Rows[0]["OrderVoucherID"]) + 1;
                    return (string.Format("{0:D3}", No));
                }
                else
                {
                    return ("001");
                }
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Error in OrderVoucherID");
            //    return null;
            //}
            finally
            {
                con.Close();
            }
        }
    }
}
