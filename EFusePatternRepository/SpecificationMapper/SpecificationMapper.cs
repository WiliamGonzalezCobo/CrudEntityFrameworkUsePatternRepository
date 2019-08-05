using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Repo.Dto;
using EFusePatternRepository.Models;

namespace EFusePatternRepository.SpecificationMapper
{
    public static class SpecificationMapper
    {
        public static MapperConfiguration UserDetailDtoToModel { get { return new MapperConfiguration(cfg => cfg.CreateMap<UserDetailDto, UserDetailModel>().ForMember(d => d.Id, opt => opt.MapFrom(src => src.IdUserDetail))); } }
        public static MapperConfiguration UserDetailModelToDto { get { return new MapperConfiguration(cfg => cfg.CreateMap<UserDetailModel, UserDetailDto>().ForMember(d => d.IdUserDetail, opt => opt.MapFrom(src => src.Id))); } }
    }
}
