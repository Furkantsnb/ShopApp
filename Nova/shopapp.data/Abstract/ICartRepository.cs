using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetByUserId(string userId);//belirli bir kullanıcının sepetindeki ürünü getirir.
        void DeleteFromCart(int cartId, int productId);//sepette belirli ürünü siler
        void ClearCart(int cartId);//sepetteki tüm ürünleri siler
    }
}
