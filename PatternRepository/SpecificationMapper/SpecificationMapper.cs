using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetEntity;
using EF_Repo.Dto;

namespace PatternRepository.SpecificationMapper
{
    public static class SpecificationMapper
    {
        public static MapperConfiguration UserDetailToDto { get { return new MapperConfiguration(cfg => cfg.CreateMap<UserDetails, UserDetailDto>().ForMember(d => d.IdUserDetail, opt => opt.MapFrom(src => src.Id))); } }

        public static MapperConfiguration UserDtoToDetail { get { return new MapperConfiguration(cfg => cfg.CreateMap<UserDetailDto, UserDetails>().ForMember(d => d.Id, opt => opt.MapFrom(src => src.IdUserDetail))); } }
    }
}
