namespace Socialapp.Api.Helpers
{
    public class PaginationHeader
    {
        public PaginationHeader(int currentPage, int itemPerPage, int totalItems, int totalpages)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemPerPage;
            TotalItems = totalItems;
            Totalpages = totalpages;
        }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int Totalpages { get; set; }
    }
}
