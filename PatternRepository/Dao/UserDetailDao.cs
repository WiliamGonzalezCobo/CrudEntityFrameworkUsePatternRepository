using System;
using System.Collections.Generic;
using EF_Repo.PatternRepository;
using AdoNetEntity;
using EF_Repo.Dto;
using PatternRepository.Specification.EntitiesSpecifications;
using EF_Repo.Utils.MapperBase;
using AutoMapper;


namespace PatternRepository.Dao
{
    public class UserDetailDao
    {
        private Repository<UserDetails> repository { get; set; }
        public UserDetailDao()
        {
            repository = new Repository<UserDetails>();
        }

        public IReadOnlyList<UserDetailDto> GetUsersAll()
        {
            var all = new UserDetailAllSpecifications();
            return MapperConfigurationCentral<UserDetails, UserDetailDto>.MapList(repository.GetAll(all), SpecificationMapper.SpecificationMapper.UserDetailToDto);
        }

        public IReadOnlyList<UserDetailDto> GetUsersName(string name)
        {
            var userxName = new UserDetailxNombreSpecifications(name);
            return MapperConfigurationCentral<UserDetails, UserDetailDto>.MapList(repository.GetAll(userxName),SpecificationMapper.SpecificationMapper.UserDetailToDto);
        }

        public IReadOnlyList<UserDetailDto> GetUsersEmail(string email)
        {
            var userxEmail = new UserDetailxEmailSpecifications(email);
            return MapperConfigurationCentral<UserDetails, UserDetailDto>.MapList(repository.GetAll(userxEmail),SpecificationMapper.SpecificationMapper.UserDetailToDto);
        }

        public IReadOnlyList<UserDetailDto> GetUsersCity(string city)
        {
            var userxCity = new UserDetailxCitySpecifications(city);
            return MapperConfigurationCentral<UserDetails, UserDetailDto>.MapList(repository.GetAll(userxCity),SpecificationMapper.SpecificationMapper.UserDetailToDto);
        }

        public IReadOnlyList<UserDetailDto> GetUsersCityAndName(string city, string name)
        {
            var userxCityAndName = new UserDetailxCitySpecifications(city).And(new UserDetailxNombreSpecifications(name));
            return MapperConfigurationCentral<UserDetails, UserDetailDto>.MapList(repository.GetAll(userxCityAndName),SpecificationMapper.SpecificationMapper.UserDetailToDto);
        }

        public bool ValidMail(string mail, UserDetailDto userDetailDto)
        {
            var userxCity = new UserDetailValidMailSpecifications(mail);
            return userxCity.IsSatisfiedBy(MapperConfigurationCentral<UserDetailDto, UserDetails>.MapEntity(userDetailDto));
        }

        public void AddUser(UserDetailDto userDto)
        {
            repository.Add(MapperConfigurationCentral<UserDetailDto, UserDetails>.MapEntity(userDto, SpecificationMapper.SpecificationMapper.UserDtoToDetail));
            repository.Save();
            repository.Dispose();
        }

        public void UpdateUser(UserDetailDto userDto)
        {
            repository.Update(MapperConfigurationCentral<UserDetailDto, UserDetails>.MapEntity(userDto,SpecificationMapper.SpecificationMapper.UserDtoToDetail));
            repository.Save();
            repository.Dispose();
        }

        public UserDetailDto GetUserById(int id)
        {
            return MapperConfigurationCentral<UserDetails, UserDetailDto>.MapEntity(repository.GetById(id),SpecificationMapper.SpecificationMapper.UserDetailToDto);
        }

        public void DeleteUser(int id)
        {
            repository.Delete(id);
            repository.Save();
            repository.Dispose();
        }
    }
}
