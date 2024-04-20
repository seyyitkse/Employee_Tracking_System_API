using AutoMapper;
using TrackingProject.DtoLayer.Dtos.AnnouncementDto;
using TrackingProject.DtoLayer.Dtos.ApplicationUserDto;
using TrackingProject.EntityLayer.Concrete;
using TrackingProject.WebApi.Dtos.AnnouncementDto;

namespace TrackingProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultsAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<CreatedAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<UpdatedAnnouncementDto, Announcement>().ReverseMap();

            CreateMap<CreateApplicationUserDto, ApplicationUser>().ReverseMap();
            CreateMap<LoginApplicationUserDto, ApplicationUser>().ReverseMap();
            
            //CreateMap<RegisterPanelUserDto, PanelUser>().ReverseMap();
            //CreateMap<ResultPanelUserDto, PanelUser>().ReverseMap();
            //CreateMap<UpdatePanelUserDto, PanelUser>().ReverseMap();

        }
    }
}
