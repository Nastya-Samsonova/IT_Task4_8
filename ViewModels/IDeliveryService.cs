using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public interface IDeliveryService
    {
        void Deliver(string address, Product product);
    }
}