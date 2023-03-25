using ModernStore.Shared.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.CommandResult
{
    public  class GetListProductCommandResult: ICommandResult
    {
        public GetListProductCommandResult(){ }
        public GetListProductCommandResult(Guid id, 
            string nome, 
            string image, 
            double preco, 
            int quantityOnHend)
        {
            Id = id;
            Nome = nome;
            Image = image;
            Preco = preco;
            QuantityOnHend = quantityOnHend;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Image { get; set; }
        public double Preco { get; set; }
        public int QuantityOnHend { get; set; }
    }
}
