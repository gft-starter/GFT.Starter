using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Core.Models.Interfaces
{
    public interface IOwner
    {
        Owner ChangeDeletion(bool deleted, Guid id);
    }
}