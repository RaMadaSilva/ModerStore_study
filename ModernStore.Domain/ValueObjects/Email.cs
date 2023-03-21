using Flunt.Notifications;
using Flunt.Validations;
using ModernStore.Shared.ValueObject;

namespace ModernStore.Domain.ValueObjects
{
    public class Email: ValueObject
    {
        protected Email() { }
        public Email(string adress)
        {
            Adress = adress;

            AddNotifications(new Contract<Email>()
        .Requires()
        .IsNotEmail(Adress, "E-mail Invalido"));
        }
        public string Adress { get; private set; }
    }
}
