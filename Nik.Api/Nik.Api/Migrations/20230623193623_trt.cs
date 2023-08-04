using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nik.Api.Migrations
{
    /// <inheritdoc />
    public partial class trt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    AchievementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Icon = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.AchievementID);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    Text = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    ImageName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tags = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Blog__54379E3063E75C0B", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "CardBanner",
                columns: table => new
                {
                    CardBannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Text = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CardBann__4280811206489A5F", x => x.CardBannerId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CATEGORY__19093A0B7F012C6F", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Category",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "CompanyLogos",
                columns: table => new
                {
                    CompanyLogosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CompanyL__9EF28081A35C6520", x => x.CompanyLogosId);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Subject = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Text = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    ContactUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ContactUsId);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    SliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    FirstTitle = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    MiddleTitle = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    FinalTitle = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Slider__24BC96F07D3D905B", x => x.SliderId);
                });

            migrationBuilder.CreateTable(
                name: "Social",
                columns: table => new
                {
                    SocialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Url = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social", x => x.SocialId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryImage",
                columns: table => new
                {
                    CategoryImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__7CA506C3375F8F92", x => x.CategoryImageId);
                    table.ForeignKey(
                        name: "FK__CategoryI__Categ__2E1BDC42",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    Text = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    ImageName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tags = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryImage_CategoryId",
                table: "CategoryImage",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "CardBanner");

            migrationBuilder.DropTable(
                name: "CategoryImage");

            migrationBuilder.DropTable(
                name: "CompanyLogos");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "Social");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
