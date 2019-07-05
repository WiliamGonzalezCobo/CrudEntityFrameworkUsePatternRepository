using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Repo.Dto
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string City { get; set; }
        public string PhoneNo { get; set; }
        public string PinCode { get; set; }
    }
}
