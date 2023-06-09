﻿using Flunt.Validations;
using ModernStore.Shared.Entities;
using System.Security.Cryptography;
using System.Text;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }
        public User(string userName, string password, string confirmPassword)
        {
            UserName = userName; 
            Passeword = EncryptPassword(password);
            Active = true;

            AddNotifications(new Contract<User>()
                .Requires()
                .IsNullOrEmpty(UserName, "Obrigatorio Inserir o user Name")
                .IsNullOrEmpty(Passeword, "Deve passar o password")
                .AreEquals(Passeword, EncryptPassword(confirmPassword), "As senhas não confirmão"));  
        }
        public string UserName { get; private set; }
        public string Passeword { get; private set; }
        public bool Active { get; private set; }

        public void Activeted()
            => Active = true; 
        public void InActiveted()
            => Active = false;

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass))
                return "";
             
            var md5 = MD5.Create();
            var bytes = Encoding.ASCII.GetBytes(pass);
            var hash = md5.ComputeHash(bytes);

            var sbstring = new StringBuilder();
            foreach (var t in hash)
                sbstring.Append(t.ToString("x"));

            return sbstring.ToString().Substring(0,20); 

        }
    }
}
