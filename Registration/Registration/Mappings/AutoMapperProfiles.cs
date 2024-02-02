using AutoMapper;
using Registration.Models.Domain;
using Registration.Models.DTO;

namespace Registration.Mappings
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<AddBranchRequestDto, Branch>().ReverseMap();
            CreateMap<UpdateBranchRequestDto, Branch>().ReverseMap();
            CreateMap<AddUserRequestDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<AddCompanyRequestDto, Company>().ReverseMap();
            CreateMap<UpdateCompanyRequestDto, Company>().ReverseMap();
            CreateMap<UpdateUserRequestDto, User>().ReverseMap(); 
        }
    }
}
