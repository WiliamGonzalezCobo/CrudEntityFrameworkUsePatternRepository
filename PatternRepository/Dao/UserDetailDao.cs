using System;
using System.Collections.Generic;
using EF_Repo.PatternRepository;
using AutoMapper;
using AdoNetEntity;
using EF_Repo.Dto;

namespace PatternRepository.Dao
{
    public class UserDetailDao
    {
        private Repository<UserDetails> repository { get; set; }
        private MapperConfiguration configMapDbToDto;
        private MapperConfiguration configMapDtoToDb;
        private IMapper mapper;
        public UserDetailDao()
        {
            repository = new Repository<UserDetails>();
            configMapDbToDto = new MapperConfiguration(cfg => cfg.CreateMap<UserDetails, UserDetailDto>());
            configMapDtoToDb = new MapperConfiguration(cfg => cfg.CreateMap<UserDetailDto, UserDetails>());
        }

        public IEnumerable<UserDetailDto> GetUsersAll()
        {
            mapper = configMapDbToDto.CreateMapper();
            return mapper.Map<IEnumerable<UserDetails>, IEnumerable<UserDetailDto>>(repository.GetAll());
        }

        public void AddUser(UserDetailDto userDto)
        {
            mapper = configMapDtoToDb.CreateMapper();
            repository.Add(mapper.Map<UserDetails>(userDto));
            repository.Save();
            repository.Dispose();
        }

        public void UpdateUser(UserDetailDto userDto)
        {
            mapper = configMapDtoToDb.CreateMapper();
            repository.Update(mapper.Map<UserDetails>(userDto));
            repository.Save();
            repository.Dispose();
        }

        public UserDetailDto GetUserById(int id)
        {
            mapper = configMapDbToDto.CreateMapper();
            return mapper.Map<UserDetailDto>(repository.GetById(id));
        }

        public void DeleteUser(int id)
        {
            repository.Delete(id);
            repository.Save();
            repository.Dispose();
        }
    }
}
