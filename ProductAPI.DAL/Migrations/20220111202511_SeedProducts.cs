using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vasilek.Services.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Лесные", "Майский ландыш – единственный представитель рода Ландыши. Корневище ландыша ползучее, у верхушки несколько бледных мелких листьев, наполовину скрытых в земле.", "https://vasilek.blob.core.windows.net/vasilek/foto-landischi-07.jpg", "Ландыш", 15.0 },
                    { 2, "Комнатные", "Жасмин — это род из 200 или более листопадных кустарников, вьющихся или вьющихся растений, которые выращивают в основном из-за их белых, розовых или желтых сильно ароматных цветов.", "https://vasilek.blob.core.windows.net/vasilek/fonstola.ru_268892_1024x768.jpg", "Жасмин", 13.99 },
                    { 3, "Лекарственный", "Растение травянистое многолетнее высотой 10-50 см, с длинночерешковыми, широкоовальными, крупными зимующими листьями темно-зеленого цвета, собранными в розетку при корне. Когда лето заканчивается, у Бадана краснеют листья. У него длинное, толстое, ветвистое и ползучее корневище.", "https://vasilek.blob.core.windows.net/vasilek/drug-plants-03.jpg", "Бадан толстолистный", 10.99 },
                    { 4, "Садовые", "Название растение получило из-за особой формы цветка, бутоны очень похожи на голову дельфина. По древней греческой легенде у одного юноши погибла возлюбленная, не в силах пережить боль утраты он сделал статую девушки и вдохнул в нее жизнь. Боги разгневались на такую дерзость и превратили юношу в дельфина. Возрожденная девушка однажды вышла на берег моря и увидела дельфина, он подплыл к ней и положил к ее ногам веточку Дельфиниума.", "https://vasilek.blob.core.windows.net/vasilek/761.jpg", "Дельфиниум", 15.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
