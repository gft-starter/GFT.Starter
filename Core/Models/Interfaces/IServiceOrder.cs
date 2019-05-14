using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Core.Models.Interfaces
{
    public interface IServiceOrder
    {
        ServiceOrder ChangeStatus(ServiceOrderStatus status, Guid id);
    }
}
