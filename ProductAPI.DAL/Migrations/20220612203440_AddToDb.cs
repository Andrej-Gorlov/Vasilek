using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.DAL.Migrations
{
    public partial class AddToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Лесные" },
                    { 2, "Комнатные" },
                    { 3, "Лекарственный" },
                    { 4, "Садовые" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Майский ландыш – единственный представитель рода Ландыши. Корневище ландыша ползучее, у верхушки несколько бледных мелких листьев, наполовину скрытых в земле.", "https://vasilek.blob.core.windows.net/vasilek/foto-landischi-07.jpg", "Ландыш", 15.0 },
                    { 2, 2, "Жасмин — это род из 200 или более листопадных кустарников, вьющихся или вьющихся растений, которые выращивают в основном из-за их белых, розовых или желтых сильно ароматных цветов.", "https://vasilek.blob.core.windows.net/vasilek/fonstola.ru_268892_1024x768.jpg", "Жасмин", 13.99 },
                    { 3, 3, "Растение травянистое многолетнее высотой 10-50 см, с длинночерешковыми, широкоовальными, крупными зимующими листьями темно-зеленого цвета, собранными в розетку при корне. Когда лето заканчивается, у Бадана краснеют листья. У него длинное, толстое, ветвистое и ползучее корневище.", "https://vasilek.blob.core.windows.net/vasilek/drug-plants-03.jpg", "Бадан толстолистный", 10.99 },
                    { 4, 4, "Название растение получило из-за особой формы цветка, бутоны очень похожи на голову дельфина. По древней греческой легенде у одного юноши погибла возлюбленная, не в силах пережить боль утраты он сделал статую девушки и вдохнул в нее жизнь. Боги разгневались на такую дерзость и превратили юношу в дельфина. Возрожденная девушка однажды вышла на берег моря и увидела дельфина, он подплыл к ней и положил к ее ногам веточку Дельфиниума.", "https://vasilek.blob.core.windows.net/vasilek/761.jpg", "Дельфиниум", 15.0 },
                    { 5, 3, "Гвоздика пышная встречается по всей европейской части России, кроме Юга и Крайнего Севера, растет в Средней Азии, в Западной и Восточной Сибири. Наиболее часто встречается по опушкам лесов, в лугах, в разреженных лесах, а также встречается в горах, где растет выше лесного пояса. Этот лесной цветок является многолетним корневищным травянистым растением.Высотой от 25 до 60 см.Обладает супротивными листьями и немногими цветоносными стеблями с цветами необычайной красоты.Пурпурные, розовые или белые цветы с глубоко рассеченными лепестками напоминают тончайшие кружева мастерицы.Цветет с начала июня до июля.", "https://vasilek.blob.core.windows.net/vasilek/1024x768_420725_%5Bwww.ArtFile.ru%5D.jpg", "Гвоздика пышная", 18.0 },
                    { 6, 3, "Свое народное название – Водосбор, Аквилегия получила из-за особого строения цветка, каждый из которых имеет несколько «карманчиков», которые во время дождя наполняются водой, то есть «собирают воду». У декоративных видов данная функция отсутствует, но у Водосбора настоящего (см. фото) есть такие карманчики. Аквилегия или Водосбор являются травянистыми многолетними растениями.Его видов насчитывается около 70 видов.В дикой природе растение произрастает в лесах и лугах, Водосбор широко распространен в горных областях Северного полушария.", "https://vasilek.blob.core.windows.net/vasilek/659792_1.jpg", "Аквилегия (Водосбор)", 25.0 },
                    { 7, 4, "Родиной Айвы японской является Япония и Китай, значительно распространена в России – не только в южной части страны, но и в средней полосе. Связано это с тем, что данный цветущий кустарник прекрасно переносит морозы. Даже если его ветки в холодный период года подмерзают – сам куст остается. Название «Северный лимон» Айва японская получила благодаря плодам – ярко желтым с характерным запахом и вкусом лимона.Хотя и по содержанию витамина С этот кустарник цветущий практически не уступает настоящему лимону.", "https://vasilek.blob.core.windows.net/vasilek/P9-PIGWOWIEC-JAPONSKI-40-CM-WYPRZEDAZ.jfif", "Айва японская", 19.0 },
                    { 8, 2, "Родиной Зефирантеса является Центральная Америка. В настоящий момент это довольно распространенное и популярное декоративное растение, выращиваемое в основном как комнатный цветок. Народное название «Выскочка» образовалось из - за интересной особенности растения: его бутоны довольно быстро появляются из - под земли, и если пару дней назад даже предпосылок к цветению не было, то сегодня оно уже все может быть в цветах.", "https://vasilek.blob.core.windows.net/vasilek/c05414b4d9b8af597705a8cbd2.jpeg", "Зефирантес", 18.0 },
                    { 9, 1, "Название Колокольчика произошло из латинского языка, в дословном переводе означающий колокол. По народному поверью, цветы Колокольчиков один раз в году звенят, происходит это в сказочную ночь накануне праздника Ивана Купалы. Колокольчик – травянистое растение, имеющее более трёхсот видов.Наиболее часто цветы встречаются в Европе, на Кавказе, в Сибири, Колокольчик предпочитает умеренный климат.Растет цветок в полях, лесах и лугах, встречается также на скальных и пустынных участках, некоторые виды также растут в лесу.В последнее время Колокольчик активно высаживается на садовых участках..", "https://vasilek.blob.core.windows.net/vasilek/6d6e12a458c2df5.jpg", "Колокольчик", 18.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
