using System.Windows;

namespace WpfApp1.Models
{
    public class TradePoint
    {
        public event EventHandler<Product>? ProductSoldOut;
        public event EventHandler<Product>? ProductPurchased;

        private readonly List<Product> _products = new List<Product>();

        public IReadOnlyList<Product> Products => _products;

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void SellProduct(Product product)
        {
            if (ProductExists(product))
            {
                if (ProductAvailable(product))
                {
                    DecreaseProductQuantity(product);
                    ProductPurchased?.Invoke(this, product);
                }
                else
                {
                    ProductSoldOut?.Invoke(this, product);
                }
            }
            else
            {
                ShowErrorMessage("Товар не найден!");
            }
        }

        private bool ProductExists(Product product)
        {
            return _products.Contains(product);
        }

        private bool ProductAvailable(Product product)
        {
            return product.Quantity > 0;
        }

        private void DecreaseProductQuantity(Product product)
        {
            product.Quantity--;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}