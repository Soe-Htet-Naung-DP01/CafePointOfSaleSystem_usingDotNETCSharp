namespace Cafe.MasterData
{
    partial class OrderVoucher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderVoucher));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvOrderList = new System.Windows.Forms.DataGridView();
            this.cboDeliveryManName = new System.Windows.Forms.ComboBox();
            this.cboCustomerName = new System.Windows.Forms.ComboBox();
            this.lblCustomerAdd = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblOrderVoucherID = new System.Windows.Forms.Label();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.lblOrderTax = new System.Windows.Forms.Label();
            this.lblOrderGrandTotal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDeliveryFees = new System.Windows.Forms.TextBox();
            this.txtOrderPayment = new System.Windows.Forms.TextBox();
            this.lblOrderRefund = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboStaffName = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CustomerName :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "CustomerPhone :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Customer Address :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "DeliveryMan :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "OrderItemList";
            // 
            // dgvOrderList
            // 
            this.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderList.Location = new System.Drawing.Point(0, 225);
            this.dgvOrderList.Name = "dgvOrderList";
            this.dgvOrderList.Size = new System.Drawing.Size(822, 220);
            this.dgvOrderList.TabIndex = 1;
            this.dgvOrderList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderList_CellEnter);
            this.dgvOrderList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvOrderList_EditingControlShowing);
            // 
            // cboDeliveryManName
            // 
            this.cboDeliveryManName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeliveryManName.FormattingEnabled = true;
            this.cboDeliveryManName.Location = new System.Drawing.Point(114, 163);
            this.cboDeliveryManName.Name = "cboDeliveryManName";
            this.cboDeliveryManName.Size = new System.Drawing.Size(143, 21);
            this.cboDeliveryManName.TabIndex = 2;
            // 
            // cboCustomerName
            // 
            this.cboCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerName.FormattingEnabled = true;
            this.cboCustomerName.Location = new System.Drawing.Point(114, 53);
            this.cboCustomerName.Name = "cboCustomerName";
            this.cboCustomerName.Size = new System.Drawing.Size(143, 21);
            this.cboCustomerName.TabIndex = 2;
            // 
            // lblCustomerAdd
            // 
            this.lblCustomerAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerAdd.Location = new System.Drawing.Point(115, 90);
            this.lblCustomerAdd.Name = "lblCustomerAdd";
            this.lblCustomerAdd.Size = new System.Drawing.Size(142, 23);
            this.lblCustomerAdd.TabIndex = 3;
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerPhone.Location = new System.Drawing.Point(114, 128);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(142, 23);
            this.lblCustomerPhone.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "OrderVoucherID :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Total Amount :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Tax :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(282, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Grand Total :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(552, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "OrderPayment :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(562, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Refund :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(280, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Order DATE :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(378, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblOrderVoucherID
            // 
            this.lblOrderVoucherID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderVoucherID.Location = new System.Drawing.Point(378, 53);
            this.lblOrderVoucherID.Name = "lblOrderVoucherID";
            this.lblOrderVoucherID.Size = new System.Drawing.Size(142, 23);
            this.lblOrderVoucherID.TabIndex = 6;
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderTotal.Location = new System.Drawing.Point(378, 91);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(142, 23);
            this.lblOrderTotal.TabIndex = 6;
            // 
            // lblOrderTax
            // 
            this.lblOrderTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderTax.Location = new System.Drawing.Point(378, 129);
            this.lblOrderTax.Name = "lblOrderTax";
            this.lblOrderTax.Size = new System.Drawing.Size(142, 23);
            this.lblOrderTax.TabIndex = 6;
            // 
            // lblOrderGrandTotal
            // 
            this.lblOrderGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderGrandTotal.Location = new System.Drawing.Point(378, 197);
            this.lblOrderGrandTotal.Name = "lblOrderGrandTotal";
            this.lblOrderGrandTotal.Size = new System.Drawing.Size(142, 23);
            this.lblOrderGrandTotal.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(282, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Delivery Fees :";
            // 
            // txtDeliveryFees
            // 
            this.txtDeliveryFees.Location = new System.Drawing.Point(378, 164);
            this.txtDeliveryFees.Name = "txtDeliveryFees";
            this.txtDeliveryFees.Size = new System.Drawing.Size(142, 20);
            this.txtDeliveryFees.TabIndex = 8;
            // 
            // txtOrderPayment
            // 
            this.txtOrderPayment.Location = new System.Drawing.Point(638, 19);
            this.txtOrderPayment.Name = "txtOrderPayment";
            this.txtOrderPayment.Size = new System.Drawing.Size(142, 20);
            this.txtOrderPayment.TabIndex = 8;
            this.txtOrderPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderPayment_KeyPress);
            // 
            // lblOrderRefund
            // 
            this.lblOrderRefund.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderRefund.Location = new System.Drawing.Point(638, 57);
            this.lblOrderRefund.Name = "lblOrderRefund";
            this.lblOrderRefund.Size = new System.Drawing.Size(142, 23);
            this.lblOrderRefund.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(538, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(647, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Phone : 0961451545";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(647, 123);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 61);
            this.label15.TabIndex = 10;
            this.label15.Text = "Address : MyayNiGone, YANGON";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "StaffName :";
            // 
            // cboStaffName
            // 
            this.cboStaffName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStaffName.FormattingEnabled = true;
            this.cboStaffName.Location = new System.Drawing.Point(115, 19);
            this.cboStaffName.Name = "cboStaffName";
            this.cboStaffName.Size = new System.Drawing.Size(143, 21);
            this.cboStaffName.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(538, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Location = new System.Drawing.Point(638, 192);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(75, 23);
            this.btnPayment.TabIndex = 12;
            this.btnPayment.Text = "&Payment";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(734, 193);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(706, 161);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(103, 23);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "&New Voucher";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // OrderVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(821, 445);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtOrderPayment);
            this.Controls.Add(this.txtDeliveryFees);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblOrderRefund);
            this.Controls.Add(this.lblOrderGrandTotal);
            this.Controls.Add(this.lblOrderTax);
            this.Controls.Add(this.lblOrderTotal);
            this.Controls.Add(this.lblOrderVoucherID);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCustomerPhone);
            this.Controls.Add(this.lblCustomerAdd);
            this.Controls.Add(this.cboStaffName);
            this.Controls.Add(this.cboCustomerName);
            this.Controls.Add(this.cboDeliveryManName);
            this.Controls.Add(this.dgvOrderList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OrderVoucher";
            this.Text = "OrderVoucher";
            this.Load += new System.EventHandler(this.OrderVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvOrderList;
        private System.Windows.Forms.ComboBox cboDeliveryManName;
        private System.Windows.Forms.ComboBox cboCustomerName;
        private System.Windows.Forms.Label lblCustomerAdd;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblOrderVoucherID;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.Label lblOrderTax;
        private System.Windows.Forms.Label lblOrderGrandTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDeliveryFees;
        private System.Windows.Forms.TextBox txtOrderPayment;
        private System.Windows.Forms.Label lblOrderRefund;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboStaffName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNew;
    }
}