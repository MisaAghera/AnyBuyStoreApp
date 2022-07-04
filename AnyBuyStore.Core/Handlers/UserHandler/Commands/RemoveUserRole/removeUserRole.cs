
using AnyBuyStore.Data.Data;
using AnyBuyStore.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.UserHandler.Commands.RemoveUserRole
{
    public class removeUserRole : IRequest<int>
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public class removeUserRoleHandler : IRequestHandler<removeUserRole, int>
        {
            private readonly DatabaseContext _context;
            public removeUserRoleHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(removeUserRole command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.UserRoles.Where(a => a.UserId == command.UserId && a.RoleId == command.RoleId).FirstOrDefaultAsync();

                _context.UserRoles.Remove(deleteData);
                await _context.SaveChangesAsync();
                return deleteData.RoleId;

            }
        }
    }
}
