using ModernStore.Shared.Command;

namespace ModernStore.Domain.CommandResult
{
    public class RegisterCustomerCommandResult : ICommandResult
    {
        public RegisterCustomerCommandResult() { }

        public RegisterCustomerCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        
        public string Name { get; set; }
    }
}
