using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Sales_Date_Prediction_.Utilidades
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacionCabecera<T>(this HttpContext httpContext, IEnumerable<T> queriyable)
        {
            if(httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            double cantidad =  queriyable.Count();
            httpContext.Response.Headers.Append("Cantidad-Total-Registros", cantidad.ToString());
        }
    }
}
