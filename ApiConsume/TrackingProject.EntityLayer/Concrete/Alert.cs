namespace TrackingProject.EntityLayer.Concrete
{
    public class Alert
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
    }
}
