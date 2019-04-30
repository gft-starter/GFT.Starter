using Helpers.Domain;

namespace DomainModel.Owner.Events
{
    public class OwnerCreated : DomainEvent
    {
        public Owner Owner { get; set; }

        public override void Flatten()
        {
            Args.Add(nameof(Owner.Id), Owner.Id);
            Args.Add(nameof(Owner.Name), Owner.Name);
            Args.Add(nameof(Owner.BirthDate), Owner.BirthDate.ToShortDateString());
            Args.Add(nameof(Owner.Cpf), Owner.Cpf);
            Args.Add(nameof(Owner.Gender), Owner.Gender);
        }
    }
}
