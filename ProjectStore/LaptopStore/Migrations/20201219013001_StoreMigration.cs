using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaptopStore.Migrations
{
    public partial class StoreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catelog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catelogName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catelog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Combo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comboName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    priceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    catelogID = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    priceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    sale = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    imgLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Catelog_catelogID",
                        column: x => x.catelogID,
                        principalTable: "Catelog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<int>(type: "int", nullable: false),
                    registraDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    role_ID = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                    table.ForeignKey(
                        name: "FK_People_Role_role_ID",
                        column: x => x.role_ID,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    shipperID = table.Column<int>(type: "int", nullable: true),
                    totalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: true),
                    customerAddesss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK_Invoice_People_customerID",
                        column: x => x.customerID,
                        principalTable: "People",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_People_shipperID",
                        column: x => x.shipperID,
                        principalTable: "People",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceID = table.Column<int>(type: "int", nullable: false),
                    productID = table.Column<int>(type: "int", nullable: true),
                    comboID = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Combo_comboID",
                        column: x => x.comboID,
                        principalTable: "Combo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice_invoiceID",
                        column: x => x.invoiceID,
                        principalTable: "Invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Product_productID",
                        column: x => x.productID,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Catelog",
                columns: new[] { "id", "catelogName" },
                values: new object[,]
                {
                    { 1, "Laptop" },
                    { 2, "Bàn phím" },
                    { 3, "Chuột" },
                    { 4, "Tai nghe" },
                    { 5, "Loa" }
                });

            migrationBuilder.InsertData(
                table: "Combo",
                columns: new[] { "id", "comboName", "endDate", "price", "priceSale", "productList", "startDate" },
                values: new object[] { 1, "Giảm giá Giáng Sinh", new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000000m, 15000000m, "1;3;5;7", new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "roleName" },
                values: new object[,]
                {
                    { 1, "Quản lý" },
                    { 2, "Nhân viên" },
                    { 3, "Giao hàng" },
                    { 4, "Khách hàng" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "id", "address", "birthDate", "gender", "name", "password", "phone", "registraDate", "role_ID", "status", "username" },
                values: new object[,]
                {
                    { 1, "273 An Duong vuong, Quan 5, TP.Ho Chi Minh", new DateTime(2000, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nam", "Nguyen van A", "f8b1688fccda97a9750c65fe0baed7e2", 123456789, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "phunghathao1@gmail.com" },
                    { 2, "273 An Duong vuong, Quan 5, TP.Ho Chi Minh", new DateTime(2000, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nam", "Nguyen van B", "f8b1688fccda97a9750c65fe0baed7e2", 123456789, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "phunghathao2@gmail.com" },
                    { 3, "273 An Duong vuong, Quan 5, TP.Ho Chi Minh", new DateTime(2000, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nam", "Nguyen van C", "f8b1688fccda97a9750c65fe0baed7e2", 123456789, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "phunghathao3@gmail.com" },
                    { 4, "273 An Duong vuong, Quan 5, TP.Ho Chi Minh", new DateTime(2000, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nam", "Nguyen van D", "f8b1688fccda97a9750c65fe0baed7e2", 123456789, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, "phunghathao4@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "amount", "catelogID", "createdDate", "imgLink", "price", "priceSale", "productDetail", "productName", "sale", "status" },
                values: new object[,]
                {
                    { 1, 10, 1, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13690000m, 13000000m, "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz;Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg", "Laptop Acer Aspire 3 A315 56 36YS i3 1005G1 (NX.HS5SV.008)", null, null },
                    { 2, 7, 1, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 28990000m, 28990000m, "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg", "Laptop Asus Gaming Rog Strix G512 i7 10750H/144Hz (IAL001T)", null, null },
                    { 3, 7, 2, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 790000m, null, "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg", "Bàn phím Newmen GM368", null, null },
                    { 4, 7, 2, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 690000m, null, "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg", "Bàn phím E-Dra EK311", null, null },
                    { 5, 7, 3, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 290000m, null, "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg", "Chuột Gaming Zadez G151M Đen", null, null },
                    { 6, 7, 3, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 290000m, null, "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg", "Chuột không dây Zadez M353 Xám", null, null },
                    { 7, 7, 4, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 790000m, null, "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg", "Tai nghe Bluetooth True Wireless Mozard Air 3 Đen", null, null },
                    { 8, 7, 4, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3790000m, null, "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg", "Tai nghe Bluetooth True Wireless Jabra Elite Active 65T Xanh Cooper", null, null },
                    { 9, 7, 5, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3390000m, null, "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg", "Loa Bluetooth LG Xboom Go PL7 Xanh Đen", null, null },
                    { 10, 7, 5, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2952000m, null, "CPU: Intel Core i3 Ice Lake, 1005G1, 1.20 GHz;RAM: 8 GB, DDR4 (On board 4GB +1 khe 4GB), 2400 MHz; Ổ cứng: SSD 512 GB M.2 PCIe, Hỗ trợ khe cắm HDD SATA;Màn hình: 15.6 inch, Full HD (1920 x 1080);Card màn hình: Card đồ họa tích hợp, Intel UHD Graphics;Cổng kết nối: 2 x USB 2.0, USB 3.1, HDMI, LAN (RJ45);Hệ điều hành: Windows 10 Home SL;Thiết kế: Vỏ nhựa, PIN liền;Kích thước: Dày 19.9 mm, 1.7 kg", "Loa Bluetooth JBL PULSE2BLKAS Đen", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_customerID",
                table: "Invoice",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_shipperID",
                table: "Invoice",
                column: "shipperID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_comboID",
                table: "InvoiceDetail",
                column: "comboID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_invoiceID",
                table: "InvoiceDetail",
                column: "invoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_productID",
                table: "InvoiceDetail",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_People_role_ID",
                table: "People",
                column: "role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_catelogID",
                table: "Product",
                column: "catelogID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "Combo");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Catelog");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
