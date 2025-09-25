using SalesAnalysisETL.Application.Interfaces;

namespace SalesAnalysisETL.Application.Services
{
    public class CsvExtractor<T> : IExtractor<T>
    {
        private readonly Func<string[], T> _mapFunc;

        public CsvExtractor(Func<string[], T> mapFunc)
        {
            _mapFunc = mapFunc;
        }

        public IEnumerable<T> Extraer(string rutaArchivo)
        {
            var lineas = File.ReadAllLines(rutaArchivo).Skip(1);
            foreach (var linea in lineas)
            {
                var columnas = linea.Split(',');
                yield return _mapFunc(columnas);
            }
        }
    }
}