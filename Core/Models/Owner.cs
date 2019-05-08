using GFT.Starter.Core.Models.Interfaces;
using System;

namespace GFT.Starter.Core.Models
{
    public class Owner : IOwner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }

        public Owner ChangeDeletion(bool deleted, Guid id)
        {
            Id = id;
            //Deleted = deleted;

            return this;
        }
    }
}