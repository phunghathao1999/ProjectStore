using System;
using ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Catelog> Catelog { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ImageProduct> ImageProduct { get; set; }
        public virtual DbSet<ProductAvatar> ProductAvatar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catelog>().HasData(
                new Catelog() { id = 1, catelogName = "Laptop" },
                new Catelog() { id = 2, catelogName = "Bàn phím" },
                new Catelog() { id = 3, catelogName = "Chuột" },
                new Catelog() { id = 4, catelogName = "Tai nghe" },
                new Catelog() { id = 5, catelogName = "Loa" }
            );

            modelBuilder.Entity<Product>().HasData(
                    new Product()
                    {
                        id = 1,
                        productName = "Laptop Acer Aspire 3 A315 56 36YS i3 1005G1 (NX.HS5SV.008)",
                        catelogID = 1,
                        amount = 10,
                        price = 13690000,
                        priceSale = 13000000,
                        createdDate = Convert.ToDateTime("19/11/2020"),
                        productDetail = "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg",
                    },
                    new Product()
                    {
                        id = 2,
                        productName = "Laptop Asus Gaming Rog Strix G512 i7 10750H/144Hz (IAL001T)",
                        catelogID = 1,

                        amount = 7,
                        price = 28990000,
                        priceSale = 28990000,
                        createdDate = Convert.ToDateTime("19/11/2020"),
                        productDetail = "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg",
                    },
                    new Product()
                    {
                        id = 3,
                        productName = "Bàn phím Newmen GM368",
                        catelogID = 2,
                        amount = 7,
                        price = 790000,
                        createdDate = Convert.ToDateTime("19/11/2020"),
                        productDetail = "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg",
                    },
                    new Product()
                    {
                        id = 4,
                        productName = "Bàn phím E-Dra EK311",
                        catelogID = 2,
                        amount = 7,
                        price = 690000,
                        createdDate = Convert.ToDateTime("19/11/2020"),
                        productDetail = "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg",
                    },
                    new Product()
                    {
                        id = 5,
                        productName = "Chuột Gaming Zadez G151M Đen",
                        catelogID = 3,
                        amount = 7,
                        price = 290000,
                        createdDate = Convert.ToDateTime("19/11/2020"),
                        productDetail = "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg",
                    },
                    new Product()
                    {
                        id = 6,
                        productName = "Chuột không dây Zadez M353 Xám",
                        catelogID = 3,
                        amount = 7,
                        price = 290000,
                        createdDate = Convert.ToDateTime("19/11/2020"),
                        productDetail = "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg",
                    },
                    new Product()
                    {
                        id = 7,
                        productName = "Tai nghe Bluetooth True Wireless Mozard Air 3 Đen",
                        catelogID = 4,
                        amount = 7,
                        price = 790000,
                        createdDate = Convert.ToDateTime("19/11/2020"),
                        productDetail = "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg",
                    },
                    new Product()
                    {
                        id = 8,
                        productName = "Tai nghe Bluetooth True Wireless Jabra Elite Active 65T Xanh Cooper",
                        catelogID = 4,
                        amount = 7,
                        price = 3790000,
                        createdDate = Convert.ToDateTime("19/11/2020"),
                        productDetail = "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg",
                    },
                    new Product()
                    {
                        id = 9,
                        productName = "Loa Bluetooth LG Xboom Go PL7 Xanh Đen",
                        catelogID = 5,
                        amount = 7,
                        price = 3390000,
                        createdDate = Convert.ToDateTime("19/11/2020"),
                        productDetail = "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg",
                    },
                    new Product()
                    {
                        id = 10,
                        productName = "Loa Bluetooth JBL PULSE2BLKAS Đen",
                        catelogID = 5,
                        amount = 7,
                        price = 2952000,
                        createdDate = Convert.ToDateTime("19/11/2020"),
                        productDetail = "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg",
                    }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role() { id = 1, roleName = "Quản lý" },
                new Role() { id = 2, roleName = "Nhân viên" },
                new Role() { id = 3, roleName = "Giao hàng" },
                new Role() { id = 4, roleName = "Khách hàng" }
            );

            modelBuilder.Entity<People>().HasData(
                new People()
                {
                    id = 1,
                    username = "phunghathao1@gmail.com",
                    password = "f8b1688fccda97a9750c65fe0baed7e2",
                    name = "Nguyen van A",
                    gender = "Nam",
                    birthDate = Convert.ToDateTime("19/11/2000"),
                    address = "273 An Duong vuong, Quan 5, TP.Ho Chi Minh",
                    phone = 123456789,
                    registraDate = Convert.ToDateTime("19/11/2020"),
                    role_ID = 1,
                },
                new People()
                {
                    id = 2,
                    username = "phunghathao2@gmail.com",
                    password = "f8b1688fccda97a9750c65fe0baed7e2",
                    name = "Nguyen van B",
                    gender = "Nam",
                    birthDate = Convert.ToDateTime("19/11/2000"),
                    address = "273 An Duong vuong, Quan 5, TP.Ho Chi Minh",
                    phone = 123456789,
                    registraDate = Convert.ToDateTime("19/11/2020"),
                    role_ID = 2,
                },
                new People()
                {
                    id = 3,
                    username = "phunghathao3@gmail.com",
                    password = "f8b1688fccda97a9750c65fe0baed7e2",
                    name = "Nguyen van C",
                    gender = "Nam",
                    birthDate = Convert.ToDateTime("19/11/2000"),
                    address = "273 An Duong vuong, Quan 5, TP.Ho Chi Minh",
                    phone = 123456789,
                    registraDate = Convert.ToDateTime("19/11/2020"),
                    role_ID = 3,
                },
                new People()
                {
                    id = 4,
                    username = "phunghathao4@gmail.com",
                    password = "f8b1688fccda97a9750c65fe0baed7e2",
                    name = "Nguyen van D",
                    gender = "Nam",
                    birthDate = Convert.ToDateTime("19/11/2000"),
                    address = "273 An Duong vuong, Quan 5, TP.Ho Chi Minh",
                    phone = 123456789,
                    registraDate = Convert.ToDateTime("19/11/2020"),
                    role_ID = 4,
                }
            );

        }
    }
}