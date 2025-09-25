namespace SalesAnalysisETL.Application.Interfaces
{
    public interface IExtractor<T>
    {
        IEnumerable<T> Extraer(string rutaArchivo);
    }
}
