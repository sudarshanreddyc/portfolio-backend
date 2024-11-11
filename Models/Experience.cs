namespace Portfolio.Models
{
    public class Experience
    {
        public int Id { get; set; } 
        public string? JobTitle { get; set; } 
        public string? Company { get; set; }
        public string? Responsibilities { get; set; }
        public DateTime FromDate { get; set; } 
        public DateTime ToDate { get; set; } 
    }
}
