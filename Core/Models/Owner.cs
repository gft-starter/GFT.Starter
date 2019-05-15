using System;

namespace Core.Models
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        //[Required]
        //[MinLength(1)]
        public char Gender { get; set; }
    }
}
