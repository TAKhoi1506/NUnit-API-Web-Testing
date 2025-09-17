using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_29_Khoi
{
    //Chuyển đổi phạm vi truy cập từ internal -> sang public để cho phép truy cập từ các lớp khác
    public class TinhToan_29_Khoi
    {
        //Khởi tạo các biến toàn cục để lưu tọa độ của hai vector
        private double xA_29_Khoi, yA_29_Khoi;
        private double xB_29_Khoi, yB_29_Khoi;

        //Hàm khởi tạo nhận tọa độ hai vector A (xA, yA) và B (xB, yB)
        public TinhToan_29_Khoi(double xA_29_Khoi, double yA_29_Khoi, double xB_29_Khoi, double yB_29_Khoi)
        {
            this.xA_29_Khoi = xA_29_Khoi;
            this.yA_29_Khoi = yA_29_Khoi;
            this.xB_29_Khoi = xB_29_Khoi;
            this.yB_29_Khoi = yB_29_Khoi;
        }



        //Hàm tính tích vô hướng
        public double TichVoHuong_29_Khoi()
        {
            //Trả về phép tính theo công thức A·B = (xA × xB) + (yA × yB)
            return ((xA_29_Khoi * xB_29_Khoi) + (yA_29_Khoi * yB_29_Khoi));
        }



        //Hàm tính góc giữa hai vector (đơn vị độ)
        public double GocGiuaHaiVectors_29_Khoi()
        {
            //Khởi tạo biến để gọi hàm tính tích vô hướng của hai vector
            double tichVH_29_Khoi = TichVoHuong_29_Khoi();

            //Tính độ lớn của hai vectơ theo công thức |A| = √(xA² + yA²) và |B| = √(xB² + yB²)
            double doLonA_29_Khoi = Math.Sqrt(Math.Pow(xA_29_Khoi, 2) + Math.Pow(yA_29_Khoi, 2));
            double doLonB_29_Khoi = Math.Sqrt(Math.Pow(xB_29_Khoi, 2) + Math.Pow(yB_29_Khoi, 2));

            if (doLonA_29_Khoi == 0 || doLonB_29_Khoi == 0)
                MessageBox.Show("Không thể tính góc nếu một vector có đội dài bằng không", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //Tính cos của hai vector
            double result_29_Khoi = (tichVH_29_Khoi) / (doLonA_29_Khoi * doLonB_29_Khoi);

            //Trả về kết quả góc theo đơn vị độ
            return Math.Acos(result_29_Khoi) * (180.0 / Math.PI);

        }
    }

}
