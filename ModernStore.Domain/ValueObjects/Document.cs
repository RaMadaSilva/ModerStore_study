﻿using ModernStore.Shared.ValueObject;
using System.Text.RegularExpressions;

namespace ModernStore.Domain.ValueObjects
{

    public class Document: ValueObject
    {
        protected Document() { }
        public Document(string number)
        {
            Number = number;

            if (!Validate(Number.ToUpper()))
                AddNotification(Number.ToUpper(), "Numero Invalido");
        }
        public string Number { get; private set; }

        public bool Validate(string number)
        {
            var regex = new Regex("^[0-9]{9}[a-zA-Z]{2}[0-9]{3}$".ToUpper());
            return regex.IsMatch(number.ToUpper());
        }
    }
}
