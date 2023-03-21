using ModernStore.Shared.Command;

namespace ModernStore.Domain.Command
{
    public  class UpdateCustomerCommand : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
