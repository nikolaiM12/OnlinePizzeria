using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services
{
    public class CreditCardPaymentService : ICreditCardPaymentService
    {
        private readonly ApplicationDbContext context;
        public CreditCardPaymentService(ApplicationDbContext post)
        {
            context = post;
        }
        public async Task<ICollection<CreditCardPaymentViewModel>> GetAll()
        {
            return await context.OnlinePayment.Select(payment => new CreditCardPaymentViewModel()
            {
                CardNumber = payment.CardNumber,
                ExpirationDate = payment.ExpirationDate,
                CVV = payment.CVV,
                Amount = payment.Amount,
                Customer = payment.Customer,
                Order = payment.Order,
            }).ToListAsync();
        }
        public async Task CreateAsync(CreditCardPaymentViewModel model)
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment();

            creditCardPayment.CreditCardPaymentId = model.CreditCardPaymentId;
            creditCardPayment.CardNumber = model.CardNumber;
            creditCardPayment.ExpirationDate = model.ExpirationDate;
            creditCardPayment.CVV = model.CVV;
            creditCardPayment.Amount = model.Amount;
            creditCardPayment.Customer = model.Customer; 
            creditCardPayment.Order = model.Order;
            
            await context.OnlinePayment.AddAsync(creditCardPayment);
            await context.SaveChangesAsync();
        }
        public async Task DeletePayment(string creditCardPaymentId)
        {
            var onlinepaymentDb = context.OnlinePayment.FirstOrDefault(x => x.CreditCardPaymentId == creditCardPaymentId);
            context.OnlinePayment.Remove(onlinepaymentDb);
            await context.SaveChangesAsync();
        }
        public CreditCardPaymentViewModel FindById(string creditCardPaymentId)
        {
            CreditCardPaymentViewModel creditCardPayment = context.OnlinePayment
                .Select(creditCardPayment => new CreditCardPaymentViewModel()
                {
                    CreditCardPaymentId = creditCardPayment.CreditCardPaymentId,
                    CardNumber = creditCardPayment.CardNumber,
                    ExpirationDate = creditCardPayment.ExpirationDate,
                    CVV = creditCardPayment.CVV,
                    Amount = creditCardPayment.Amount,
                    Customer = creditCardPayment.Customer,
                    Order = creditCardPayment.Order
                }).SingleOrDefault(creditCardPayment => creditCardPayment.CreditCardPaymentId == creditCardPaymentId);
            return creditCardPayment;
        }
    
        public async Task UpdateAsync(CreditCardPaymentViewModel model)
        {
            CreditCardPayment? creditCardPayment = context.OnlinePayment.Find(model.CreditCardPaymentId);

            if(creditCardPayment == null)
            {
                return;
            }

            creditCardPayment.CardNumber = model.CardNumber;
            creditCardPayment.ExpirationDate = model.ExpirationDate;
            creditCardPayment.CVV = model.CVV;
            creditCardPayment.Amount = model.Amount;
            creditCardPayment.Customer = model.Customer;
            creditCardPayment.Order = model.Order;

            context.OnlinePayment.Update(creditCardPayment);
            await context.SaveChangesAsync();
        }
        public CreditCardPaymentViewModel UpdateById(string creditCardPaymentId) 
        {
            CreditCardPaymentViewModel card = context.OnlinePayment
                .Select(card => new CreditCardPaymentViewModel()
                {
                    CreditCardPaymentId = card.CreditCardPaymentId,
                    CardNumber = card.CardNumber,
                    ExpirationDate = card.ExpirationDate,
                    CVV = card.CVV,
                    Amount = card.Amount,
                    Customer = card.Customer,
                    Order = card.Order,
                }).SingleOrDefault(c => c.CreditCardPaymentId == creditCardPaymentId);
            return card; 
        }
    }
}
