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
using Cafe.MasterData;

namespace Cafe.MasterData
{


    public partial class frmSale : Form
    {

        clsSale obj_clsSale = new clsSale();
        clsSaleDetail obj_clsSaleDetail = new clsSaleDetail();
        clsMenu obj_clsMenu = new clsMenu();
        clsMainDB obj_clsMainDB = new clsMainDB();

        DataTable DT = new DataTable();
        DataTable DTSale = new DataTable();
        string SPString = "";
        int _SaleID = 0;

        public frmSale()
        {
            InitializeComponent();
        }

        private void CreateTable()
        {
            DTSale.Rows.Clear();
            DTSale.Columns.Clear();

            DTSale.Columns.Add("MenuID");
            DTSale.Columns.Add("MenuName");
            DTSale.Columns.Add("QtyOnHand");
            DTSale.Columns.Add("SalePrice");
            DTSale.Columns.Add("SaleQty");
            DTSale.Columns.Add("Total");
            dgvSale.DataSource = DTSale;

            dgvSale.Columns[0].Visible = false;
            dgvSale.Columns[1].Width = (dgvSale.Width / 100) * 40;
            dgvSale.Columns[2].Width = (dgvSale.Width / 100) * 10;
            dgvSale.Columns[2].ReadOnly = true;
            dgvSale.Columns[3].Width = (dgvSale.Width / 100) * 20;
            dgvSale.Columns[3].ReadOnly = true;
            dgvSale.Columns[4].Width = (dgvSale.Width / 100) * 10;
            dgvSale.Columns[5].Width = (dgvSale.Width / 100) * 20;
            dgvSale.Columns[5].ReadOnly = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CreateTable();
            lblTotalAmount.Text = "";
            lblTax.Text = "";
            lblGrandTotal.Text = "";
            txtPayment.Text = "";
            lblRefund.Text = "";
            dgvSale.Focus();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (lblGrandTotal.Text == "")
            {
                MessageBox.Show("There is no menu.");
                dgvSale.Focus();
            }
            else
            {
                txtPayment.Text = "";
                txtPayment.Focus();
            }
        }

        private void frmSale_Load(object sender, EventArgs e)
        {
            CreateTable();
            SPString = String.Format("SP_Select_Sale N'{0}', N'{1}', N'{2}'", dtpDate.Value.ToShortDateString(), "0", "1");
            lblSaleVoucher.Text = obj_clsMainDB.GetVoucher(SPString, dtpDate.Value.ToShortDateString());
            dgvSale.Focus();
        }

        private void dgvSale_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtMenuName = (TextBox)e.Control;
            txtMenuName.AutoCompleteCustomSource.Clear();
            int CurCol = 0;
            CurCol = dgvSale.CurrentCell.ColumnIndex;
            if (CurCol == 1)
            {
                SPString = String.Format("SP_Select_Menu N'{0}', N'{1}', N'{2}'", "0", "0", "5");
                obj_clsMainDB.TextBoxData(ref txtMenuName, SPString, "MenuName");
            }
        }

        private void CalculateTotal()
        {
            int GrandTotal = 0;
            int TotalSaleQty = 0;

            for (int i = 0; i < dgvSale.Rows.Count - 1; i++)
            {
                DataGridViewRow DR = dgvSale.Rows[i];
                int SaleQty = Convert.ToInt32(DR.Cells["SaleQty"].Value.ToString());
                int SalePrice = Convert.ToInt32(DR.Cells["SalePrice"].Value.ToString());
                int Total = SaleQty * SalePrice;

                DR.Cells["Total"].Value = Total.ToString();

                GrandTotal += Total;
                TotalSaleQty += SaleQty;
            }
            lblTotalAmount.Text = GrandTotal.ToString();
            lblTax.Text = (TotalSaleQty * 50).ToString();
            lblGrandTotal.Text = (Convert.ToInt32(lblTotalAmount.Text) + Convert.ToInt32(lblTax.Text)).ToString();
            txtPayment.Text = "0";
            lblRefund.Text = "0";
        }

        private void dgvSale_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int CurRow = 0, CurCol = 0;
            String MenuName = "";
            String SaleQty = "0";

            CurRow = dgvSale.CurrentCell.RowIndex;
            CurCol = dgvSale.CurrentCell.ColumnIndex;

            MenuName = dgvSale.Rows[CurRow].Cells["MenuName"].Value.ToString();
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
                        for (int i = 0; i < dgvSale.Rows.Count - 1; i++)
                        {
                            if (dgvSale.Rows[i].Cells["MenuName"].Value.ToString() == MenuName && i != CurRow)
                            {
                                MessageBox.Show("This Menu is already sold.");
                                AddRow = false;
                                SendKeys.Send("{HOME}");
                            }
                        }

                        if (AddRow)
                        {
                            dgvSale.Rows[CurRow].Cells["MenuID"].Value = DT.Rows[0]["MenuID"].ToString();
                            dgvSale.Rows[CurRow].Cells["QtyOnHand"].Value = DT.Rows[0]["Qty"].ToString();
                            dgvSale.Rows[CurRow].Cells["SalePrice"].Value = DT.Rows[0]["Price"].ToString();
                            dgvSale.Rows[CurRow].Cells["SaleQty"].Value = "0";
                            dgvSale.Rows[CurRow].Cells["Total"].Value = "0";
                            SendKeys.Send("{TAB}");
                            SendKeys.Send("{TAB}");
                            CalculateTotal();
                        }
                    }
                }
                if (CurCol - 1 == 4)
                {
                    dgvSale.CurrentRow.Cells["Total"].Value = "0";

                    int OK;
                    SaleQty = dgvSale.Rows[CurRow].Cells["SaleQty"].Value.ToString();
                    if (int.TryParse(SaleQty, out OK) == false)
                    {
                        MessageBox.Show("SaleQty should be a number");
                        SendKeys.Send("{HOME}");
                        SendKeys.Send("{TAB}");
                    }
                    else if (Convert.ToInt32(SaleQty) <= 0 || Convert.ToInt32(SaleQty) > Convert.ToInt32(dgvSale.CurrentRow.Cells["QtyOnHand"].Value.ToString()))
                    {
                        MessageBox.Show("SaleQty should be between 1 and " + dgvSale.CurrentRow.Cells["QtyOnHand"].Value.ToString());
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

        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lblTotalAmount.Text == "" || lblTotalAmount.Text == "0")
            {
                MessageBox.Show("There is no menu record");
                dgvSale.Focus();
            }
            else
            {
                int OK;
                lblRefund.Text = "0";
                if (e.KeyChar.Equals('\r'))
                {
                    if (txtPayment.Text == "")
                    {
                        MessageBox.Show("Please Type Payment");
                        txtPayment.Focus();
                    }
                    else if (int.TryParse(txtPayment.Text, out OK) == false)
                    {
                        MessageBox.Show("Payment should be a number");
                        txtPayment.Focus();
                        txtPayment.SelectAll();
                    }
                    else if (Convert.ToInt32(txtPayment.Text) < Convert.ToInt32(lblGrandTotal.Text))
                    {
                        MessageBox.Show("Payment should be above " + lblGrandTotal.Text);
                        txtPayment.Focus();
                        txtPayment.SelectAll();
                    }
                    else if (Convert.ToInt32(txtPayment.Text) > Convert.ToInt32(lblGrandTotal.Text) + 10000)
                    {
                        MessageBox.Show("Payment amount should be below " + (Convert.ToInt32(lblGrandTotal.Text) + 10000));
                        txtPayment.Focus();
                        txtPayment.SelectAll();
                    }
                    else
                    {
                        lblRefund.Text = (Convert.ToInt32(txtPayment.Text) - Convert.ToInt32(lblGrandTotal.Text)).ToString();
                    }
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SPString = string.Format("SP_Select_Sale N'{0}', N'{1}', N'{2}'", dtpDate.Value.ToShortDateString(), "0", "2");
            DT = obj_clsMainDB.SelectData(SPString);
            int DateDiff = Convert.ToInt32(DT.Rows[0]["No"]);
            if (DateDiff > 0)
            {
                MessageBox.Show("Please Check SaleDate");
                dtpDate.Text = DateTime.Now.ToShortDateString();
            }
            else if (DateDiff <= -7)
            {
                MessageBox.Show("Please Check SaleDate");
                dtpDate.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                SPString = string.Format("SP_Select_Sale N'{0}', N'{1}', N'{2}'", dtpDate.Value.ToShortDateString(), "0", "1");
                lblSaleVoucher.Text = obj_clsMainDB.GetVoucher(SPString, dtpDate.Value.ToShortDateString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvSale.Rows.Count <= 1)
            {
                MessageBox.Show("There is no menu record!");
                dgvSale.Focus();
            }
            else if (lblRefund.Text == "" || lblRefund.Text == "0")
            {
                MessageBox.Show("Please check payment!!");
                txtPayment.Focus();
            }
            else
            {
                obj_clsSale.VOUCHER = lblSaleVoucher.Text;
                obj_clsSale.SDATE = dtpDate.Value.ToShortDateString();
                obj_clsSale.TOTALAMT = Convert.ToInt32(lblTotalAmount.Text);
                obj_clsSale.TAX = Convert.ToInt32(lblTax.Text);
                obj_clsSale.GRANDTOTAL = Convert.ToInt32(lblGrandTotal.Text);
                obj_clsSale.USERID = Program.UserID;
                obj_clsSale.ACTION = 0;
                obj_clsSale.SaveData();
                SPString = string.Format("SP_Select_Sale N'{0}', N'{1}', N'{2}'", "0", "0", "3");
                DT = obj_clsMainDB.SelectData(SPString);
                _SaleID = Convert.ToInt32(DT.Rows[0]["SaleID"].ToString());

                for (int i = 0; i < DTSale.Rows.Count; i++)
                {
                    obj_clsSaleDetail.SID = _SaleID;
                    obj_clsSaleDetail.MENUID = Convert.ToInt32(DTSale.Rows[i]["MenuID"].ToString());
                    obj_clsSaleDetail.SQTY = Convert.ToInt32(DTSale.Rows[i]["SaleQty"].ToString());
                    obj_clsSaleDetail.SPRICE = Convert.ToInt32(DTSale.Rows[i]["SalePrice"].ToString());
                    obj_clsSaleDetail.ACTION = 0;
                    obj_clsSaleDetail.SaveData();

                    obj_clsMenu.MENUID = Convert.ToInt32(DTSale.Rows[i]["MenuID"].ToString());
                    obj_clsMenu.QTY = Convert.ToInt32(DTSale.Rows[i]["SaleQty"].ToString());
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
    }
}

