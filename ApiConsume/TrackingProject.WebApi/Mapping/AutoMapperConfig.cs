using AutoMapper;
using TrackingProject.DtoLayer.Dtos.AnnouncementDto;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<CreateAnnouncementDto,Announcement>().ReverseMap();
            CreateMap<UpdateAnnouncementDto,Announcement>().ReverseMap();
        }
    }
}
