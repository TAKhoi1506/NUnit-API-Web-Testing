using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_29_Khoi
{
    public partial class Frm_29_Khoi : Form
    {
        public Frm_29_Khoi()
        {
            InitializeComponent();
        }

        private void btnResult_29_Khoi_Click(object sender, EventArgs e)
        {
            //Khởi tạo các biến lưu tọa độ của hai vector và kết quả tính toán
            int Xa_29_Khoi = 0, Ya_29_Khoi = 0, Xb_29_Khoi = 0, Yb_29_Khoi = 0;
            double resultTVH_29_Khoi, resultGoc_29_Khoi;


            //Kiểm tra dữ liệu nhập vào có bị bỏ trống hay không

            if (string.IsNullOrEmpty(tbxA_29_Khoi.Text) || string.IsNullOrEmpty(tbyA_29_Khoi.Text)
                || string.IsNullOrEmpty(tbxB_29_Khoi.Text) || string.IsNullOrEmpty(tbyB_29_Khoi.Text))
            {
                MessageBox.Show("Lỗi!Vui lòng không để trống", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Nếu lỗi thì dừng chương trình
                return;
            }


            ////Kiểm tra vector có phải (0,0) không
            //if ((Xa_29_Khoi == 0 && Ya_29_Khoi == 0) || (Xb_29_Khoi == 0 && Yb_29_Khoi == 0))
            //{
            //        MessageBox.Show("Không thể tính góc nếu một vector có đội dài bằng không", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //Khởi tạo đối tượng để tính toán dựa trên các vector
            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(Xa_29_Khoi, Ya_29_Khoi, Xb_29_Khoi, Yb_29_Khoi);

            //Tính tích vô hướng và hiển thị kết quả
            resultTVH_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();
            tbTVH_29_Khoi.Text = resultTVH_29_Khoi.ToString();

            //Tính góc giữa hai vector và hiển thị (định dạng 2 chữ số thập phân, đơn vị độ)
            resultGoc_29_Khoi = T_29_Khoi.GocGiuaHaiVectors_29_Khoi();
            tbGVH_29_Khoi.Text = resultGoc_29_Khoi.ToString("F2") + "°";
        }

        private void Frm_29_Khoi_Load(object sender, EventArgs e)
        {

        }
    }
}
