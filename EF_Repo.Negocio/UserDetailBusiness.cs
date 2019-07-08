using System.Collections.Generic;
using EF_Repo.Dto;
using PatternRepository.Dao;


namespace EF_Repo.Negocio
{
    public class UserDetailBusiness
    {
        UserDetailDao userDetailDao;
        public UserDetailBusiness()
        {
            userDetailDao = new UserDetailDao();
        }

        public IReadOnlyList<UserDetailDto> GetUsersAll()
        {
            return userDetailDao.GetUsersAll();
        }

        public IReadOnlyList<UserDetailDto> GetUsersEmail(string email)
        {
            return userDetailDao.GetUsersEmail(email);
        }

        public IReadOnlyList<UserDetailDto> GetUsersName(string name)
        {
            return userDetailDao.GetUsersName(name);
        }

        public IReadOnlyList<UserDetailDto> GetUsersCity(string city)
        {
            return userDetailDao.GetUsersCity(city);
        }

        public IReadOnlyList<UserDetailDto> GetUsersCityAndName(string city,string name)
        {
            return userDetailDao.GetUsersCityAndName(city, name);
        }

        public bool ValidMail(string mail, UserDetailDto userDto)
        {
            return userDetailDao.ValidMail(mail, userDto);
        }

        public void AddUser(UserDetailDto userDto)
        {
            userDetailDao.AddUser(userDto);
        }

        public void UpdateUser(UserDetailDto userDto)
        {
            userDetailDao.UpdateUser(userDto);
        }

        public UserDetailDto GetUserById(int id)
        {
            return userDetailDao.GetUserById(id);
        }

        public void DeleteUser(int id)
        {
            userDetailDao.DeleteUser(id);
        }
    }
}
