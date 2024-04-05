using AutoMapper;
using TrackingProject.DtoLayer.Dtos.AnnouncementDto;
using TrackingProject.DtoLayer.Dtos.PanelUserDto;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<CreateAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<UpdateAnnouncementDto, Announcement>().ReverseMap();
            
            //CreateMap<RegisterPanelUserDto, PanelUser>().ReverseMap();
            //CreateMap<ResultPanelUserDto, PanelUser>().ReverseMap();
            //CreateMap<UpdatePanelUserDto, PanelUser>().ReverseMap();

        }
    }
}
