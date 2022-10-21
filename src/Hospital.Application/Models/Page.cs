namespace Hospital.Application.Models
{
    public struct Page
    {
        public int PageSize { get; } = 2;
        public int PageIndex { get; set; } = 0;

        public Page(int number) : this() => PageIndex = number;

        public int FirstRow() => PageIndex * PageSize;
        public int LastRow() => PageIndex * PageSize + PageSize - 1;
    }
}
