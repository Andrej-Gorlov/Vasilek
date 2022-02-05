using Microsoft.EntityFrameworkCore;
using Vasilek.Services.ProductAPI.Models;
using Vasilek.Services.ProductAPI.Models.Dto;

namespace Vasilek.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext:DbContext   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Product>? Product { get; set; }

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
                CategoryName = "Лесные"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Жасмин",
                Price = 13.99,
                Description = "Жасмин — это род из 200 или более листопадных кустарников, вьющихся или вьющихся растений, которые выращивают в основном из-за их белых, розовых или желтых сильно ароматных цветов.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/fonstola.ru_268892_1024x768.jpg",
                CategoryName = "Комнатные"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Бадан толстолистный",
                Price = 10.99,
                Description = "Растение травянистое многолетнее высотой 10-50 см, с длинночерешковыми, широкоовальными, крупными зимующими листьями темно-зеленого цвета, собранными в розетку при корне. Когда лето заканчивается, у Бадана краснеют листья. У него длинное, толстое, ветвистое и ползучее корневище.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/drug-plants-03.jpg",
                CategoryName = "Лекарственный"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Дельфиниум",
                Price = 15,
                Description = "Название растение получило из-за особой формы цветка, бутоны очень похожи на голову дельфина. По древней греческой легенде у одного юноши погибла возлюбленная, не в силах пережить боль утраты он сделал статую девушки и вдохнул в нее жизнь. Боги разгневались на такую дерзость и превратили юношу в дельфина. Возрожденная девушка однажды вышла на берег моря и увидела дельфина, он подплыл к ней и положил к ее ногам веточку Дельфиниума.",
                ImageUrl = "https://vasilek.blob.core.windows.net/vasilek/761.jpg",
                CategoryName = "Садовые"
            });
        }
    }
}
