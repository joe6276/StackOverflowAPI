namespace StackOverflowAPI.Repositories.Pagination
{
    public class PaginationMetadata
    {

        public int TotalIntemCount { get; set; }

        public int TotalPageCount { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public PaginationMetadata(int totalIntemCount, int pageSize, int currentPage)
        {
            TotalIntemCount = totalIntemCount;
            TotalPageCount = (int) Math.Ceiling(totalIntemCount/(double) pageSize);
            PageSize = pageSize;
            CurrentPage = currentPage;
        }
    }
}
