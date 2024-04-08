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
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace QuanLyKhachSan.Views
{
    public partial class frmHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public static string MaPhong;
        public static string MaPhieuDK;
        public static int ThanhTien;
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            HienThiDanhSachCacKhachHangDaCoPhong_KH();
            HienThiDanhSachChiTietHoaDon("");
            HienThiDanhSachCacHoaDon();
            txtMaNV.Text = frmMain.MaNV;
        }
        private void HienThiDanhSachCacKhachHangDaCoPhong_KH()
        {
            dgvDanhSachKH.DataSource = KhachHang_BLL.HienThiDanhSachCacKhachHangDaCoPhong_KH();
        }

        private void HienThiDanhSachCacHoaDon()
        {
            dgvXuLyHD.DataSource = HoaDon_BLL.HienThiDanhSachHoaDon();
        }


        private void HienThiDanhSachChiTietHoaDon(string MaPhong)
        {
            if (string.IsNullOrEmpty(MaPhong))
                return;
            dgvHoaDon.DataSource = HoaDon_BLL.HienThiDanhSachChiTietHoaDon(MaPhong);
            //dgvHoaDon.Columns[6].Visible = false;
        }   
       
        private void dgvDanhSachKH_Click(object sender, EventArgs e)
        {
            try
            {
                btnThemHoaDon.Enabled = false;
                if (dgvDanhSachKH.SelectedRows != null)
                {
                    btnThemHoaDon.Enabled = true;
                    DataGridViewRow row = dgvDanhSachKH.SelectedRows[0];
                    MaPhong = row.Cells["MaPhonggg"].Value.ToString();
                    MaPhieuDK = row.Cells["MaPhieuDKK"].Value.ToString();
                    float tienCoc = float.Parse(PhieuDangKy_BLL.TienCoc(MaPhong));
                    txtSoTienDatTruoc.Text = tienCoc.ToString("##,#");
                    //thanhtien = Tong DV + Tien Phong 
                    ThanhTien = Phong_BLL.ThanhTien(MaPhong);
                    HienThiDanhSachChiTietHoaDon(MaPhong) ;


                }
            }
            catch (Exception)
            {

                return;
            }
            
        }

       
     


        private void dgvHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            //Tạo một hóa đơn mới và lưu vào cơ sở dữ liệu

            //Cập nhật mã hóa đơn vào các phiếu dịch vụ
            //Cập nhật tình trạng phòng

        }

        private void btnXacNhanHD_Click(object sender, EventArgs e)
        {
            HoaDon_DTO hdDTO = new HoaDon_DTO();

            try
            {
                hdDTO.MaHoaDon = txtMaHoaDon.Text;
                hdDTO.NgayBatDau = PhieuDangKy_BLL.NgayDen(MaPhieuDK);
                hdDTO.NgayKetThuc = Convert.ToDateTime(dtpNgayThanhToan.Text);
                hdDTO.TienCoc = int.Parse(txtSoTienDatTruoc.Text.Replace(",", string.Empty));
                hdDTO.TongTienHoaDon = ThanhTien - hdDTO.TienCoc;
                hdDTO.MaNV = txtMaNV.Text;
                hdDTO.MaPhong = MaPhong;
                hdDTO.MaPhieuDK = MaPhieuDK;
                hdDTO.ChiPhiPhatSinh = HoaDon_BLL.LayTienDichVu(MaPhong);
                int check = HoaDon_BLL.XacNhanHoaDon(hdDTO);
                if (check > 0)
                {
                   
                    XtraMessageBox.Show("Xác nhận thanh toán thành công!!!", "Thông báo");
                    HienThiDanhSachChiTietHoaDon("");
                    HienThiDanhSachCacHoaDon();
                }
                else
                {
                    XtraMessageBox.Show("Xác nhận thanh toán thất bại!!", "Thông báo");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"SERVER = .; integrated security=True; DATABASE = QuanLyKhachSan");
            conn.Open();
            string sql = "select * from HoaDon";
            SqlCommand command = new SqlCommand(sql, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet ds = new DataSet("tbHoaDon");
            adapter.Fill(ds, "tbHoaDon");
            conn.Close();

            rpHoaDon rp = new rpHoaDon();
            rp.DataSource = ds;
            rp.DataMember = ds.Tables["tbHoaDon"].TableName;
            rp.ShowPreview();
        }

        

        
    }
}