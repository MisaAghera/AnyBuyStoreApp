
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stripe;
using Product = Stripe.Product;

namespace AnyBuyStore.Core.Handlers.PaymentHandler.commands.paymentWithStripe
{
    public class PaymentwithStripeCommand : IRequest<bool>
    {
        public PaymentwithStripeCommand(PaymentModel @in)
        {
            In = @in;
        }
        public PaymentModel In { get; set; }
    }

    public class PaymentHandler : IRequestHandler<PaymentwithStripeCommand, bool>
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public PaymentHandler(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public async Task<bool> Handle(PaymentwithStripeCommand command, CancellationToken cancellationToken)
        {
            StripeConfiguration.SetApiKey(_configuration.GetSection("secretStripeapiKey").Value);

            var customers = new CustomerService();
            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = command.In.CustomerEmail,
                Source = command.In.Id,
            });

            var options = new PaymentIntentCreateOptions
            {
                Amount = (long?)command.In.Amount,
                Currency = "inr",
                Customer = customer.Id,
                PaymentMethodTypes = new List<string> { "card"},
                Metadata = new Dictionary<string, string>{ {"OrderId",command.In.OrderId.ToString()}},
            };

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);

            if (paymentIntent != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class PaymentModel
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string CustomerEmail { get; set; }
        public int OrderId {get;set;}
    }

}
