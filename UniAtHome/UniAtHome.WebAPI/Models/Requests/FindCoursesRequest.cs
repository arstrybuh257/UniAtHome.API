namespace UniAtHome.WebAPI.Models.Requests
{
    public class FindCoursesRequest
    {
        public string SearchText { get; set; }

        public int PageNum { get; set; }

        public int PageSize { get; set; }
    }
}
