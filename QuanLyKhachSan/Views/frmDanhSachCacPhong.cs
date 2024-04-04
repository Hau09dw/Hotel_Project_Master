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
    public partial class frmDanhSachCacPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachCacPhong()
        {
            InitializeComponent();
        }
        List<Phong_DTO> lstPhong = new List<Phong_DTO>();
        

        private void frmDanhSachCacPhong_Load(object sender, EventArgs e)
        {
            lstPhong = Phong_BLL.HienThiDanhSachCacPhong();
            dgvDanhSachCacPhong.DataSource = lstPhong;
            
            dgvDanhSachCacPhong.Columns[5].Visible = false;
            dgvDanhSachCacPhong.Columns[6].Visible = false;
            //change collumn name

            dgvDanhSachCacPhong.Columns[0].HeaderText = "Mã Phòng";
            dgvDanhSachCacPhong.Columns[1].HeaderText = "Tên Phòng";
            dgvDanhSachCacPhong.Columns[2].HeaderText = "Tình Trạng";
            dgvDanhSachCacPhong.Columns[3].HeaderText = "Mã Loại";
            dgvDanhSachCacPhong.Columns[4].HeaderText = "Loại Phòng";
            
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"SERVER = .; integrated security=True; DATABASE = QuanLyKhachSan");
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Phong", conn);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet ds = new DataSet("tbPhong");
            adapter.Fill(ds, "tbPhong");
            conn.Close();

            rpPhong rp = new rpPhong();
            rp.DataSource = ds;
            rp.DataMember = ds.Tables["tbPhong"].TableName;
            rp.ShowPreview();
        }

        private void dgvDanhSachCacPhong_Click(object sender, EventArgs e)
        {
            
        }
    }
}