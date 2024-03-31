namespace TrackingProject.WebUI.Dtos.AnnouncementDto
{
    public class ResultAnnouncementDto
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public int TypeID { get; set; }
    }
}
