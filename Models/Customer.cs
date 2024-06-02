namespace WpfApp1.Models
{
    public class Customer
    {
        public class Product
        {
            public string? Name { get; set; }

            public void Purchase(TradePoint tradePoint, Product product)
            {
                tradePoint.SellProduct(product);
            }
        }
    }
}