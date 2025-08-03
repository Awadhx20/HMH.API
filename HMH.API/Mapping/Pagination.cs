namespace HMH.API.Mapping
{
    public class Pagination<T>where T :class
    {
        public Pagination(int pageSize, int pageNumber, int totoalCount, IEnumerable<T> data)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotoalCount = totoalCount;
            Data = data;
        }

        public int PageSize { get; set; }
        public int PageNumber {get;set; }
        public int TotoalCount { get; set; }
        public IEnumerable<T> Data { get; set; }

    }
}
