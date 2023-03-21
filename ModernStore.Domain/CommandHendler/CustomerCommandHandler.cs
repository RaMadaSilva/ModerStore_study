using Flunt.Notifications;
using ModernStore.Domain.Command;
using ModernStore.Domain.CommandResult;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repository;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Command;

namespace ModernStore.Domain.CommandHendler
{
    public class CustomerCommandHandler : Notifiable<Notification>,
            ICommandHendler<UpdateCustomerCommand>, ICommandHendler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ImailService _mailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository, 
            ImailService imailService)
        {
            _customerRepository = customerRepository;
            _mailService = imailService;
        }

        public ICommandResult Handler(UpdateCustomerCommand Command)
        {
            //Receber um cliente do banco de dados
            var customer = _customerRepository.Get(Command.Id);

            //verificar se o cliente existe 
            if (customer == null)
            {
                AddNotification("Customer", "Cliente Não encontrado");
                return new RegisterCustomerCommandResult();
            }

            //actualizar o cliente 
            var name = new Name(Command.FirstName, Command.LastName);
            customer.Update(name, customer.BirthDate);

            //adicionar as notificações do cliente
            AddNotifications(customer.Notifications);

            //verificar se o cliente é valido e actualizar o cliente
            if (customer.IsValid)
                _customerRepository.Update(customer);

            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());

        }

        public ICommandResult Handler(RegisterCustomerCommand Command)
        {
            if (_customerRepository.DocumentExists(Command.Document))
            {
                AddNotification("Document", "Documento já está em uso ");
                return new RegisterCustomerCommandResult();
            }

            //criar o cliente
            var name = new Name(Command.FirstName, Command.LastName);

            var document = new Document(Command.Document);
            var email = new Email(Command.Email);
            var user = new User(Command.Username, Command.Password, Command.ConfirmPassword);
            var customer = new Customer(name, Command.BirthDate, email, document, user); 

            AddNotifications(customer.Notifications);

            if (IsValid)
                _customerRepository.Save(customer);

            //enviar emial
            _mailService.Send(customer.Name.ToString(),
                customer.Email.Adress,
                "Bem vindo ao serviço de email",
                "");

            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString()); 
        }
    }
}