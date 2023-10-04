using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(ShopContext context) : base(context)
        {
        }
        private ShopContext ShopContext
        {
            get { return context as ShopContext; }
        }
        public List<Order> GetOrders(string userId)
        {
           
                var orders = ShopContext.Orders// tüm sipariş nesnelerini getirir
                    .Include(i => i.OrderItems)//sipariş nesnelerine bağlı olan OrderItems
                    .ThenInclude(i => i.Product)// ve Product nesnelerini de getirir.
                    .AsQueryable();// koleksiyonu bir sorgu olarak dönüştürür.

            if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i => i.UserId == userId);//userId parametresine eşit olan siparişleri filtreler.
            }
                return orders.ToList();
            
        }
    }
}
