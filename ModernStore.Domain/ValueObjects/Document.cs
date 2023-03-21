using ModernStore.Shared.ValueObject;

namespace ModernStore.Domain.ValueObjects
{

    public class Document: ValueObject
    {
        protected Document() { }
        public Document(string number)
        {
            Number = number;

            if (!IsValid)
                AddNotification("Number", "Numero Invalido");
        }
        public string Number { get; private set; }
    }
}
