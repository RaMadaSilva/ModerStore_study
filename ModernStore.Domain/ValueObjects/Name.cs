using Flunt.Notifications;
using Flunt.Validations;
using ModernStore.Shared.ValueObject;

namespace ModernStore.Domain.ValueObjects
{
    public  class Name: ValueObject
    {
        protected Name() { }
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
                .Requires()
                .IsNotNullOrEmpty(FirstName, "Nome Invalido")
                .IsNotNullOrEmpty(LastName, "Apelido Invalido")
                .IsMinValue(3, "O nome deve conter no minimo 3 caracrteres")); 
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
