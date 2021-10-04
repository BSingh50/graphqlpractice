using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarvedRock.Api.Migrations
{
    public partial class addedProductReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[,]
                {
                    { 1, 2, "It makes me feel like a real solider", "Very Good" },
                    { 2, 4, "I climbed many mountains with this kit and it saved me many times. Definitely worth it.", "Handy Dandy" },
                    { 3, 6, "It's not orange enough, didn't like it", "Orange? more like yellow" },
                    { 4, 5, "Drives very fast, recommend it to anyone", "Very Speedy" },
                    { 5, 3, "I can fill it up thousands of things and these still room for more. Amazing!", "Very useful" },
                    { 6, 1, "Leaves my feet cold and bruised. Soles fly right off.", "Terrible" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 28, 22, 10, 46, 678, DateTimeKind.Unspecified).AddTicks(5502), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 28, 22, 10, 46, 690, DateTimeKind.Unspecified).AddTicks(3823), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 28, 22, 10, 46, 690, DateTimeKind.Unspecified).AddTicks(4040), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 28, 22, 10, 46, 690, DateTimeKind.Unspecified).AddTicks(4072), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 28, 22, 10, 46, 690, DateTimeKind.Unspecified).AddTicks(4136), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 28, 22, 10, 46, 690, DateTimeKind.Unspecified).AddTicks(4157), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 27, 22, 21, 5, 572, DateTimeKind.Unspecified).AddTicks(880), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 27, 22, 21, 5, 575, DateTimeKind.Unspecified).AddTicks(1378), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 27, 22, 21, 5, 575, DateTimeKind.Unspecified).AddTicks(1433), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 27, 22, 21, 5, 575, DateTimeKind.Unspecified).AddTicks(1441), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 27, 22, 21, 5, 575, DateTimeKind.Unspecified).AddTicks(1464), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2021, 8, 27, 22, 21, 5, 575, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 1, 0, 0, 0)));
        }
    }
}
