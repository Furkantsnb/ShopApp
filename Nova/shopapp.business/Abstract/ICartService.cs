using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface ICartService //Sepet Hizmeti
    {
        void InitializeCart(string userId);//yeni bir sepet oluşturma
        Cart GetCartByUserId(string userId);//Kullanıcı Kimliğine Göre Sepeti Al
        void AddToCart(string userId, int productId, int quantity);//Sepete ekle
        void DeleteFromCart(string userId, int productId);//Sepetten Sil
        void ClearCart(int cartId);//Sepeti Temizle
    }
}
