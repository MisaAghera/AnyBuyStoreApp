using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.AddState
{
    public class AddStateCommand : IRequest<int>
    {
        public AddStateCommand(StateModel @in)
        {
            In = @in;
        }
        public StateModel In { get; set; }
    }

    public class AddStateHandler : IRequestHandler<AddStateCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddStateHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddStateCommand command, CancellationToken cancellationToken)
        {

            var addData = new States()
            {
                Id = command.In.Id,
                CountryId = command.In.CountryId,
                Name = command.In.Name,
            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class StateModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; } = string.Empty;

    }

}
