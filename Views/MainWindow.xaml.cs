using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.Views
{
    public partial class TradePointWindow : Window
    {
        private readonly TradePoint _tradePoint;
        private readonly Customer _customer;

        public TradePointWindow()
        {
            InitializeComponent();

            _tradePoint = new TradePoint
            {
                Products = new List<Product>
        {
            new Product { Name = "Пачка макарон", Price = 70.0, Quantity = 3 },
            new Product { Name = "Коробка молока", Price = 89.0, Quantity = 4 },
            new Product { Name = "Хлеб", Price = 37.0, Quantity = 5 }
        }
            };

            _customer = new Customer();

            _tradePoint.ProductPurchased += TradePoint_ProductPurchased;
            _tradePoint.ProductSoldOut += TradePoint_ProductSoldOut;

            UpdateProductList();
        }

        private void UpdateProductList()
        {
            ProductListBox.Items.Clear();
            foreach (var product in _tradePoint.Products)
            {
                ProductListBox.Items.Add($"{product.Name} - {product.Price}$ ({product.Quantity} доступно)");
            }
        }

        private void TradePoint_ProductPurchased(object sender, Product e)
        {
            MessageBox.Show($"Товар {e.Name} успешно куплен!");
            UpdateProductList();
        }

        private void TradePoint_ProductSoldOut(object sender, Product e)
        {
            MessageBox.Show($"Товар {e.Name} закончился!");
            UpdateProductList();
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            BuySelectedProduct();
        }

        private void BuySelectedProduct()
        {
            if (ProductListBox.SelectedIndex >= 0)
            {
                string productName = GetProductNameFromListBox();
                Product selectedProduct = GetProductByName(productName);

                if (selectedProduct != null)
                {
                    _customer.BuyProduct(_tradePoint, selectedProduct);
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для покупки.");
            }
        }

        private string GetProductNameFromListBox()
        {
            return ProductListBox.SelectedItem.ToString().Split('-')[0].Trim();
        }

        private Product GetProductByName(string productName)
        {
            return _tradePoint.Products.FirstOrDefault(p => p.Name == productName);
        }
    }
    }
}
