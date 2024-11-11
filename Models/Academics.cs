namespace Portfolio.Models
{
    public class Academics
    {
        public int Id { get; set; } 
        public string? School { get; set; } 
        public decimal Percentage { get; set; } 
        public string? Level { get; set; } 
        public DateTime FromDate { get; set; } 
        public DateTime ToDate { get; set; } 
    }
}
