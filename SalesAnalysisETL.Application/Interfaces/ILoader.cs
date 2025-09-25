namespace SalesAnalysisETL.Application.Interfaces
{
    public interface ILoader<T>
    {
        void Cargar(IEnumerable<T> datos);
    }
}
