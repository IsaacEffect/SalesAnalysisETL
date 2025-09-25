using SalesAnalysisETL.Application.Interfaces;

namespace SalesAnalysisETL.Application.Services
{
    public class DataTransformer<T> : ITransformador<T>
    {
        public IEnumerable<T> Transformar(IEnumerable<T> datos)
        {
            return datos.Distinct();
        }
    }
}
