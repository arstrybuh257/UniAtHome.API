namespace UniAtHome.BLL.Models.Filters
{
    public abstract class CoursesFilter
    {
        public string SearchText { get; set; }

        public int PageNum { get; set; }

        public int PageSize { get; set; }
    }
}
