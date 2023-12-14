using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        #region Fields
        public Guid Id { get; set; }
        #endregion
    }
}
