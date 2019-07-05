using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFusePatternRepository.Models
{
    public class UserDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string City { get; set; }
        public string PhoneNo { get; set; }
        public string PinCode { get; set; }
    }
}