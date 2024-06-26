﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DTO;
using BLL;
namespace QuanLyKhachSan.Views
{
    public partial class frmDichVu : DevExpress.XtraEditors.XtraForm
    {
        public frmDichVu()
        {
            InitializeComponent();
        }
        public static string MaDichVu;
        public static string MaPhong;
        List<LoaiPhong_DTO> lstTenLoaiPhong = new List<LoaiPhong_DTO>();
        List<LoaiDichVu_DTO> lstLoaiDichVu = new List<LoaiDichVu_DTO>();
        List<KhachHang_DTO> lstKhachHang = new List<KhachHang_DTO>();


        private void frmDichVu_Load(object sender, EventArgs e)
        {
            HienThiDanhSachCacKHDaCoPhong();
            HienThiTenLoaiDichVuLenComboBox();
            HienThiDanhSachPhongDaDangKyDichVu();
            HienThiTenLoaiDichVuLenComboBox_TTDV();
            HienThiTenLoaiPhongLenComboBox();
            
        }

        private void HienThiDanhSachCacKHDaCoPhong()
        {
            lstKhachHang = KhachHang_BLL.HienThiDanhSachCacKhachHangDaCoPhong_KH();
            dgvCacKhachHangDaCP.DataSource = lstKhachHang;

        }

        private void HienThiTenLoaiPhongLenComboBox()
        {
            lstTenLoaiPhong = LoaiPhong_BLL.HienThiTenLoaiPhongTheoMaLoaiPhong();
            cmbTenLoaiPhong_TTDV.DataSource = lstTenLoaiPhong;
            cmbTenLoaiPhong_TTDV.DisplayMember = "TenLoaiPhong";
            cmbTenLoaiPhong_TTDV.ValueMember = "MaLoaiPhong";
        }


        private void HienThiDanhSachPhongDaDangKyDichVu()
        {

            if (cmbTenLoaiPhong_TTDV.SelectedItem == null)
            {
                return;
            }
            if (cmbTenPhong_TTDV.SelectedItem == null)
            {
                return;
            }

            Phong_DTO maPhong = (Phong_DTO)cmbTenPhong_TTDV.SelectedItem;
            dgvThongTinPhongDaDatDV.DataSource = DichVu_BLL.HienThiThongTinPhongDaDangKyDichVu(maPhong);
            //dgvThongTinPhongDaDatDV.Columns["TongTienn"].DefaultCellStyle.Format = "{0:0,0 VND}";
        }

        private void HienThiTenLoaiDichVuLenComboBox()
        {
            lstLoaiDichVu = LoaiDichVu_BLL.HienThiTenLoaiDichVuLenComboBox();
            cmbTenLoaiDichVu.DataSource = lstLoaiDichVu;
            cmbTenLoaiDichVu.DisplayMember = "TenLoaiDichVu";
            cmbTenLoaiDichVu.ValueMember = "MaLoaiDichVu";
        }

        private void HienThiTenLoaiDichVuLenComboBox_TTDV()
        {
            lstLoaiDichVu = LoaiDichVu_BLL.HienThiTenLoaiDichVuLenComboBox();
            cmbLoaiDichVu_TTDV.DataSource = lstLoaiDichVu;
            cmbLoaiDichVu_TTDV.DisplayMember = "TenLoaiDichVu";
            cmbLoaiDichVu_TTDV.ValueMember = "MaLoaiDichVu";
        }


        private void dgvDichVu_Click(object sender, EventArgs e)
        {
            
            
        }


        private void cmbTenLoaiDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenLoaiDichVu.SelectedItem == null)
            {
                return;
            }
            LoaiDichVu_DTO ldvDTO = (LoaiDichVu_DTO)cmbTenLoaiDichVu.SelectedItem;
            cmbTenDichVu.DataSource = DichVu_BLL.HienThiTenDichVuTheoMaDichVu(ldvDTO.MaLoaiDichVu);
            cmbTenDichVu.DisplayMember = "TenDichVu";
            cmbTenDichVu.ValueMember = "MaDichVu";
        }

        private void cmbTenDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenDichVu.SelectedItem == null)
            {
                return;
            }
            DichVu_DTO dvDTO = (DichVu_DTO)cmbTenDichVu.SelectedItem;
            cmbGiaDichVu.DataSource = DichVu_BLL.HienThiGiaDichVuLenComboBox(dvDTO.MaDichVu);
            cmbGiaDichVu.DisplayMember = "DonGia";
            cmbGiaDichVu.ValueMember = "MaDichVu";
        }

        private void cmbGiaDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (cmbGiaDichVu.SelectedItem == null)
            {
                return;
            }
            DichVu_DTO dvDTO = (DichVu_DTO)txtThanhTien.SelectedItem;
            txtThanhTien.DataSource = DichVu_BLL.HienThiDonViTinh(dvDTO.ThanhTien);
            cmbDonViTinh.DisplayMember = "TenDonVi";
            cmbDonViTinh.ValueMember = "MaDonVi";*/
        }

      

        private void btnXacNhanDichVu_Click(object sender, EventArgs e)
        {
            DichVu_DTO dvDTO = new DichVu_DTO();
            Phong_DTO phgDTO = new Phong_DTO();
            try
            {
                int sl = int.Parse(txtSoLuong.Text);
                if (sl <= 0)
                {
                    MessageBox.Show("Please input a number bigger than 0");
                    return;
                }
            }
            catch {
                MessageBox.Show("Please check your quantity again","Error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string errorS = "";
                if(txtMaSDDV.Text.Trim() != "")
                {
                    dvDTO.MaSuDungDichVu = txtMaSDDV.Text;
                }
                else
                {
                    errorS += "Service ID is empty.\n";
                }
                dvDTO.MaDichVu = (string)cmbTenDichVu.SelectedValue;
                
                phgDTO.MaPhong = txtMaPhong.Text;
                dvDTO.ThanhTien = int.Parse(cmbGiaDichVu.Text) * int.Parse(txtSoLuong.Text);

                if(txtSoLuong.Text.Trim() == "")
                {
                    errorS += "Chưa nhập số lượng tính\n";                                                                                                                                                                               
                }
                if (errorS != "")
                {
                    MessageBox.Show(errorS, "Thông báo lỗi");
                    return;
                }
                dvDTO.SoLuong = int.Parse(txtSoLuong.Text);
                int check = DichVu_BLL.XacNhanDichVu(dvDTO, phgDTO);
                if (check > 0)
                {
                    btnXacNhanDichVu.Visible = true;
                    dgvCacKhachHangDaCP.Visible = true;
                    HienThiDanhSachPhongDaDangKyDichVu();
                    MessageBox.Show("Xác nhận sử dụng dịch vụ thành công!", "Thông báo");
                    btnXacNhanDichVu.Enabled = false;
                    
                    
                }
                else
                {
                    MessageBox.Show("Xác nhận sử dụng dịch vụ thất bại. Xin kiểm tra lại dữ liệu!", "Thông báo");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi chương trình " + ex.Message);
            }

        }


        private void dgvThongTinPhongDaDatDV_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvThongTinPhongDaDatDV.SelectedRows != null)
                {
                    DataGridViewRow row = dgvThongTinPhongDaDatDV.SelectedRows[0];
                    cmbLoaiDichVu_TTDV.Text = row.Cells["TenLoaiDichVu"].Value.ToString();
                    cmbTenDichVu_TTDV.Text = row.Cells["TenDichVu"].Value.ToString();
                    cmbTenPhong_TTDV.Text = row.Cells["TenPhongg"].Value.ToString();
                    txtTenKH_TTDV.Text = row.Cells["TenKHH"].Value.ToString();
                    txtSoLuong_TTDV.Text = row.Cells["SoLuongTinh"].Value.ToString();
                    MaDichVu = row.Cells["MaDichVuu"].Value.ToString();
                    MaPhong = row.Cells["MaaPhong"].Value.ToString();
                    cmbTenLoaiPhong_TTDV.Text = Phong_BLL.GetTenLoaiPhong(MaPhong);
                }

            }
            catch (Exception)
            {

                return;
            }
            
        }

        private void cmbLoaiDichVu_TTDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoaiDichVu_TTDV.SelectedItem == null)
            {
                return;
            }
            LoaiDichVu_DTO ldvDTO = (LoaiDichVu_DTO)cmbLoaiDichVu_TTDV.SelectedItem;
            cmbTenDichVu_TTDV.DataSource = DichVu_BLL.HienThiTenDichVuTheoMaDichVu(ldvDTO.MaLoaiDichVu);
            cmbTenDichVu_TTDV.DisplayMember = "TenDichVu";
            cmbTenDichVu_TTDV.ValueMember = "MaDichVu";
            frmDichVu.MaDichVu = cmbTenDichVu_TTDV.SelectedValue.ToString();
        }

        private void cmbTenDichVu_TTDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenDichVu_TTDV.SelectedItem == null)
            {
                return;
            }
            DichVu_DTO dvDTO = (DichVu_DTO)cmbTenDichVu_TTDV.SelectedItem;
            cmbGiaDichVu_TTDV.DataSource = DichVu_BLL.HienThiGiaDichVuLenComboBox(dvDTO.MaDichVu);
            //cmbGiaDichVu_TTDV.DisplayMember = "TenDichVu";
            //cmbGiaDichVu_TTDV.ValueMember = "MaDichVu";
            cmbGiaDichVu_TTDV.DisplayMember = "DonGia";
            cmbGiaDichVu_TTDV.ValueMember = "MaDichVu";

        }

        private void cmbGiaDichVu_TTDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (cmbGiaDichVu_TTDV.SelectedItem == null)
            {
                return;
            }
            DichVu_DTO dvDTO = (DichVu_DTO)cmbGiaDichVu_TTDV.SelectedItem;
            cmbGiaDichVu_TTDV.DataSource = DichVu_BLL.HienThiDonViTinh(dvDTO.MaDichVu);
            cmbGiaDichVu_TTDV.DisplayMember = "DonGia";
            cmbGiaDichVu_TTDV.ValueMember = "MaDichVu";*/
        }

        private void cmbTenLoaiPhong_TTDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenLoaiPhong_TTDV.SelectedItem == null)
            {
                
                return;
            }           
            else
            {
                dgvThongTinPhongDaDatDV.Visible = true;
                LoaiPhong_DTO lpDTO = (LoaiPhong_DTO)cmbTenLoaiPhong_TTDV.SelectedItem;
                
                cmbTenPhong_TTDV.DataSource = Phong_BLL.HienThiTenPhongTheoMaLoaiPhong_CoNguoi(lpDTO.MaLoaiPhong);
                cmbTenPhong_TTDV.DisplayMember = "TenPhong";
                cmbTenPhong_TTDV.ValueMember = "MaPhong";
                frmDichVu.MaPhong = cmbTenPhong_TTDV.SelectedValue.ToString();
            }
           
            if (cmbTenPhong_TTDV.Items.Count == 0)
            {
                cmbTenPhong_TTDV.Text = "Chưa có phòng";
                cmbTenPhong_TTDV.Enabled = false;
                btnCapNhatDichVu.Enabled = false;
                dgvThongTinPhongDaDatDV.Visible = false;
                return;
            }
            else
            {
                dgvThongTinPhongDaDatDV.Visible = true;
                btnCapNhatDichVu.Enabled = true;
                cmbTenPhong_TTDV.Enabled = true;
                

            }
        }

        private void cmbTenPhong_TTDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenLoaiPhong_TTDV.SelectedItem == null)
            {   
                return;
            }
            if (cmbTenPhong_TTDV.SelectedItem == null)
            {
                return;
            }
            Phong_DTO maPhong = (Phong_DTO)cmbTenPhong_TTDV.SelectedItem;

            dgvThongTinPhongDaDatDV.Visible = true;
            dgvThongTinPhongDaDatDV.DataSource = DichVu_BLL.HienThiThongTinPhongDaDangKyDichVu(maPhong);


            

        }

        private void btnCapNhatDichVu_Click(object sender, EventArgs e)
        {

            if (cmbTenPhong_TTDV.Items.Count == 0)
            {
                cmbTenPhong_TTDV.Text = "Chưa có phòng";
                cmbTenPhong_TTDV.Enabled = false;
                return;
            }
            else
            {
                cmbTenPhong_TTDV.Enabled = true;
                frmCapNhatDichVu frmCNDV = new frmCapNhatDichVu();
                frmCNDV.ShowDialog();
                HienThiDanhSachPhongDaDangKyDichVu();
            }
            
            
        }


        private void dgvCacKhachHangDaCP_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCacKhachHangDaCP.SelectedRows != null)
                {
                    btnXacNhanDichVu.Enabled = true;
                    DataGridViewRow row = dgvCacKhachHangDaCP.SelectedRows[0];

                    txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                    txtMaPhong.Text = row.Cells["MaPhong"].Value.ToString();


                }
            }
            catch (Exception)
            {

                return;
            }
            
        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteServ_Click(object sender, EventArgs e)
        {
            if (dgvThongTinPhongDaDatDV.Rows.Count == 0)
            {
                XtraMessageBox.Show("There's nothing here!","Error");
                return;

            }
            DialogResult _dr = MessageBox.Show("Do you really want to delete this Service Ticket?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (_dr == DialogResult.Yes)
            {
                DichVu_BLL.XoaPhieuDichVu(MaDichVu, MaPhong);
                XtraMessageBox.Show("Service Ticket Delete Sucessful!", "Thông báo");
                HienThiDanhSachPhongDaDangKyDichVu();

            }
            else
            {
                return;
            }
        }
    }
}