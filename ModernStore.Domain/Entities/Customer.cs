using ModernStore.Shared.Entities;
using Flunt.Validations;
using ModernStore.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer() { }
        public Customer(Name name,  
            DateTime birthDate, 
            Email email,
            Document document,
            User user)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Document = document;
            User = user;

            
        }

        public Name Name { get; private set; } 
        public DateTime BirthDate { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public User User { get; private set; }

       
        public void Update(Name name, DateTime birthDate)
        {
         
            AddNotifications(name.Notifications); 

            Name = name;
            BirthDate = birthDate;
        }

        
    }
}
