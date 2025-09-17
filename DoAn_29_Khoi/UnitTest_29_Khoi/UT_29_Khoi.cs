using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DoAn_29_Khoi;

namespace UnitTest_29_Khoi
{
    [TestClass]
    public class UT_29_Khoi
    {
        [TestMethod]

        //Kiểm tra trường hợp hai vector tạo thành góc bất kỳ - Pass
        //Input xA = 5, yA = 8, xB = 4, yB = 10
        public void TC1_GocBatKy_29_Khoi_Pass()
        {
            double expectedTich_29_Khoi, actualTich_29_Khoi, expectedGoc_29_Khoi, actualGoc_29_Khoi;

            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(5, 8, 4, 10);

            //Kết quả mong đợi của tích vô hướng
            expectedTich_29_Khoi = 100;
            actualTich_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();


            //Kết quả mong đợi của góc giữa 2 vecto
            expectedGoc_29_Khoi = 10.20;
            actualGoc_29_Khoi = Math.Round(T_29_Khoi.GocGiuaHaiVectors_29_Khoi(), 2);


            Assert.AreEqual(expectedTich_29_Khoi, actualTich_29_Khoi);
            Assert.AreEqual(expectedGoc_29_Khoi, actualGoc_29_Khoi);

        }


        [TestMethod]
        //Kiểm tra hai vector vuông góc - Pass
        //Input xA = 2 , yA = 3,xB = -3, yB = 2
        public void TC2_VectoVuongGoc_29_Khoi_Pass()
        {
            double expectedTich_29_Khoi, actualTich_29_Khoi, expectedGoc_29_Khoi, actualGoc_29_Khoi;

            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(2, 3, -3, 2);


            expectedTich_29_Khoi = 0;
            actualTich_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();

            expectedGoc_29_Khoi = 90;
            actualGoc_29_Khoi = Math.Round(T_29_Khoi.GocGiuaHaiVectors_29_Khoi(), 2);


            Assert.AreEqual(expectedTich_29_Khoi, actualTich_29_Khoi);
            Assert.AreEqual(expectedGoc_29_Khoi, actualGoc_29_Khoi);

        }


        [TestMethod]
        //Kiểm tra trường hợp hai vector song song cùng chiều - Pass
        //Input xA = 3, yA = 6, xB = 1, yB = 2
        public void TC3_VectorSongSongCungChieu_29_Khoi_Pass()
        {
            double expectedTich_29_Khoi, actualTich_29_Khoi, expectedGoc_29_Khoi, actualGoc_29_Khoi;
            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(3, 6, 1, 2);
            //Kết quả mong đợi của tích vô hướng
            expectedTich_29_Khoi = 15;
            actualTich_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();
            //Kết quả mong đợi của góc giữa 2 vecto
            expectedGoc_29_Khoi = 0;
            actualGoc_29_Khoi = Math.Round(T_29_Khoi.GocGiuaHaiVectors_29_Khoi(), 2);
            Assert.AreEqual(expectedTich_29_Khoi, actualTich_29_Khoi);
            Assert.AreEqual(expectedGoc_29_Khoi, actualGoc_29_Khoi);
        }

        [TestMethod]
        //Kiểm tra trường hợp hai vector ngược chiều nhau - Pass
        //Input xA = 1, yA = 0, xB = -1, yB = 0
        public void TC4_VectorNguocChieu_29_Khoi_Pass()
        {
            double expectedTich_29_Khoi, actualTich_29_Khoi, expectedGoc_29_Khoi, actualGoc_29_Khoi;
            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(1, 0, -1, 0);
            //Kết quả mong đợi của tích vô hướng
            expectedTich_29_Khoi = -1;
            actualTich_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();
            //Kết quả mong đợi của góc giữa 2 vecto
            expectedGoc_29_Khoi = 180;
            actualGoc_29_Khoi = Math.Round(T_29_Khoi.GocGiuaHaiVectors_29_Khoi(), 2);
            Assert.AreEqual(expectedTich_29_Khoi, actualTich_29_Khoi);
            Assert.AreEqual(expectedGoc_29_Khoi, actualGoc_29_Khoi);
        }

        [TestMethod]
        //Kiểm tra trường hợp một vector bằng 0 - Fail (trường hợp đặc biệt)
        //Input xA = 0, yA = 0, xB = 5, yB = 12
        public void TC5_VectorBangKhong_29_Khoi_Fail()
        {
            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(0, 0, 5, 12);
            //Kết quả mong đợi của tích vô hướng
            double actualTich_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();
            Assert.AreEqual(0, actualTich_29_Khoi);

            // Kiểm tra xem phương thức có ném ra ngoại lệ khi tính góc với vector 0 không
            try
            {
                double actualGoc_29_Khoi = T_29_Khoi.GocGiuaHaiVectors_29_Khoi();
                Assert.Fail("Phương thức không ném ra ngoại lệ khi vector có độ dài bằng 0");
            }
            catch (DivideByZeroException)
            {
                // Ngoại lệ được ném ra như mong đợi
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        //Kiểm tra trường hợp góc nhỏ - Pass
        //Input xA = 10, yA = 1, xB = 9.8, yB = 0.5
        public void TC6_GocNho_29_Khoi_Pass()
        {
            double expectedTich_29_Khoi, actualTich_29_Khoi, expectedGoc_29_Khoi, actualGoc_29_Khoi;
            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(10, 1, 9.8, 0.5);
            //Kết quả mong đợi của tích vô hướng
            expectedTich_29_Khoi = 98.5;
            actualTich_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();
            //Kết quả mong đợi của góc giữa 2 vecto (khoảng 2.79 độ)
            expectedGoc_29_Khoi = 2.79;
            actualGoc_29_Khoi = Math.Round(T_29_Khoi.GocGiuaHaiVectors_29_Khoi(), 2);
            Assert.AreEqual(expectedTich_29_Khoi, actualTich_29_Khoi);
            Assert.AreEqual(expectedGoc_29_Khoi, actualGoc_29_Khoi);
        }

        [TestMethod]
        //Kiểm tra trường hợp góc lớn (gần 180 độ) - Fail
        //Input xA = 5, yA = 2, xB = -4.95, yB = -2.1
        public void TC7_GocLon_29_Khoi_Fail()
        {
            double expectedTich_29_Khoi, actualTich_29_Khoi, expectedGoc_29_Khoi, actualGoc_29_Khoi;
            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(5, 2, -4.95, -2.1);
            //Kết quả mong đợi của tích vô hướng
            expectedTich_29_Khoi = -28.95;
            actualTich_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();
            //Kết quả mong đợi của góc giữa 2 vecto là 178.9
            expectedGoc_29_Khoi = 178.9;
            //Kết quả thực tế của gốc giữa 2 vector là 178.81
            actualGoc_29_Khoi = Math.Round(T_29_Khoi.GocGiuaHaiVectors_29_Khoi(), 2); 
            Assert.AreEqual(expectedTich_29_Khoi, actualTich_29_Khoi);
            Assert.AreEqual(expectedGoc_29_Khoi, actualGoc_29_Khoi);
        }

        [TestMethod]
        //Kiểm tra trường hợp tọa độ thập phân - Fail
        //Input xA = 1.5, yA = 2.5, xB = 3.5, yB = 4.5
        public void TC8_ToaDoThapPhan_29_Khoi_Fail()
        {
            double expectedTich_29_Khoi, actualTich_29_Khoi, expectedGoc_29_Khoi, actualGoc_29_Khoi;
            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(1.5, 2.5, 3.5, 4.5);
            //Kết quả mong đợi của tích vô hướng là 16.5
            expectedTich_29_Khoi = 16.5;
            //Kết quả thực tế của tích vô hướng là
            actualTich_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();
            //Kết quả mong đợi của góc giữa 2 vecto là 3.98
            expectedGoc_29_Khoi = 3.98;
            //Kết quả thực tế của góc giữa 2 vecto là 6.91
            actualGoc_29_Khoi = Math.Round(T_29_Khoi.GocGiuaHaiVectors_29_Khoi(), 2);
            Assert.AreEqual(expectedTich_29_Khoi, actualTich_29_Khoi);
            Assert.AreEqual(expectedGoc_29_Khoi, actualGoc_29_Khoi);
        }

        [TestMethod]
        //Kiểm tra trường hợp tọa độ âm - Pass
        //Input xA = -3, yA = -4, xB = -6, yB = -8
        public void TC9_ToaDoAm_29_Khoi_Pass()
        {
            double expectedTich_29_Khoi, actualTich_29_Khoi, expectedGoc_29_Khoi, actualGoc_29_Khoi;
            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(-3, -4, -6, -8);
            //Kết quả mong đợi của tích vô hướng là 50
            expectedTich_29_Khoi = 50;
            //Kết quả thực tế của tích vô hương là 50
            actualTich_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();
            //Kết quả mong đợi của góc giữa 2 vecto là 0 (vector cùng hướng)
            expectedGoc_29_Khoi = 0;
            //Kết quả thực tế của góc giữa 2 vectơ là 0
            actualGoc_29_Khoi = Math.Round(T_29_Khoi.GocGiuaHaiVectors_29_Khoi(), 2);
            Assert.AreEqual(expectedTich_29_Khoi, actualTich_29_Khoi);
            Assert.AreEqual(expectedGoc_29_Khoi, actualGoc_29_Khoi);
        }

        [TestMethod]
        //Kiểm tra trường hợp một vector có độ dài lớn và một vector có độ dài nhỏ - Fail
        //Input xA = 100, yA = 200, xB = 0.5, yB = 1
        public void TC10_DoDaiKhacNhau_29_Khoi_Fail()
        {
            double expectedTich_29_Khoi, actualTich_29_Khoi, expectedGoc_29_Khoi, actualGoc_29_Khoi;
            TinhToan_29_Khoi T_29_Khoi = new TinhToan_29_Khoi(100, 200, 0.5, 1);
            //Kết quả mong đợi của tích vô hướng
            expectedTich_29_Khoi = 250;
            //Kết quả thực tế của tích vô hướng là 250
            actualTich_29_Khoi = T_29_Khoi.TichVoHuong_29_Khoi();
            //Kết quả mong đợi của góc giữa 2 vecto là 10(vector cùng hướng)
            expectedGoc_29_Khoi = 10;
            //Kết quả thực té của góc giữa 2 vecto là 0 (vecto cùng hướng)
            actualGoc_29_Khoi = Math.Round(T_29_Khoi.GocGiuaHaiVectors_29_Khoi(), 2);
            Assert.AreEqual(expectedTich_29_Khoi, actualTich_29_Khoi);
            Assert.AreEqual(expectedGoc_29_Khoi, actualGoc_29_Khoi);
        }


        


        
    }
}
