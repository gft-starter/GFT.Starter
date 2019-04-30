using System;

namespace Infrastructure.Models
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
    }
}
