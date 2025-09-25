namespace SalesAnalysisETL.Domain.Entities
{
    public class FuenteDatos
    {
        public int IdFuente { get; set; }
        public string TipoFuente { get; set; } = string.Empty;
        public DateTime FechaCarga { get; set; }
    }
}
