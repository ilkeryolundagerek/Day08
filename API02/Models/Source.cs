namespace API02.Models
{
    public class Source
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total_pages { get; set; }
        public int total { get; set; }
        public User[] data { get; set; }
    }
    public class SourceSingle
    {
        public User data { get; set; }
    }
}
