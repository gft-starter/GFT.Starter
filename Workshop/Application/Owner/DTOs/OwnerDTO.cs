using System;
using System.Collections.Generic;

namespace Application.Owner.DTOs
{
    public class OwnerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }

        public List<CarDto> Cars { get; set; }
    }
}
