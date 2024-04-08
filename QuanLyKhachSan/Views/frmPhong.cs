using System;
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
    public partial class frmPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmPhong()
        {
            InitializeComponent();
        }

        List<Phong_DTO> lstTenPhong = new List<Phong_DTO>();
        List<LoaiPhong_DTO> lstTenLoaiPhong = new List<LoaiPhong_DTO>();
        List<DichVu_DTO> lstTenDichVu = new List<DichVu_DTO>();
        List<LoaiDichVu_DTO> lstLoaiDichVu = new List<LoaiDichVu_DTO>();
        List<PhieuDangKy_DTO> lstPhieuDangKy;
        List<KhachHang_DTO> lstKhachHangDaCoPhong = new List<KhachHang_DTO>();
        private void frmPhong_Load(object sender, EventArgs e)
        {
            HienThiTenLoaiPhongLenComboBox();
            HienThiDuLieuPhieuDangKyDangCho();
            HienThiTenLoaiPhongLenComboBox_TTDP();
            HienThiDSKhachHangDaCoPhong();

        }


        private void HienThiTenLoaiPhongLenComboBox()
        {
            lstTenLoaiPhong = LoaiPhong_BLL.HienThiTenLoaiPhongTheoMaLoaiPhong();
            cmbTenLoaiPhong.DataSource = lstTenLoaiPhong;
            cmbTenLoaiPhong.DisplayMember = "TenLoaiPhong";
            cmbTenLoaiPhong.ValueMember = "MaLoaiPhong";
        }

        private void HienThiTenLoaiPhongLenComboBox_TTDP()
        {
            lstTenLoaiPhong = LoaiPhong_BLL.HienThiTenLoaiPhongTheoMaLoaiPhong();
            cmbTenLoaiPhong_TTDP.DataSource = lstTenLoaiPhong;
            cmbTenLoaiPhong_TTDP.DisplayMember = "TenLoaiPhong";
            cmbTenLoaiPhong_TTDP.ValueMember = "MaLoaiPhong";
        }

        private void HienThiDSKhachHangDaCoPhong()
        {
            lstKhachHangDaCoPhong = KhachHang_BLL.HienThiDanhSachCacKhachHangDaCoPhong_KH();
            dgvThongTinDatPhong.DataSource = lstKhachHangDaCoPhong;
            dgvThongTinDatPhong.Columns[0].Visible = false;
            dgvThongTinDatPhong.Columns[2].Visible = false;
        }

        //Hiển thị dữ liệu phiếu đăng ký đang chờ
        private void HienThiDuLieuPhieuDangKyDangCho()
        {
            lstPhieuDangKy = PhieuDangKy_BLL.HienThiDuLieuPDKDangCho();
            dgvPhong.DataSource = lstPhieuDangKy;
            dgvPhong.Columns[2].Visible = false;
            dgvPhong.Columns[3].Visible = false;
            dgvPhong.Columns[4].Visible = false;
            dgvPhong.Columns[5].Visible = false;
            dgvPhong.Columns[6].Visible = false;
            dgvPhong.Columns[7].Visible = false;
        }       
        private void dgvPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhong.SelectedRows != null)
                {
                    DataGridViewRow row = dgvPhong.SelectedRows[0];
                    txtMaPhieuDK.Text = row.Cells["MaPhieuDK"].Value.ToString();
                }
            }
            catch (Exception)
            {

                return;
            }
          
        }
      


        private void cmbTenLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenLoaiPhong.SelectedItem == null)
            {
                return;
            }

            LoaiPhong_DTO lpDTO = (LoaiPhong_DTO)cmbTenLoaiPhong.SelectedItem;

            cmbTenPhong.DataSource = Phong_BLL.HienThiTenPhongTheoMaLoaiPhong_Trong(lpDTO.MaLoaiPhong);
            cmbTenPhong.DisplayMember = "TenPhong";
            cmbTenPhong.ValueMember = "MaPhong";
             if(cmbTenPhong.Items.Count ==0)
            {
                cmbTenPhong.Text = "No more rooms available";
                cmbTenPhong.Enabled = false;
                btnXacNhanDatPhong.Enabled = false;
                return;
            }
             else
            {
                cmbTenPhong.Enabled = true;
                btnXacNhanDatPhong.Enabled = true;

            }
        }

        private void btnXacNhanDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPhieuDK.Text == "")
                {
                    return;
                }

                if (cmbTenPhong.Items.Count == 0)
                {
                    cmbTenPhong.Text = "No more rooms available";
                    cmbTenPhong.Enabled = false;
                    return;
                }
                else
                {
                    cmbTenPhong.Enabled = true;
                    PhieuDangKy_DTO pdkDTO = new PhieuDangKy_DTO();
                    Phong_DTO phgDTO = new Phong_DTO();
                    pdkDTO.MaPhieuDK = txtMaPhieuDK.Text;
                    phgDTO.MaPhong = (string)cmbTenPhong.SelectedValue;

                    int check = Phong_BLL.XacNhanDatPhong(pdkDTO, phgDTO);
                    if (check > 0)
                    {

                        HienThiDuLieuPhieuDangKyDangCho();
                        cmbTenPhong.DataSource = Phong_BLL.HienThiTenPhongTheoMaLoaiPhong_Trong((string)cmbTenLoaiPhong.SelectedValue);

                        cmbTenPhong.DisplayMember = "TenPhong";
                        cmbTenPhong.ValueMember = "MaPhong";


                        if (cmbTenPhong.Items.Count != 0)
                        {
                            cmbTenPhong.SelectedIndex = 0;
                        }

                        if (cmbTenPhong.Items.Count == 0)
                        {
                            cmbTenPhong.Enabled = false;
                            btnXacNhanDatPhong.Enabled = false;
                            cmbTenPhong.Text = "No more rooms available";

                        }

                        MessageBox.Show("Customer has been successfully added to the room", "Notification" +
                            "");
                        txtMaPhieuDK.Text = "";
                        HienThiDSKhachHangDaCoPhong();

                    }
                    else
                    {
                        MessageBox.Show("Customer has been failed added to the room", "Notification");
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error :" + ex.Message);
            }

           
        }

        private void cmbTenLoaiPhong_TTDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenLoaiPhong_TTDP.SelectedItem == null)
            {
                return;
            }

            LoaiPhong_DTO lpDTO = (LoaiPhong_DTO)cmbTenLoaiPhong_TTDP.SelectedItem;

            cmbTenPhong_TTDP.DataSource = Phong_BLL.HienThiTenPhongTheoMaLoaiPhong_Trong(lpDTO.MaLoaiPhong);
            cmbTenPhong_TTDP.DisplayMember = "TenPhong";
            cmbTenPhong_TTDP.ValueMember = "MaPhong";
            if (cmbTenPhong_TTDP.Items.Count == 0)
            {
                cmbTenPhong_TTDP.Text = "No more rooms available";
                cmbTenPhong_TTDP.Enabled = false;
                btnThayDoiPhongChoKhach.Enabled = false;
                return;
            }
            else
            {
                cmbTenPhong_TTDP.Enabled = true;
                btnThayDoiPhongChoKhach.Enabled = true;

            }
        }

        private void dgvThongTinDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvThongTinDatPhong.SelectedRows != null)
                {
                    DataGridViewRow row = dgvThongTinDatPhong.SelectedRows[0];
                    cmbTenPhong_TTDP.Text = row.Cells["TenPhong"].Value.ToString();
                    txtMaPhieuDK_TTDP.Text = row.Cells["MaPhieuDK"].Value.ToString();
                    txtTenKH_TTDP.Text = row.Cells["TenKhachHang"].Value.ToString();
                }
            }
            catch (Exception)
            {

                return;
            }
            
        }

        private void btnThayDoiPhongChoKhach_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (cmbTenPhong_TTDP.Items.Count == 0)
                {
                    cmbTenPhong_TTDP.Text = "No more rooms available";
                    cmbTenPhong_TTDP.Enabled = false;
                    return;
                }
                else
                {
                    cmbTenPhong_TTDP.Enabled = true;
                    PhieuDangKy_DTO pdkDTO = new PhieuDangKy_DTO();
                    Phong_DTO phgDTO = new Phong_DTO();
                    pdkDTO.MaPhieuDK = txtMaPhieuDK_TTDP.Text;
                    phgDTO.MaPhong = (string)cmbTenPhong_TTDP.SelectedValue;

                    int check = Phong_BLL.ThayDoiPhongChoKhach(pdkDTO, phgDTO);

                    DialogResult _dr = MessageBox.Show("Are you sure you want to change the room for the guest?", "Notification",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                    if(_dr == DialogResult.Yes)
                    {
                        if (check > 0)
                        {

                            HienThiDSKhachHangDaCoPhong();
                            cmbTenPhong_TTDP.DataSource = Phong_BLL.HienThiTenPhongTheoMaLoaiPhong_Trong((string)cmbTenLoaiPhong_TTDP.SelectedValue);

                            cmbTenPhong_TTDP.DisplayMember = "TenPhong";
                            cmbTenPhong_TTDP.ValueMember = "MaPhong";


                            if (cmbTenPhong_TTDP.Items.Count != 0)
                            {
                                cmbTenPhong_TTDP.SelectedIndex = 0;
                            }

                            if (cmbTenPhong_TTDP.Items.Count == 0)
                            {
                                cmbTenPhong_TTDP.Enabled = false;
                                btnThayDoiPhongChoKhach.Enabled = false;
                                cmbTenPhong_TTDP.Text = "No more rooms available";

                            }

                            MessageBox.Show("Room update for the guest was successful!!!!", "Notification");

                        }
                        else
                        {
                            MessageBox.Show("Room update for the guest was failed!!! PPlease check the data again!!!", "Notification");
                        }
                    }

                   
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }

        private void btnCapNhatLaiTrangThaiPhong_Click(object sender, EventArgs e)
        {
            PhieuDangKy_DTO pdkDTO = new PhieuDangKy_DTO();
            Phong_DTO phgDTO = new Phong_DTO();
            pdkDTO.MaPhieuDK = txtMaPhieuDK_TTDP.Text;
            phgDTO.MaPhong = (string)cmbTenPhong_TTDP.SelectedValue;
            int check = Phong_BLL.CapNhatLaiTrangThaiPhong(pdkDTO, phgDTO);
            if(check>0)
            {
                HienThiDSKhachHangDaCoPhong();
                MessageBox.Show("Room has been successfully updated.!!!!", "Notification");
            }
            else
            {
                MessageBox.Show("Update failed!!!!", "Notification");
            }



        }

        private void tabPane1_Click(object sender, EventArgs e)
        {

        }

        private void dgvThongTinDatPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}