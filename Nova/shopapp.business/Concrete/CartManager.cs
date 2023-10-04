using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;
        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddToCart(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);//userId parametresine göre sepet nesnesini alır.

            if (cart != null)
            {
                // eklenmek isteyen ürün sepette varmı (güncelleme)
                // eklenmek isteyen ürün sepette var ve yeni kayıt oluştur. (kayıt ekleme)

                var index = cart.CartItems.FindIndex(i => i.ProductId == productId);//sepetin içindeki ürünlerin listesini(cartItems) dolaşarak, productId eşit ürün varsa o Id göre yoksa -1 döner
                if (index < 0)// eğer index-1 dönerse sepete yeni bir ürün  ekler
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity; //eğer sepette ürün varsa değerini quantity miktarı kadar artırır.
                }

                _cartRepository.Update(cart);// sepet nesnesini günceller

            }
        }

        public void ClearCart(int cartId)
        {
            _cartRepository.ClearCart(cartId);// sepetin içindeki tüm ürünleri caetId göre siler
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);//userId parametresine göre sepet nesnesi alır

            if (cart != null)//eğer sepet nesnesi null değilse 
            {
                _cartRepository.DeleteFromCart(cart.Id, productId);//sepetteki ilgili ürünü siler
            }
        }

        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetByUserId(userId);//sepet nesnesini döndürür.
        }

        public void InitializeCart(string userId)//yeni bir sepet oluşturmak için kullanılır.
        {
            _cartRepository.Create(new Cart() { UserId = userId });
        }
    }
}
