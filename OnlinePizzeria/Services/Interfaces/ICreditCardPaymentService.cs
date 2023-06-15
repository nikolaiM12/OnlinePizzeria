using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
	public interface ICreditCardPaymentService
	{
		List<CreditCardPaymentViewModel> GetAll();
		Task CreateAsync(CreditCardPaymentViewModel model);
		Task DeletePayment(string id);
		CreditCardPaymentViewModel GetDetailsById(string id);
		Task UpdateAsync(CreditCardPaymentViewModel model);
		Task<CreditCardPaymentViewModel> UpdateById(string id);
		Task<bool> PaymentExists(string id);
	}
}
