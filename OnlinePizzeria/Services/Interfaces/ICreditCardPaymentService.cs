using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface ICreditCardPaymentService
    {
        List<CreditCardPaymentViewModel> GetAll();
        Task CreateAsync(CreditCardPaymentViewModel model);
        Task DeletePayment(string customerId);
        CreditCardPaymentViewModel FindById(string creditCardPaymentId);
        Task UpdateAsync(CreditCardPaymentViewModel model);
        CreditCardPaymentViewModel UpdateById(string creditCardPaymentId);
    }
}
