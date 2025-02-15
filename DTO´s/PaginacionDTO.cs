namespace Sales_Date_Prediction_.DTO_s
{
    public class PaginacionDTO
    {
        public int pagina { get; set; } = 1;
        private int registrosPorPagina = 10;
        private readonly int cantidadMaximaRegistros = 50;
        public int RegistrosPorPagina
        {
            get { return registrosPorPagina; }
            set
            {
                registrosPorPagina = (value > cantidadMaximaRegistros)? cantidadMaximaRegistros : value;
            }
        }
    }
}
