namespace QuanLyKhachSan.Views
{
    partial class frmTimKiem_PDK
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgvPhieuDangKy = new System.Windows.Forms.DataGridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.MaPhieuDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongNguoiLon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongTreEm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienDatCoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuDangKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgvPhieuDangKy);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 123);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1322, 238);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "List of registration vouchers";
            // 
            // dgvPhieuDangKy
            // 
            this.dgvPhieuDangKy.AllowUserToAddRows = false;
            this.dgvPhieuDangKy.AllowUserToDeleteRows = false;
            this.dgvPhieuDangKy.AllowUserToResizeColumns = false;
            this.dgvPhieuDangKy.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvPhieuDangKy.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhieuDangKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuDangKy.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPhieuDangKy.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvPhieuDangKy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPhieuDangKy.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPhieuDangKy.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuDangKy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhieuDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuDangKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieuDK,
            this.NgayDen,
            this.NgayDi,
            this.GioDen,
            this.GioDi,
            this.SoLuongNguoiLon,
            this.SoLuongTreEm,
            this.TienDatCoc,
            this.MaNV,
            this.MaKH});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhieuDangKy.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhieuDangKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuDangKy.EnableHeadersVisualStyles = false;
            this.dgvPhieuDangKy.Location = new System.Drawing.Point(2, 28);
            this.dgvPhieuDangKy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPhieuDangKy.MultiSelect = false;
            this.dgvPhieuDangKy.Name = "dgvPhieuDangKy";
            this.dgvPhieuDangKy.ReadOnly = true;
            this.dgvPhieuDangKy.RowHeadersVisible = false;
            this.dgvPhieuDangKy.RowHeadersWidth = 51;
            this.dgvPhieuDangKy.RowTemplate.Height = 25;
            this.dgvPhieuDangKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuDangKy.Size = new System.Drawing.Size(1318, 208);
            this.dgvPhieuDangKy.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnIn);
            this.groupControl1.Controls.Add(this.btnTimKiem);
            this.groupControl1.Controls.Add(this.txtTuKhoa);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.cmbTimTheo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1322, 123);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Search";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(1013, 57);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(119, 31);
            this.btnIn.TabIndex = 7;
            this.btnIn.Text = "Print";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.Location = new System.Drawing.Point(869, 55);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(114, 31);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Search";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuKhoa.Location = new System.Drawing.Point(468, 57);
            this.txtTuKhoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(360, 29);
            this.txtTuKhoa.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(37, 60);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 21);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Search by : ";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.CausesValidation = false;
            this.cmbTimTheo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "Mã Phiếu Đăng Ký"});
            this.cmbTimTheo.Location = new System.Drawing.Point(127, 55);
            this.cmbTimTheo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(201, 29);
            this.cmbTimTheo.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(380, 60);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 21);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Keyword : ";
            // 
            // MaPhieuDK
            // 
            this.MaPhieuDK.DataPropertyName = "MaPhieuDK";
            this.MaPhieuDK.HeaderText = "Registration voucher ID";
            this.MaPhieuDK.MinimumWidth = 6;
            this.MaPhieuDK.Name = "MaPhieuDK";
            this.MaPhieuDK.ReadOnly = true;
            // 
            // NgayDen
            // 
            this.NgayDen.DataPropertyName = "NgayDen";
            this.NgayDen.HeaderText = "Checkin date";
            this.NgayDen.MinimumWidth = 6;
            this.NgayDen.Name = "NgayDen";
            this.NgayDen.ReadOnly = true;
            // 
            // NgayDi
            // 
            this.NgayDi.DataPropertyName = "NgayDi";
            this.NgayDi.HeaderText = "checkout date";
            this.NgayDi.MinimumWidth = 6;
            this.NgayDi.Name = "NgayDi";
            this.NgayDi.ReadOnly = true;
            // 
            // GioDen
            // 
            this.GioDen.DataPropertyName = "GioDen";
            this.GioDen.HeaderText = "checkin time";
            this.GioDen.MinimumWidth = 6;
            this.GioDen.Name = "GioDen";
            this.GioDen.ReadOnly = true;
            // 
            // GioDi
            // 
            this.GioDi.DataPropertyName = "GioDi";
            this.GioDi.HeaderText = "checkout time";
            this.GioDi.MinimumWidth = 6;
            this.GioDi.Name = "GioDi";
            this.GioDi.ReadOnly = true;
            // 
            // SoLuongNguoiLon
            // 
            this.SoLuongNguoiLon.DataPropertyName = "SoLuongNguoiLon";
            this.SoLuongNguoiLon.HeaderText = "Number of adults";
            this.SoLuongNguoiLon.MinimumWidth = 6;
            this.SoLuongNguoiLon.Name = "SoLuongNguoiLon";
            this.SoLuongNguoiLon.ReadOnly = true;
            // 
            // SoLuongTreEm
            // 
            this.SoLuongTreEm.DataPropertyName = "SoLuongTreEm";
            this.SoLuongTreEm.HeaderText = "Number of children";
            this.SoLuongTreEm.MinimumWidth = 6;
            this.SoLuongTreEm.Name = "SoLuongTreEm";
            this.SoLuongTreEm.ReadOnly = true;
            // 
            // TienDatCoc
            // 
            this.TienDatCoc.DataPropertyName = "TienDatCoc";
            this.TienDatCoc.HeaderText = "Deposit price";
            this.TienDatCoc.MinimumWidth = 6;
            this.TienDatCoc.Name = "TienDatCoc";
            this.TienDatCoc.ReadOnly = true;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Employee ID";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "Customer ID";
            this.MaKH.MinimumWidth = 6;
            this.MaKH.Name = "MaKH";
            this.MaKH.ReadOnly = true;
            // 
            // frmTimKiem_PDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 361);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTimKiem_PDK";
            this.Text = "SEARCH REGISTRATION VOUCHER";
            this.Load += new System.EventHandler(this.frmTimKiem_PDK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuDangKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.DataGridView dgvPhieuDangKy;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongNguoiLon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongTreEm;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienDatCoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
    }
}