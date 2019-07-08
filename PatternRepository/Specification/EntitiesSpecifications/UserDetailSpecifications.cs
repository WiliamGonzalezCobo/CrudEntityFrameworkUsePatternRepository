using PatternRepository.Specification;
using AdoNetEntity;
using System.Linq.Expressions;
using System;

namespace PatternRepository.Specification.EntitiesSpecifications
{
    public class UserDetailAllSpecifications : Specification<UserDetails>
    {
        public override Expression<Func<UserDetails, bool>> ToExpression()
        {
            return userDetail => userDetail.Id == userDetail.Id;
        }
    }

    public class UserDetailxEmailSpecifications : Specification<UserDetails>
    {
        private readonly string _email;

        public UserDetailxEmailSpecifications(string email)
        {
            _email = email;
        }
        public override Expression<Func<UserDetails, bool>> ToExpression()
        {
            return userDetail => userDetail.EmailId.Equals(_email);
        }
    }

    public class UserDetailxCitySpecifications : Specification<UserDetails>
    {
        private readonly string _city;

        public UserDetailxCitySpecifications(string city)
        {
            _city = city;
        }
        public override Expression<Func<UserDetails, bool>> ToExpression()
        {
            return userDetail => userDetail.City.Equals(_city);
        }
    }

    public class UserDetailxNombreSpecifications : Specification<UserDetails>
    {
        private readonly string _nombre;

        public UserDetailxNombreSpecifications(string nombre)
        {
            _nombre = nombre;
        }
        public override Expression<Func<UserDetails, bool>> ToExpression()
        {
            return userDetail => userDetail.Name.Contains(_nombre);
        }
    }

    public class UserDetailValidMailSpecifications : Specification<UserDetails>
    {
        private readonly string _mail;

        public UserDetailValidMailSpecifications(string mail)
        {
            _mail = mail;
        }
        public override Expression<Func<UserDetails, bool>> ToExpression()
        {
            return userDetail => userDetail.EmailId.Equals(_mail);
        }
    }
}
