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
using System.Globalization;
using System.Data.SqlClient;
using DTO;
using BLL;
using QuanLyKhachSan.Views;
using DevExpress.XtraReports.UI;
namespace QuanLyKhachSan
{
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        List<KhachHang_DTO> lstKhachHangDTO = new List<KhachHang_DTO>();
        DataTable table = new DataTable();
        int pos = 0;
        private void frmThemKhachHang_Load(object sender, EventArgs e)
        {           
            var lstCountries = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(p => new RegionInfo(p.Name).EnglishName).Distinct().OrderBy(s => s).ToList();

            cmbQuocTich.DataSource = lstCountries;

            HienThiDuLieuKhachHang(pos);


        }

        private void HienThiDuLieuKhachHang(int pos)
        {
            lstKhachHangDTO = KhachHang_BLL.LoadKhachHang(pos);
            dgvKhachHang.DataSource = lstKhachHangDTO;
            dgvKhachHang.Columns[8].Visible = false;
            dgvKhachHang.Columns[9].Visible = false;
            dgvKhachHang.Columns[10].Visible = false;

        }

  

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }


        private void btnLuuKH_Click(object sender, EventArgs e)
        {          
            string errorS = "" ;
            try
            {
                KhachHang_DTO khDTO = new KhachHang_DTO();
                if (txtMaKH.Text.Trim() != "")
                {
                    if (KhachHang_BLL.KiemTraMa(txtMaKH.Text) == 1)
                    {
                        //Mã khách hàng đã bị trùng. Xin kiểm tra lại mã khách hàng
                        errorS += "The customer code is duplicated. Please re-check the customer code!!\n";
                    }
                    else
                    {
                        khDTO.MaKhachHang = txtMaKH.Text;
                    }

                }
                else
                {
                    //Chưa nhập thông tin cho khách hàng. Hãy nhập thông tin để tiếp tục
                    errorS += "Customer information has not been entered. Please enter the information to continue!!\n";

                }
                if (txtTenKH.Text.Trim() != "")
                {
                    khDTO.TenKhachHang = txtTenKH.Text;
                }
                else
                {
                    //Chưa nhập tên khách hàng. Hãy nhập thông tin để tiếp tục
                    errorS += "The customer name has not been entered. Please enter the information to continue!!\n";
                }

                
                if(dtpNgaySinh.Text.Trim() !="")
                {
                    khDTO.NgaySinh = Convert.ToDateTime(dtpNgaySinh.Text.ToString());
                }
                else
                {
                    //Chưa nhập ngày sinh của khách hàng. Hãy nhập thông tin để tiếp tục
                    errorS += "The customer's date of birth has not been entered. Please enter the information to continue.!!\n";
                }
               


                if (rdbNam.Checked)
                {
                    khDTO.GioiTinh = "Nam";
                }
                else khDTO.GioiTinh = "Nữ";

                if (txtCMND.Text.Trim() != "")
                {

                    if (IsNumber(txtCMND.Text) == true)
                    {
                        khDTO.CMND = txtCMND.Text;
                    }
                    else
                    {

                        errorS += "'"+txtCMND.Text + "' Invalid. The data must be numeric!!!\n";//không hợp lệ. Dữ liệu phải là số

                    }
                }
                else
                {

                    errorS += "The customer's ID card number has not been entered. Please enter the ID card number to continue!!\n";//Chưa nhập CMND của khách hàng. Hãy nhập CMND để tiếp tục

                }

                if(txtDiaChi.Text.Trim() != "")
                {
                    khDTO.DiaChi = txtDiaChi.Text;
                }
                else
                {
                    errorS += "Customer address not entered. Please enter an address to proceed!!\n";//Chưa nhập địa chỉ của khách hàng. Hãy nhập địa chỉ để tiếp tục
                }

                if (txtDienThoai.Text.Trim() != "")
                {

                    if (IsNumber(txtCMND.Text) == true)
                    {
                        khDTO.SDT = txtDienThoai.Text;
                    }
                    else
                    {

                        errorS += "'"+txtDienThoai.Text+ "' Invalid. The data must be numeric!!!\n";

                    }
                }
                else
                {

                    errorS += "Customer phone number not entered. Please enter a phone number to proceed!!\n";//Chưa nhập số điện thoại của khách hàng. Hãy nhập số điện thoại để tiếp tục

                }

                if (errorS != "")
                {
                    MessageBox.Show(errorS, "Error notification");
                    return;
                }


                khDTO.QuocTich = cmbQuocTich.Text;

                int check = KhachHang_BLL.ThemKhachHang(khDTO);

                if (check > 0)
                {
                    btnLuuKH.Enabled = true;
                    HienThiDuLieuKhachHang(pos);
                    XtraMessageBox.Show("Save successful!", "Notifycation");



                }
                else
                {
                    XtraMessageBox.Show("Save failed!", "Notifycation");
                    return;
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error : " + ex.Message);
            }
            

        }

        private void btnHuyKH_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            btnSuaKH.Enabled = false;
            KhachHang_DTO khDTO = new KhachHang_DTO();
            try
            {
                
                khDTO.MaKhachHang = txtMaKH.Text;
                khDTO.TenKhachHang = txtTenKH.Text;
                khDTO.NgaySinh = Convert.ToDateTime(dtpNgaySinh.Text);
                if (rdbNam.Checked)
                {
                    khDTO.GioiTinh = "Nam";
                }
                else khDTO.GioiTinh = "Nữ";

                khDTO.CMND = txtCMND.Text;
                khDTO.DiaChi = txtDiaChi.Text;
                khDTO.SDT = txtDienThoai.Text;
                khDTO.QuocTich = cmbQuocTich.Text;
                
                try
                {
                    int check = KhachHang_BLL.SuaKhachHang(khDTO);
                    
                                
                    if (check > 0)
                    {
                        KhachHang_DTO khDTOUpdate = lstKhachHangDTO.Single(n => n.MaKhachHang == khDTO.MaKhachHang);
                        khDTOUpdate.TenKhachHang = khDTO.TenKhachHang;
                        khDTOUpdate.NgaySinh = khDTO.NgaySinh;
                        khDTOUpdate.GioiTinh = khDTO.GioiTinh;
                        khDTOUpdate.CMND = khDTO.CMND;
                        khDTOUpdate.DiaChi = khDTO.DiaChi;
                        khDTOUpdate.SDT = khDTO.CMND;
                        khDTOUpdate.QuocTich = khDTO.QuocTich;
                        HienThiDuLieuKhachHang(pos);
                        XtraMessageBox.Show("Update successful", "Notifycation");

                    }
                    else
                    {
                        XtraMessageBox.Show("Update failed!", "Notifycation");
                        return;
                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show("Error : " + ex.Message);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error : " + ex.Message);
            }
            
            

        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {

            btnXoaKH.Enabled = false;
            string maKH = txtMaKH.Text;
            if(maKH == "")
            {
                XtraMessageBox.Show("No data selected for deletion", "Notifycation");//Chưa chọn dữ liệu để xóa
            }
            if(KhachHang_BLL.XoaKhachHang(maKH) == 1)
            {


                DialogResult dr = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if(dr == DialogResult.Yes)
                {
                    KhachHang_DTO khDTODelete = lstKhachHangDTO.Single(n => n.MaKhachHang == maKH);
                    lstKhachHangDTO.Remove(khDTODelete);
                    HienThiDuLieuKhachHang(pos);
                    XtraMessageBox.Show("Delete successful", "Notifycation");
                }              
   
            }
            else
            {
                XtraMessageBox.Show("Delete failed", "Notifycation");
            }   

        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKhachHang.SelectedRows != null)
                {
                    btnSuaKH.Enabled = true;
                    btnXoaKH.Enabled = true;
                    DataGridViewRow _row = dgvKhachHang.SelectedRows[0];
                    txtMaKH.Text = _row.Cells["MaKH"].Value.ToString();
                    txtTenKH.Text = _row.Cells["TenKH"].Value.ToString();
                    dtpNgaySinh.Text = Convert.ToDateTime(_row.Cells["NgaySinh"].Value.ToString()).ToShortDateString();
                    if (_row.Cells["GioiTinh"].Value.ToString() == "Nam")
                    {
                        rdbNam.Checked = true;
                    }
                    else rdbNu.Checked = true;


                    txtCMND.Text = _row.Cells["CMND"].Value.ToString();
                    txtDiaChi.Text = _row.Cells["DiaChi"].Value.ToString();
                    txtDienThoai.Text = _row.Cells["SDT"].Value.ToString();
                    cmbQuocTich.Text = _row.Cells["QuocTich"].Value.ToString();
                }
            }
            catch (Exception)
            {

                return;
            }
            

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(pos < dgvKhachHang.RowCount)
            {
                if(pos!=dgvKhachHang.RowCount-1)
                {
                    dgvKhachHang.Rows[pos].Selected = false;
                    dgvKhachHang.Rows[++pos].Selected = true;
                }
                else
                {
                    MessageBox.Show("End");
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(pos>=0)
            {
                if(pos!=0)
                {
                    dgvKhachHang.Rows[pos].Selected = false;
                    dgvKhachHang.Rows[--pos].Selected = true;
                }
                else
                {
                    MessageBox.Show("End");
                }
            }
            
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            dgvKhachHang.Rows[pos].Selected = true;
           
        }

        private void btnLast_Click(object sender, EventArgs e)
        {

            pos = dgvKhachHang.Rows.Count - 1;
            dgvKhachHang.Rows[pos].Selected = true;

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            dtpNgaySinh.Text = "";
            txtDienThoai.Text = "";
            cmbQuocTich.Text = "";
        }

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpNgaySinh.Text = cmbQuocTich.Text = txtCMND.Text = txtDiaChi.Text = txtDienThoai.Text = txtMaKH.Text = txtTenKH.Text = "";
            dgvKhachHang.ClearSelection();      
        }
    }
}