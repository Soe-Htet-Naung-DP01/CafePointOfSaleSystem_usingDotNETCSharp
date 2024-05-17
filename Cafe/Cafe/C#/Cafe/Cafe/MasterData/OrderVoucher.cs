using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cafe.DBA;


namespace Cafe.MasterData
{


    public partial class OrderVoucher : Form
    {


        clsOrder obj_clsOrder = new clsOrder();
        clsOrderVoucherDetail obj_clsOrderDetail = new clsOrderVoucherDetail();
        clsMenu obj_clsMenu = new clsMenu();
        clsMainDB obj_clsMainDB = new clsMainDB();

        DataTable DT = new DataTable();
        DataTable DTOrder = new DataTable();
        string SPString = "";
        int _OrderID = 0;

        public OrderVoucher()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int Ok;
            if (dgvOrderList.Rows.Count <= 1)
            {
                MessageBox.Show("There is no menu record!");
                dgvOrderList.Focus();
            }
            else if (lblOrderRefund.Text == "" || lblOrderRefund.Text == "0")
            {
                MessageBox.Show("Please check payment!!");
                txtOrderPayment.Focus();
            }
            else if (int.TryParse(txtDeliveryFees.Text, out Ok) == false)
            {
                MessageBox.Show("The Delivery Fees should be number!");
                txtDeliveryFees.Clear();
                txtDeliveryFees.Focus();
            }
            else
            {
                obj_clsOrder.ORDERVOUCHERID = lblOrderVoucherID.Text;
                obj_clsOrder.ORDERDATE = dateTimePicker1.Value.ToShortDateString();
                obj_clsOrder.ORDERTOTALAMOUNT = Convert.ToInt32(lblOrderTotal.Text);
                obj_clsOrder.ORDERTAX = Convert.ToInt32(lblOrderTax.Text);
                obj_clsOrder.ORDERGRANDTOTAL = Convert.ToInt32(lblOrderGrandTotal.Text);
                obj_clsOrder.USERID = Program.UserID;
                obj_clsOrder.ACTION = 0;
                obj_clsOrder.SaveData();
                SPString = string.Format("SP_Select_OrderVoucher N'{0}', N'{1}', N'{2}'", "0", "0", "3");
                DT = obj_clsMainDB.SelectData(SPString);
                _OrderID = Convert.ToInt32(DT.Rows[0]["OrderID"].ToString());

                for (int i = 0; i < DTOrder.Rows.Count; i++)
                {
                    obj_clsOrderDetail.ORDERID = _OrderID;
                    obj_clsOrderDetail.MENUID = Convert.ToInt32(DTOrder.Rows[i]["MenuID"].ToString());
                    obj_clsOrderDetail.ORDERQTY = Convert.ToInt32(DTOrder.Rows[i]["OrderQty"].ToString());
                    obj_clsOrderDetail.ORDERPRICE = Convert.ToInt32(DTOrder.Rows[i]["OrderPrice"].ToString());
                    obj_clsOrderDetail.ACTION = 0;
                    obj_clsOrderDetail.SaveData();

                    obj_clsMenu.MENUID = Convert.ToInt32(DTOrder.Rows[i]["MenuID"].ToString());
                    obj_clsMenu.QTY = Convert.ToInt32(DTOrder.Rows[i]["OrderQty"].ToString());
                    obj_clsMenu.ACTION = 4;
                    obj_clsMenu.SaveData();
                }

                //SPString = string.Format("SP_Select_SaleReport N'{0}', N'{1}', N'{2}'", "0", "0", "0");
                //DT = obj_clsMainDB.SelectData(SPString);
                //frm_Report frm = new frm_Report();
                //crpt_Voucher crpt = new crpt_Voucher();
                //crpt.SetDataSource(DT);
                //frmReport.crystalReportViewer1.ReportSource = crpt;
                //frmReport.ShowDialog();
                MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (lblOrderGrandTotal.Text == "")
            {
                MessageBox.Show("There is no menu.");
                dgvOrderList.Focus();
            }
            else
            {
                txtOrderPayment.Text = "";
                txtOrderPayment.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CreateTable();
            txtDeliveryFees.Text = "";
            txtOrderPayment.Text = "";
            lblCustomerAdd.Text = "";
            lblCustomerPhone.Text = "";
            lblOrderTax.Text = "";
            lblOrderGrandTotal.Text = "";
            lblOrderRefund.Text = "";
            lblOrderVoucherID.Text = "";
            lblOrderTotal.Text = "";
            dgvOrderList.Focus();
        }

        private void CreateTable()
        {
            DTOrder.Rows.Clear();
            DTOrder.Columns.Clear();

            DTOrder.Columns.Add("MenuID");
            DTOrder.Columns.Add("MenuName");
            DTOrder.Columns.Add("QtyOnHand");
            DTOrder.Columns.Add("OrderPrice");
            DTOrder.Columns.Add("OrderQty");
            DTOrder.Columns.Add("Total");
            dgvOrderList.DataSource = DTOrder;

            dgvOrderList.Columns[0].Visible = false;
            dgvOrderList.Columns[1].Width = (dgvOrderList.Width / 100) * 40;
            dgvOrderList.Columns[2].Width = (dgvOrderList.Width / 100) * 10;
            dgvOrderList.Columns[2].ReadOnly = true;
            dgvOrderList.Columns[3].Width = (dgvOrderList.Width / 100) * 20;
            dgvOrderList.Columns[3].ReadOnly = true;
            dgvOrderList.Columns[4].Width = (dgvOrderList.Width / 100) * 10;
            dgvOrderList.Columns[5].Width = (dgvOrderList.Width / 100) * 20;
            dgvOrderList.Columns[5].ReadOnly = true;
        }

        private void CalculateTotal()
        {
            int OrderGrandTotal = 0;
            int TotalSaleQty = 0;

            for (int i = 0; i < dgvOrderList.Rows.Count - 1; i++)
            {
                DataGridViewRow DR = dgvOrderList.Rows[i];
                int OrderQty = Convert.ToInt32(DR.Cells["OrderQty"].Value.ToString());
                int OrderPrice = Convert.ToInt32(DR.Cells["OrderPrice"].Value.ToString());
                int OrderTotal = OrderQty * OrderPrice;

                DR.Cells["OrderTotalAmount"].Value = OrderTotal.ToString();

                OrderGrandTotal += OrderTotal;
                TotalSaleQty += OrderQty;
            }

            lblOrderTotal.Text = OrderGrandTotal.ToString();
            lblOrderTax.Text = (TotalSaleQty * 50).ToString();
            lblOrderGrandTotal.Text = (Convert.ToInt32(lblOrderTotal.Text) + Convert.ToInt32(lblOrderTax.Text) + Convert.ToInt32(txtDeliveryFees.Text)).ToString();
            txtOrderPayment.Text = "0";
            lblOrderRefund.Text = "0";
        }

        private void dgvOrderList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int CurRow = 0, CurCol = 0;
            String MenuName = "";
            String OrderQty = "0";

            CurRow = dgvOrderList.CurrentCell.RowIndex;
            CurCol = dgvOrderList.CurrentCell.ColumnIndex;

            MenuName = dgvOrderList.Rows[CurRow].Cells["MenuName"].Value.ToString();
            if (MenuName != "")
            {
                if (CurCol - 1 == 1)
                {
                    SPString = String.Format("SP_Select_Menu N'{0}', N'{1}', N'{2}'", MenuName, "0", "6");
                    DT = obj_clsMainDB.SelectData(SPString);
                    if (DT.Rows.Count <= 0)
                    {
                        MessageBox.Show("This MenuName is not exist");
                        SendKeys.Send("{HOME}");
                    }
                    else
                    {
                        bool AddRow = true;
                        for (int i = 0; i < dgvOrderList.Rows.Count - 1; i++)
                        {
                            if (dgvOrderList.Rows[i].Cells["MenuName"].Value.ToString() == MenuName && i != CurRow)
                            {
                                MessageBox.Show("This Menu is already sold.");
                                AddRow = false;
                                SendKeys.Send("{HOME}");
                            }
                        }

                        if (AddRow)
                        {
                            dgvOrderList.Rows[CurRow].Cells["MenuID"].Value = DT.Rows[0]["MenuID"].ToString();
                            dgvOrderList.Rows[CurRow].Cells["QtyOnHand"].Value = DT.Rows[0]["Qty"].ToString();
                            dgvOrderList.Rows[CurRow].Cells["OrderPrice"].Value = DT.Rows[0]["Price"].ToString();
                            dgvOrderList.Rows[CurRow].Cells["OrderQty"].Value = "0";
                            dgvOrderList.Rows[CurRow].Cells["OrderTotal"].Value = "0";
                            SendKeys.Send("{TAB}");
                            SendKeys.Send("{TAB}");
                            CalculateTotal();
                        }
                    }
                }

                if (CurCol - 1 == 4)
                {
                    dgvOrderList.CurrentRow.Cells["OrderTotal"].Value = "0";

                    int OK;
                    OrderQty = dgvOrderList.Rows[CurRow].Cells["OrderQty"].Value.ToString();
                    if (int.TryParse(OrderQty, out OK) == false)
                    {
                        MessageBox.Show("OrderQty should be a number");
                        SendKeys.Send("{HOME}");
                        SendKeys.Send("{TAB}");
                    }
                    else if (Convert.ToInt32(OrderQty) <= 0 || Convert.ToInt32(OrderQty) > Convert.ToInt32(dgvOrderList.CurrentRow.Cells["QtyOnHand"].Value.ToString()))
                    {
                        MessageBox.Show("OrderQty should be between 1 and " + dgvOrderList.CurrentRow.Cells["QtyOnHand"].Value.ToString());
                        SendKeys.Send("{HOME}");
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        CalculateTotal();
                    }
                }
            }
        }

        private void dgvOrderList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtMenuName = (TextBox)e.Control;
            txtMenuName.AutoCompleteCustomSource.Clear();
            int CurCol = 0;
            CurCol = dgvOrderList.CurrentCell.ColumnIndex;
            if (CurCol == 1)
            {
                SPString = String.Format("SP_Select_Menu N'{0}', N'{1}', N'{2}'", "0", "0", "5");
                obj_clsMainDB.TextBoxData(ref txtMenuName, SPString, "MenuName");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SPString = string.Format("SP_Select_OrderVoucher N'{0}', N'{1}', N'{2}'", dateTimePicker1.Value.ToShortDateString(), "0", "2");
            DT = obj_clsMainDB.SelectData(SPString);
            int DateDiff = Convert.ToInt32(DT.Rows[0]["No"]);
            if (DateDiff > 0)
            {
                MessageBox.Show("Please Check OrderDate");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
            else if (DateDiff <= -7)
            {
                MessageBox.Show("Please Check OrderDate");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                SPString = string.Format("SP_Select_OrderVoucher N'{0}', N'{1}', N'{2}'", dateTimePicker1.Value.ToShortDateString(), "0", "1");
                lblOrderVoucherID.Text = obj_clsMainDB.GetOrderVoucher(SPString, dateTimePicker1.Value.ToShortDateString());
            }
        }

        private void OrderVoucher_Load(object sender, EventArgs e)
        {
            CreateTable();
            SPString = String.Format("SP_Select_OrderVoucher N'{0}', N'{1}', N'{2}'", dateTimePicker1.Value.ToShortDateString(), "0", "1");
            lblOrderVoucherID.Text = obj_clsMainDB.GetOrderVoucher(SPString, dateTimePicker1.Value.ToShortDateString());
            dgvOrderList.Focus();
        }

        private void txtOrderPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lblOrderTotal.Text == "" || lblOrderTotal.Text == "0")
            {
                MessageBox.Show("There is no menu record");
                dgvOrderList.Focus();
            }
            else
            {
                int OK;
                lblOrderRefund.Text = "0";
                if (e.KeyChar.Equals('\r'))
                {
                    if (txtOrderPayment.Text == "")
                    {
                        MessageBox.Show("Please Type Payment");
                        txtOrderPayment.Focus();
                    }
                    else if (int.TryParse(txtOrderPayment.Text, out OK) == false)
                    {
                        MessageBox.Show("Payment should be a number");
                        txtOrderPayment.Focus();
                        txtOrderPayment.SelectAll();
                    }
                    else if (Convert.ToInt32(txtOrderPayment.Text) < Convert.ToInt32(lblOrderGrandTotal.Text))
                    {
                        MessageBox.Show("Payment should be above " + lblOrderGrandTotal.Text);
                        txtOrderPayment.Focus();
                        txtOrderPayment.SelectAll();
                    }
                    else if (Convert.ToInt32(txtOrderPayment.Text) > Convert.ToInt32(lblOrderGrandTotal.Text) + 10000)
                    {
                        MessageBox.Show("Payment amount should be below " + (Convert.ToInt32(lblOrderGrandTotal.Text) + 10000));
                        txtOrderPayment.Focus();
                        txtOrderPayment.SelectAll();
                    }
                    else
                    {
                        lblOrderRefund.Text = (Convert.ToInt32(txtOrderPayment.Text) - Convert.ToInt32(lblOrderGrandTotal.Text)).ToString();
                    }
                }
            }
        }

    }
}
