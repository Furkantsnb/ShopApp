﻿
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {

        public EfCoreCartRepository(ShopContext context) : base(context)
        {
        }
        private ShopContext ShopContext
        {
            get { return context as ShopContext; }
        }
        public void ClearCart(int cartId)
        {
            

                var cmd = @"delete from CartItems where CartId=@p0 ";
            ShopContext.Database.ExecuteSqlRaw(cmd, cartId);
            
        }

            public void DeleteFromCart(int cartId, int productId)
        {
            
               
                var cmd = @"delete from CartItems where CartId=@p0 and ProductId=@p1";
            ShopContext.Database.ExecuteSqlRaw(cmd, cartId, productId);
            
        }

        public Cart GetByUserId(string userId)
        {
            
                return ShopContext.Carts
                            .Include(i => i.CartItems)//sepet nesnesine bağlı cartıtems getirir.
                            .ThenInclude(i => i.Product)
                            .FirstOrDefault(i => i.UserId == userId);// UserId parametresine eşit olan ilk sepet nesnesini döndürü

        }

        public override void Update(Cart entity)
        {

            ShopContext.Carts.Update(entity);
                context.SaveChanges();
            
        }
    }
}
