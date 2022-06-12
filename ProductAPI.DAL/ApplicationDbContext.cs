using Microsoft.EntityFrameworkCore;
using ProductAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product>? Product { get; set; }
        public DbSet<Category>? Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Ландыш",
                Price = 15,
                Description = "Майский ландыш – единственный представитель рода Ландыши. Корневище ландыша ползучее, у верхушки несколько бледных мелких листьев, наполовину скрытых в земле.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/foto-landischi-07.jpg",
                Category = new() { CategoryName= "Лесные" }
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Жасмин",
                Price = 13.99,
                Description = "Жасмин — это род из 200 или более листопадных кустарников, вьющихся или вьющихся растений, которые выращивают в основном из-за их белых, розовых или желтых сильно ароматных цветов.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/fonstola.ru_268892_1024x768.jpg",
                Category = new() { CategoryName = "Комнатные" }
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Бадан толстолистный",
                Price = 10.99,
                Description = "Растение травянистое многолетнее высотой 10-50 см, с длинночерешковыми, широкоовальными, крупными зимующими листьями темно-зеленого цвета, собранными в розетку при корне. Когда лето заканчивается, у Бадана краснеют листья. У него длинное, толстое, ветвистое и ползучее корневище.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/drug-plants-03.jpg",
                Category = new() { CategoryName = "Лекарственный" }
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Дельфиниум",
                Price = 15,
                Description = "Название растение получило из-за особой формы цветка, бутоны очень похожи на голову дельфина. По древней греческой легенде у одного юноши погибла возлюбленная, не в силах пережить боль утраты он сделал статую девушки и вдохнул в нее жизнь. Боги разгневались на такую дерзость и превратили юношу в дельфина. Возрожденная девушка однажды вышла на берег моря и увидела дельфина, он подплыл к ней и положил к ее ногам веточку Дельфиниума.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/761.jpg",
                Category = new() { CategoryName = "Садовые" }
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Гвоздика пышная",
                Price = 18,
                Description = "Гвоздика пышная встречается по всей европейской части России, кроме Юга и Крайнего Севера, растет в Средней Азии, в Западной и Восточной Сибири. Наиболее часто встречается по опушкам лесов, в лугах, в разреженных лесах, а также встречается в горах, где растет выше лесного пояса. Этот лесной цветок является многолетним корневищным травянистым растением.Высотой от 25 до 60 см.Обладает супротивными листьями и немногими цветоносными стеблями с цветами необычайной красоты.Пурпурные, розовые или белые цветы с глубоко рассеченными лепестками напоминают тончайшие кружева мастерицы.Цветет с начала июня до июля.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/1024x768_420725_%5Bwww.ArtFile.ru%5D.jpg",
                Category = new() { CategoryName = "Лекарственные" }
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "Аквилегия (Водосбор)",
                Price = 25,
                Description = "Свое народное название – Водосбор, Аквилегия получила из-за особого строения цветка, каждый из которых имеет несколько «карманчиков», которые во время дождя наполняются водой, то есть «собирают воду». У декоративных видов данная функция отсутствует, но у Водосбора настоящего (см. фото) есть такие карманчики. Аквилегия или Водосбор являются травянистыми многолетними растениями.Его видов насчитывается около 70 видов.В дикой природе растение произрастает в лесах и лугах, Водосбор широко распространен в горных областях Северного полушария.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/659792_1.jpg",
                Category = new() { CategoryName = "Лекарственные" }
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                Name = "Айва японская",
                Price = 19,
                Description = "Родиной Айвы японской является Япония и Китай, значительно распространена в России – не только в южной части страны, но и в средней полосе. Связано это с тем, что данный цветущий кустарник прекрасно переносит морозы. Даже если его ветки в холодный период года подмерзают – сам куст остается. Название «Северный лимон» Айва японская получила благодаря плодам – ярко желтым с характерным запахом и вкусом лимона.Хотя и по содержанию витамина С этот кустарник цветущий практически не уступает настоящему лимону.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/P9-PIGWOWIEC-JAPONSKI-40-CM-WYPRZEDAZ.jfif",
                Category = new() { CategoryName = "Садовые" }
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                Name = "Зефирантес",
                Price = 18,
                Description = "Родиной Зефирантеса является Центральная Америка. В настоящий момент это довольно распространенное и популярное декоративное растение, выращиваемое в основном как комнатный цветок. Народное название «Выскочка» образовалось из - за интересной особенности растения: его бутоны довольно быстро появляются из - под земли, и если пару дней назад даже предпосылок к цветению не было, то сегодня оно уже все может быть в цветах.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/c05414b4d9b8af597705a8cbd2.jpeg",
                Category = new() { CategoryName = "Комнатные" }
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                Name = "Колокольчик",
                Price = 18,
                Description = "Название Колокольчика произошло из латинского языка, в дословном переводе означающий колокол. По народному поверью, цветы Колокольчиков один раз в году звенят, происходит это в сказочную ночь накануне праздника Ивана Купалы. Колокольчик – травянистое растение, имеющее более трёхсот видов.Наиболее часто цветы встречаются в Европе, на Кавказе, в Сибири, Колокольчик предпочитает умеренный климат.Растет цветок в полях, лесах и лугах, встречается также на скальных и пустынных участках, некоторые виды также растут в лесу.В последнее время Колокольчик активно высаживается на садовых участках..",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/6d6e12a458c2df5.jpg",
                Category = new() { CategoryName = "Лесные" }
            });
        }
    }
}
