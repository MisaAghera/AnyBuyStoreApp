using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.UpdateState
{
    public class UpdateStateCommand : IRequest<int>
    {
        public UpdateStateCommand(UpdateStateModel @in)
        {
            In = @in;

        }
        public UpdateStateModel In { get; set; }
    }

    public class UpdateStateHandler : IRequestHandler<UpdateStateCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateStateHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateStateCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.States.Where(a => a.Id == command.In.Id).FirstOrDefault();

            UpdateData.CountryId = command.In.CountryId;
            UpdateData.Name = command.In.Name;
            UpdateData.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return UpdateData.Id;

        }
    }
    public class UpdateStateModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; } = string.Empty;

    }

}

