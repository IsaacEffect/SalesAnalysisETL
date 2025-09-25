using SalesAnalysisETL.Application.Interfaces;

namespace SalesAnalysisETL.Application.Services
{
    public class Pipeline<T>
    {
        private readonly IExtractor<T> _extractor;
        private readonly ITransformador<T> _transformador;
        private readonly ILoader<T> _loader;

        public Pipeline(IExtractor<T> extractor, ITransformador<T> transformador, ILoader<T> loader)
        {
            _extractor = extractor;
            _transformador = transformador;
            _loader = loader;
        }

        public void Ejecutar(string rutaArchivo)
        {
            var extraidos = _extractor.Extraer(rutaArchivo);
            var transformados = _transformador.Transformar(extraidos);
            _loader.Cargar(transformados);
        }
    }
}
