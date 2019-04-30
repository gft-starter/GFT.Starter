using Helpers.Domain;

namespace DomainModel.Services
{
    public class TaxService : IDomainService
    {
        public float CalculateTaxes(ServiceOrder.ServiceOrder serviceOrder)
        {
            return serviceOrder.CalculateValue() * 0.1f;
        }
    }
}
