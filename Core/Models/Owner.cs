using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }

        [Required]
        [MinLength(1)]
        public char Gender { get; set; }

        public static implicit operator Guid(Owner v)
        {
            throw new NotImplementedException();
        }

        public class Create : Owner
        {
            private object name;
            private object cpf;
            private object gender;
            private object birthDate;

            public Create(object name, object cpf, object gender, object birthDate)
            {
                this.name = name;
                this.cpf = cpf;
                this.gender = gender;
                this.birthDate = birthDate;
            }
        }
    }
}
