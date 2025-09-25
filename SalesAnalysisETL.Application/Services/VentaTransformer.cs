using SalesAnalysisETL.Application.Interfaces;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Application.Services
{
    public class VentaTransformer : ITransformador<Venta>
    {
        public IEnumerable<Venta> Transformar(IEnumerable<Venta> ventas)
        {
            
            return ventas.Where(v => v.Cantidad > 0 && v.Precio > 0);
        }
    }
}
