using Sales_Date_Prediction_.DTO_s;

namespace Sales_Date_Prediction_.Utilidades
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Paginar<T>(this IEnumerable<T> lista, PaginacionDTO paginacionDTO)
        {
            return lista.Skip((paginacionDTO.pagina - 1) * paginacionDTO.RegistrosPorPagina)
                        .Take(paginacionDTO.RegistrosPorPagina);
                        
        }
    }
}
