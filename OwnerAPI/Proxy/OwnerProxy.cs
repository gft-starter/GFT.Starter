using GFT.Starter.Core.Models;
using GFT.Starter.Core.Models.Interfaces;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using System;

namespace OwnerAPI.Proxy
{
    public class OwnerProxy : IOwner
    {

        private readonly IReadOnlyRepository<Owner> ownerReadOnlyRepository;
        public Owner ChangeDeletion(bool deleted, Guid id)
        {
            Owner Owner = ownerReadOnlyRepository.Find(id);
            if(Owner != null)
            {
                Owner.ChangeDeletion(deleted, id);
            }
            return Owner;
        }
    }
}