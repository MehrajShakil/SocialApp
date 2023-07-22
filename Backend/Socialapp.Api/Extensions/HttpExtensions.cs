using Socialapp.Api.Helpers;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Socialapp.Api.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, PaginationHeader paginationHeader)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy= JsonNamingPolicy.CamelCase
            };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, jsonOptions));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
