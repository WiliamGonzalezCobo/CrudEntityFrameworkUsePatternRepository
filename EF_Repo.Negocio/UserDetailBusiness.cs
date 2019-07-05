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

        public IEnumerable<UserDetailDto> GetUsersAll()
        {
            return userDetailDao.GetUsersAll();
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
