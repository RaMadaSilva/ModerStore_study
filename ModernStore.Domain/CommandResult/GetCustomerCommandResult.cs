using ModernStore.Shared.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.CommandResult
{
    public class GetCustomerCommandResult: ICommandResult
    {
        public GetCustomerCommandResult() { }
        public GetCustomerCommandResult(string name, 
            string document, 
            string email, 
            string userName, 
            string password, 
            bool active)
        {
            Name = name;
            Document = document;
            Email = email;
            UserName = userName;
            Password = password;
            Active = active;
        }

        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
