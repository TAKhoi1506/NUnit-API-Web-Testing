using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace DoAn_SeleniumTest_29_Khoi
{
    public partial class Frm_29_Khoi : Form
    {
        public Frm_29_Khoi()
        {
            InitializeComponent();
        }

        //Hàm thêm sản phẩm vào giỏ hàng
        private void btThemSPVaoGioHang_29_Khoi_Click(object sender, EventArgs e)
        {
            //Khởi tạo webdriver mới là 1 driver chuyên dùng cho trình duyệt chrome
            IWebDriver driver_29_Khoi = new ChromeDriver();

            //Điều hướng driver tới trang web nhathuoclongchau.com.vn
            driver_29_Khoi.Navigate().GoToUrl("https://nhathuoclongchau.com.vn/");

            //Tìm thanh tìm kiếm trên trang web và nhập từ khóa là "đau đầu"
            IWebElement timKiem_29_Khoi = driver_29_Khoi.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/header/div/div[2]/div/div/div[4]/div/div/div/form/input"));
            timKiem_29_Khoi.SendKeys("đau đầu");
            Thread.Sleep(1000);//Đợi 1 giây để trình duyệt kịp xử lý


            //Sử dụng Actions mới để giả lập hành động sau khi nhập chữ "đau đầu" thì tự động nhấn Enter để xác nhận dữ liệu nhập vào
            new Actions(driver_29_Khoi).KeyDown(OpenQA.Selenium.Keys.Enter).Build().Perform();
            Thread.Sleep(2000);//Đợi 2 giây để trình duyệt kịp xử lý


            //Tìm sản phẩm đầu tiên trong danh sách kết quả và click vào để xem chi tiết sản phẩm
            IWebElement thuocDauTien_29_Khoi= driver_29_Khoi.FindElement(By.XPath("//*[@id=\"category-page__products-section\"]/div[2]/div/div[1]"));
            thuocDauTien_29_Khoi.Click();
            Thread.Sleep(2000);//Đợi 2 giây để trình duyệt kịp xử lý

            //Khởi tạo một IJavaScriptExecuter để thực hiện thao tác cuộn trang
            IJavaScriptExecutor js_29_Khoi = (IJavaScriptExecutor)driver_29_Khoi;


            // Tìm phần tử
            IWebElement chonSanPham_29_Khoi = driver_29_Khoi.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div[2]/div[3]/div/div/div[1]/div[2]/div/div[7]"));


            // Cuộn đến vị trí của nút "Chọn mua" (cuộn mượt, căn giữa màn hình)
            js_29_Khoi.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", chonSanPham_29_Khoi);
            Thread.Sleep(2000); // Đợi cuộn hoàn tất

            // Tìm và click vào nút "Chọn mua"
            IWebElement chonMua_29_Khoi = driver_29_Khoi.FindElement(By.CssSelector("#__next > div.omd\\:min-w-container-content.lg\\:w-full.flex.flex-col.min-h-screen > div.bg-layer-gray.pb-9.flex-1.relative > div:nth-child(3) > div > div > div.p-4.flex.gap-4.umd\\:flex-col.omd\\:flex-row.omd\\:flex-nowrap.omd\\:rounded-xl.bg-layer-white > div:nth-child(2) > div > div.z-\\[12\\].umd\\:hidden > div.mt-4.flex.gap-4 > button.inline-flex.items-center.justify-center.font-medium.focus-visible\\:outline-none.focus-visible\\:ring-2.focus-visible\\:ring-ring.focus-visible\\:ring-offset-2.disabled\\:cursor-not-allowed.ring-offset-background.bgi-button-primary-active.text-text-white.active\\:bg-button-primary-pressed.active\\:bgi-none.py-\\[14px\\].h-\\[56px\\].rounded-\\[42px\\].text-heading2.flex-auto.px-6"));
            chonMua_29_Khoi.Click();
            Thread.Sleep(1000);


            //Điều hướng tới trang giỏ hàng để kiểm tra xem sản phẩm đã được thêm vào giỏ hàng chưa
            driver_29_Khoi.Navigate().GoToUrl("https://nhathuoclongchau.com.vn/gio-hang");
            Thread.Sleep(1000);

            // Kiểm tra xem giỏ hàng có chứa sản phẩm hay không
            // Nếu không dùng Count > 0 thì sẽ bị lỗi nếu phần tử không tồn tại (NoSuchElementException)
            bool soLuongSP_29_Khoi = driver_29_Khoi.FindElements(By.XPath(".//div[button[text() = 'Mua hàng']]")).Count > 0;
            bool khongtimThay_29_Khoi = driver_29_Khoi  .FindElements(By.XPath(".//div[div[text() = 'Chưa có sản phẩm nào trong giỏ']]")).Count > 0;
            
            //Xuất ra màn hình kết quả thực hiện được
            if(soLuongSP_29_Khoi && !khongtimThay_29_Khoi)
            {
                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Đợi vài giây rồi đóng trình duyệt
            Thread.Sleep(3000);
            driver_29_Khoi.Quit();
        }




        private void btUploadHinhAnh_29_Khoi_Click(object sender, EventArgs e)
        {
            //Khởi tạo đối tượng WebDriver sử dụng trình duyệt Chrome
            IWebDriver driver_29_Khoi = new ChromeDriver();
            try
            {
                //Truy cập vào trang web Nhà Thuốc Long Châu
                driver_29_Khoi.Navigate().GoToUrl("https://nhathuoclongchau.com.vn/");
                driver_29_Khoi.Manage().Window.Maximize();//Phóng to cửa sổ trình duyệt

                //Tìm phần tử chứa ô tìm kiếm và các nút chức năng liên quan(gồm cả nút upload ảnh)
                IWebElement search_29_Khoi = driver_29_Khoi.FindElement(By.XPath("//*[@id='__next']/div[1]/header/div/div[2]/div/div/div[4]/div/div/div"));

                //Tìm và nhấn vào nút upload ảnh (nút thứ hai trong cụm tìm kiếm)
                IWebElement buttonimageUpload_29_Khoi = search_29_Khoi.FindElement(By.XPath("//*[@id='__next']/div[1]/header/div/div[2]/div/div/div[4]/div/div/div/div/button[2]"));
                buttonimageUpload_29_Khoi.Click();
                Thread.Sleep(3000);//Đợi giao diện upload hiển thị

                //Xác định khu vực chứa giao diện upload ảnh 
                IWebElement uploadLocate_29_Khoi = driver_29_Khoi.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div/div[2]"));
                Thread.Sleep(1000);

                //Tìm input để truyển đường dẫn ảnh từ máy vào (tải ảnh lên)
                IWebElement uploadInput_29_Khoi = uploadLocate_29_Khoi.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div/div[2]/div[2]/div/div/button/input"));
               
                //Gửi đường dẫn ảnh trực tiếp vào input(giả lập người dùng chọn ảnh từ máy)
                uploadInput_29_Khoi.SendKeys("D:\\OU\\HK8\\KTPM\\Image\\eugica.jpg");
                Thread.Sleep(3000); //Đợi hệ thống nhận diện ảnh

                //Tìm nút "Tìm kiếm" (submit ảnh đã upload) và click để gửi yêu cầu
                IWebElement submitLocate_29_Khoi = driver_29_Khoi.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div/div[3]"));
                IWebElement submitButton_29_Khoi = submitLocate_29_Khoi.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div/div[3]/button"));
                submitButton_29_Khoi.Click();
                Thread.Sleep(8000); //Đợi kết quả được hiển thị

                //Tìm phần danh sách sản phẩm kết quả trả về sau khi upload ảnh
                IWebElement resultList_29_Khoi = driver_29_Khoi.FindElement(By.XPath("//*[@id='__next']/div[1]/div[2]/div[3]/div/div[3]/div[1]/section"));

                //Lấy danh sách các sản phẩm trong phần kết quả
                var results_29_Khoi = resultList_29_Khoi.FindElements(By.XPath("//div[contains(@class, 'flex gap-3 items-center shrink-0')]"));

                //Hiển thị thông báo tùy theo số lượng kết quả tìm thấy
                if(results_29_Khoi.Count > 0)
                {
                    MessageBox.Show($"Danh sách có {results_29_Khoi.Count} sản phẩm","Kết quả tìm kiếm",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm phù hợp", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    

            }
            //Trường hợp không tìm thấy phần tử nào trong quá trình xử lý (thường do ảnh không nhận dạng được)
            catch (NoSuchElementException)
            {
                MessageBox.Show("Danh sách kết quả không hiển thị.");
            }
            finally
            {
                Thread.Sleep(3000); // Optional: để nhìn thấy kết quả trước khi tắt trình duyệt
                driver_29_Khoi.Quit();
            }
        }




        private void Frm_29_Khoi_Load(object sender, EventArgs e)
        {

        }

        private void btLocSP_29_Khoi_Click(object sender, EventArgs e)
        {
            // Khởi tạo WebDriver với trình duyệt Chrome
            IWebDriver driver_29_Khoi = new ChromeDriver();

            try
            {
                // Điều hướng đến trang chủ Nhà Thuốc Long Châu
                driver_29_Khoi.Navigate().GoToUrl("https://nhathuoclongchau.com.vn/");

                // Nhấp vào danh mục "Thực phẩm chức năng"
                IWebElement DanhMucTPChucNang_29_Khoi = driver_29_Khoi.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div[2]/div[1]/div/ul/li[1]/a/span/p"));
                DanhMucTPChucNang_29_Khoi.Click();
                Thread.Sleep(2000);

                // Nhấp vào danh mục con "Hỗ trợ điều trị"
                IWebElement DanhMucHoTroDieuTri_29_Khoi = driver_29_Khoi.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div[2]/div[1]/div/ul/li[1]/div/div/div[1]/div/div[4]/a/p"));
                DanhMucHoTroDieuTri_29_Khoi.Click();
                Thread.Sleep(2000);


                // Chuẩn bị thực thi JavaScript để cuộn trang
                IJavaScriptExecutor js_29_Khoi = (IJavaScriptExecutor)driver_29_Khoi;

                // Tìm phần tử làm mốc để cuộn đến khu vực bộ lọc
                IWebElement List_Option_29_Khoi = driver_29_Khoi.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div[2]/div[3]/div/div[4]/div/div/div/div[2]"));
                Thread.Sleep(2000);

                // Cuộn mượt đến phần bộ lọc, căn giữa màn hình
                js_29_Khoi.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth' ,block: 'center'});", List_Option_29_Khoi);
                Thread.Sleep(5000);

                //Mở danh sách các lựa chọn
                Thread.Sleep(1000);

                // --- Áp dụng các bộ lọc sản phẩm ---

                // 1. Lọc theo đối tượng sử dụng: chọn "Trẻ em"
                driver_29_Khoi.FindElement(By.XPath("//label[span[text()='Trẻ em']]/span[1]")).Click();
                Thread.Sleep(1000);


                // 2. Lọc theo giá: chọn "Dưới 100.000đ"
                driver_29_Khoi.FindElement(By.XPath("//button[span[text()='Dưới 100.000đ']]")).Click();
                Thread.Sleep(1000);

                // 3. Lọc theo loại thuốc: chọn cả "Thuốc kê đơn" và "Thuốc không kê đơn"
                IWebElement Bo_Loc_29_Khoi = driver_29_Khoi.FindElement(By.CssSelector("#__next > div.omd\\:min-w-container-content.lg\\:w-full.flex.flex-col.min-h-screen > div.bg-layer-gray.pb-9.flex-1.relative > div:nth-child(3) > div > div.container-lite.umd\\:px-0 > div > div > div > div.sm-scrollbar.max-h-\\[calc\\(100vmin-45px-2\\*12px-16px\\)\\].overflow-auto.px-4.\\[\\&\\>\\:last-child\\]\\:pb-0"));
                Thread.Sleep(1000);

                IWebElement LoaiThuoc_29_Khoi = Bo_Loc_29_Khoi.FindElement(By.XPath(".//div[p[text() = 'Loại thuốc']]"));

                js_29_Khoi.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", LoaiThuoc_29_Khoi);
                Thread.Sleep(2000);

                //Thuốc kê đơn
                driver_29_Khoi.FindElement(By.XPath("//label[span[text() = 'Thuốc kê đơn']]")).Click();
                Thread.Sleep(2000);
                //Thuốc không kê đơn
                driver_29_Khoi.FindElement(By.XPath("//label[span[text() = 'Thuốc không kê đơn']]")).Click();
                Thread.Sleep(2000);


                // 4. Lọc theo nước sản xuất: tìm và chọn "Ấn Độ"
                //Chọn nước sản xuất -> tìm kiếm nước sản xuất trên ô tìm kiếm
                IWebElement NuocSX_29_Khoi = driver_29_Khoi.FindElement(By.XPath(".//div[p[text() = 'Nước sản xuất']]"));
                //Ấn để mở rộng thanh cuộn
                NuocSX_29_Khoi.Click();
                Thread.Sleep(2000);

                string keys_29_Khoi = "Ấn Độ";
                NuocSX_29_Khoi.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div[2]/div[3]/div/div[4]/div/div/div/div[2]/div[4]/div[2]/div/div/form/div/input")).SendKeys(keys_29_Khoi);
                Thread.Sleep(2000);
                IWebElement keyword_29_Khoi = driver_29_Khoi.FindElement(By.XPath($"//label[span[text() = '{keys_29_Khoi}']]"));
                js_29_Khoi.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", keyword_29_Khoi);
                Thread.Sleep(2000);
                keyword_29_Khoi.Click();



                // 5. Lọc theo "Chỉ định": mở rộng và chọn "Viêm họng"
                IWebElement ChiDinh_29_Khoi = driver_29_Khoi.FindElement(By.XPath(".//div[p[text() = 'Chỉ định']]"));
                ChiDinh_29_Khoi.Click();
                Thread.Sleep(2000);
                IWebElement xemThem_29_Khoi = ChiDinh_29_Khoi.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div[2]/div[3]/div/div[4]/div/div/div/div[2]/div[5]/div[2]/div/button"));

                // Nhấn "Xem thêm" để hiển thị toàn bộ danh sách chỉ định
                js_29_Khoi.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", xemThem_29_Khoi);
                Thread.Sleep(2000);

                xemThem_29_Khoi.Click(); // Mở rộng danh sách chỉ định
                driver_29_Khoi.FindElement(By.XPath("//label[span[text() = 'Viêm họng']]")).Click();
                Thread.Sleep(3000);

                // --- Kiểm tra kết quả lọc ---
                var ketQua_29_Khoi = driver_29_Khoi.FindElements(By.CssSelector("#category-page__products-section > div.px-4.pt-3.md\\:px-0.md\\:pt-0 > div.grid.grid-cols-2.gap-2.md\\:grid-cols-4.md\\:gap-5"));

                if (ketQua_29_Khoi.Count > 0)
                {
                    MessageBox.Show($"Tìm thấy {ketQua_29_Khoi.Count} sản phảm sau khi lọc", "Kết quả lọc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi khi lọc sản phẩm","Kết quả lọc",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            finally
            {
                Thread.Sleep(3000);
                driver_29_Khoi.Quit();
            }
        }
    }
}
