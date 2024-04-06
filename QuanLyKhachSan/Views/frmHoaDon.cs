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
            btnXacNhanHD.Enabled = false;
        }
        private void HienThiDanhSachCacKhachHangDaCoPhong_KH()
        {
            dgvDanhSachKH.DataSource = KhachHang_BLL.HienThiDanhSachCacKhachHangDaCoPhong_KH();
        }

        private void HienThiDanhSachCacHoaDon()
        {
            dgvXuLyHD.DataSource = HoaDon_BLL.HienThiDanhSachHoaDon();
            dgvXuLyHD.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvXuLyHD.Columns[1].HeaderText = "Tên Hóa Đơn";
            dgvXuLyHD.Columns[2].HeaderText = "Ngày Bắt Đầu";
            dgvXuLyHD.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy" ;
            dgvXuLyHD.Columns[3].HeaderText = "Ngày Kết Thúc";
            dgvXuLyHD.Columns[4].HeaderText = "Tiền Phòng";
            dgvXuLyHD.Columns[5].HeaderText = "Chi phí phát sinh";
            dgvXuLyHD.Columns[6].HeaderText = "Tổng tiền Hóa Đơn";
            dgvXuLyHD.Columns[7].HeaderText = "Tiền Đặt Cọc";
            dgvXuLyHD.Columns[8].HeaderText = "Mã NV";
            dgvXuLyHD.Columns[9].HeaderText = "Mã Phiếu ĐK";
            dgvXuLyHD.Columns[10].HeaderText = "Mã Phòng";
        }


        private void HienThiDanhSachChiTietHoaDon(string MaKH)
        {
            if (string.IsNullOrEmpty(MaKH))
                return;
            dgvHoaDon.DataSource = HoaDon_BLL.HienThiDanhSachChiTietHoaDon(MaKH);
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
                    string MaKH = row.Cells[0].Value.ToString().Trim();
                    HienThiDanhSachChiTietHoaDon(MaKH) ;

                }
            }
            catch (Exception)
            {

                return;
            }
            
        }

       
     


        private void dgvHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDon.SelectedRows != null)
                {
                    btnXacNhanHD.Enabled = true;
                    DataGridViewRow row = dgvHoaDon.SelectedRows[0];
                    MaPhong = row.Cells["MaPhongg"].Value.ToString();
                    ThanhTien = Convert.ToInt32(row.Cells["ThanhTienn"].Value);
                    txtMaCTHD.Text = row.Cells["MaChiTietHoaDon"].Value.ToString();
                    txtSoTienDatTruoc.Text = Convert.ToString(HoaDon_BLL.LayTienDatCoc(MaPhong));

                }
            }
            catch (Exception)
            {

                return;
            }
           
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {

            frmChiTietHoaDon frmCTHD = new frmChiTietHoaDon();
            frmCTHD.ShowDialog();
            HienThiDanhSachChiTietHoaDon("");
            HienThiDanhSachCacKhachHangDaCoPhong_KH();
            
        }

        private void btnXacNhanHD_Click(object sender, EventArgs e)
        {
            HoaDon_DTO hdDTO = new HoaDon_DTO();
            try
            {
                hdDTO.MaHoaDon = txtMaHoaDon.Text;
                hdDTO.NgayThanhToan = Convert.ToDateTime(dtpNgayThanhToan.Text);
                hdDTO.SoTienDaDatTruoc = int.Parse(txtSoTienDatTruoc.Text);
                hdDTO.TongTienHoaDon = ThanhTien - hdDTO.SoTienDaDatTruoc;
                hdDTO.MaNV = txtMaNV.Text;
                hdDTO.MaChiTietHoaDon = txtMaCTHD.Text;
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