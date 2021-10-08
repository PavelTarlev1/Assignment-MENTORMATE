using Assignment_2.Model;
using AutoMapper;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // RegisterRequest -> RoomModel
            CreateMap<RegisterRequest, RoomModel>();
            // CheckRoomRequest -> CheckRoom
            CreateMap<CheckRoomRequest, CheckRoom>();
        }
    }
}