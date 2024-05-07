using HappyGrocery.Data;

namespace HappyGrocery.Models
{
    public class ShoppingCart
    {
        private readonly HappyGroceryContext _happyGroceryContext;

        private ShoppingCart(HappyGroceryContext happyGroceryContext)
        {
            _happyGroceryContext = happyGroceryContext;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        public static ShoppingCart GetCart(IServiceProvider services) 
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<HappyGroceryContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem = _happyGroceryContext.ShoppingCartItem.SingleOrDefault(
                s => s.Product.ProductId.Equals(ShoppingCartId));

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                _happyGroceryContext.ShoppingCartItem.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
                _happyGroceryContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = _happyGroceryContext.ShoppingCartItem.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;


            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _happyGroceryContext.ShoppingCartItem.Remove(shoppingCartItem);
                }
            }
            _happyGroceryContext.SaveChanges();

            return localAmount;
        }


    }
}
