using SalesAnalysisETL.Application.Interfaces;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Application.Services
{
    public class CustomerTransformer : ITransformador<Customer>
    {
        public IEnumerable<Customer> Transformar(IEnumerable<Customer> customers)
        {
            // Filtrar correos duplicados
            return customers
                .Where(c => !string.IsNullOrWhiteSpace(c.Email))
                .GroupBy(c => c.Email.ToLower())
                .Select(g => g.First());
        }
    }

}
