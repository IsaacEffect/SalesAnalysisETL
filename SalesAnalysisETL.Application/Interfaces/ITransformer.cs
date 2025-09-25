namespace SalesAnalysisETL.Application.Interfaces
{
    public interface ITransformador<T>
    {
        IEnumerable<T> Transformar(IEnumerable<T> datos);
    }
}
