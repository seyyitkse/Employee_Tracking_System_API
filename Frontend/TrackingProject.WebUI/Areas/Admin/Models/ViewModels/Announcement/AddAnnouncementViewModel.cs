namespace TrackingProject.WebUI.Areas.Admin.Models.ViewModels.Announcement
{
    public class AddAnnouncementViewModel
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public int TypeID { get; set; }
    }
}
