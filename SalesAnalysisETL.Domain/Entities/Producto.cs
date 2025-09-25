﻿namespace SalesAnalysisETL.Domain.Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}
