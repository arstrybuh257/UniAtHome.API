namespace UniAtHome.BLL.Models.Filters
{
    public class CoursesFilter
    {
        public string SearchText { get; set; }

        public int PageNum { get; set; }

        public int PageSize { get; set; }

        public string UserEmail { get; set; }
    }
}
