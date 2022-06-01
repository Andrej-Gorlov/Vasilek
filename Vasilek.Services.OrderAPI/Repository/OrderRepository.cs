using Microsoft.EntityFrameworkCore;
using Vasilek.Services.OrderAPI.DbContexts;
using Vasilek.Services.OrderAPI.Models;

namespace Vasilek.Services.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        // Регистрация ApplicationDbContext как одиночка для OrderRepository
        // т.к OrderRepository требуется внутри служебной шины  
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;

        public OrderRepository(DbContextOptions<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            _db.OrderHeaders.Add(orderHeader);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            var orderHeaderFromDb = await _db.OrderHeaders.FirstOrDefaultAsync(u => u.OrderHeaderId == orderHeaderId);
            if (orderHeaderFromDb != null)
            {
                orderHeaderFromDb.PaymentStatus = paid;
                await _db.SaveChangesAsync();
            }
        }
    }
}
