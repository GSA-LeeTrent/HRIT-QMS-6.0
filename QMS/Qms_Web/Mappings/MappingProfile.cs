using AutoMapper;
using Qms_Data.ViewModels;
using QmsCore.Model;

namespace Qms_Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMapProfiles();
        }

        private void CreateMapProfiles()
        {
            CreateMap<SecUser, UserAdminFormVM>().ReverseMap();
        }
    }
}
