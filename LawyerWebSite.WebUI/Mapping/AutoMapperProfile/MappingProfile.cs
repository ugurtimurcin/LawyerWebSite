using AutoMapper;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Mapping.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUserEditDto, AppUser>().ReverseMap();
            CreateMap<AppUserListDto, AppUser>().ReverseMap();
            CreateMap<AppUserLoginDto, AppUser>().ReverseMap();
            CreateMap<AppUserRegisterDto, AppUser>().ReverseMap();
            CreateMap<AppUserUpdatePasswordDto, AppUser>().ReverseMap();
            CreateMap<ArticleAddDto, Article>().ReverseMap();
            CreateMap<ArticleEditDto, Article>().ReverseMap();
            CreateMap<ArticleListDto, Article>().ReverseMap();
            CreateMap<CategoryAddDto, Category>().ReverseMap();
            CreateMap<CategoryAllListDto, Category>().ReverseMap();
            CreateMap<CategoryEditDto, Category>().ReverseMap();
            CreateMap<CategoryListDto, Category>().ReverseMap();
            CreateMap<WorkAreaAddDto, WorkArea>().ReverseMap();
            CreateMap<WorkAreaEditDto, WorkArea>().ReverseMap();
            CreateMap<WorkAreaListDto, WorkArea>().ReverseMap();
        }
    }
}
