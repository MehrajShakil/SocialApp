using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Socialapp.Api.Helpers
{
    public class PagedList<TDto> : List<TDto>
    {
        public PagedList(IEnumerable<TDto> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (count+pageSize-1)/pageSize;
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public static async Task<PagedList<TDto>> CreateAsync(IQueryable<TDto> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<TDto>(items, count, pageNumber, pageSize);
        }
    }
}
