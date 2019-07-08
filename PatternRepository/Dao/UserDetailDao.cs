using System;
using System.Collections.Generic;
using EF_Repo.PatternRepository;
using AutoMapper;
using AdoNetEntity;
using EF_Repo.Dto;
using PatternRepository.Specification.EntitiesSpecifications;

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

        public IReadOnlyList<UserDetailDto> GetUsersAll()
        {
            mapper = configMapDbToDto.CreateMapper();
            var all = new UserDetailAllSpecifications();
            return mapper.Map<IReadOnlyList<UserDetails>, IReadOnlyList<UserDetailDto>>(repository.GetAll(all));
        }

        public IReadOnlyList<UserDetailDto> GetUsersName(string name)
        {
            mapper = configMapDbToDto.CreateMapper();
            var userxName = new UserDetailxNombreSpecifications(name);
            return mapper.Map<IReadOnlyList<UserDetails>, IReadOnlyList<UserDetailDto>>(repository.GetAll(userxName));
        }

        public IReadOnlyList<UserDetailDto> GetUsersEmail(string email)
        {
            mapper = configMapDbToDto.CreateMapper();
            var userxEmail = new UserDetailxEmailSpecifications(email);
            return mapper.Map<IReadOnlyList<UserDetails>, IReadOnlyList<UserDetailDto>>(repository.GetAll(userxEmail));
        }

        public IReadOnlyList<UserDetailDto> GetUsersCity(string city)
        {
            mapper = configMapDbToDto.CreateMapper();
            var userxCity = new UserDetailxCitySpecifications(city);
            return mapper.Map<IReadOnlyList<UserDetails>, IReadOnlyList<UserDetailDto>>(repository.GetAll(userxCity));
        }

        public IReadOnlyList<UserDetailDto> GetUsersCityAndName(string city, string name)
        {
            mapper = configMapDbToDto.CreateMapper();
            var userxCityAndName = new UserDetailxCitySpecifications(city).And(new UserDetailxNombreSpecifications(name));
            return mapper.Map<IReadOnlyList<UserDetails>, IReadOnlyList<UserDetailDto>>(repository.GetAll(userxCityAndName));
        }

        public bool ValidMail(string mail, UserDetailDto userDetailDto)
        {
            mapper = configMapDtoToDb.CreateMapper();
            var userxCity = new UserDetailValidMailSpecifications(mail);
            return userxCity.IsSatisfiedBy(mapper.Map<UserDetails>(userDetailDto));
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
