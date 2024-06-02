using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class DeliveryService : IDeliveryService
    {
        public void Deliver(string address, Product product)
        {
            MessageBox.Show($"Товар {product.Name} доставлен по адресу: {address}");
        }
    }
}