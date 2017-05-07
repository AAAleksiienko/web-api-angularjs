using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api_AngularJs.Data_Access_Layer
{
    public class UserDA
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public UserDA() { }

        public UserDA(User ur)
        {
            Id = ur.Id;
            Name = ur.Name;
            Password = ur.Password;
            Role = ur.Role;
        }

        public static User Convert(UserDA ud)
        {

            return Update(new User(), ud);
        }

        public static User Update(User ud, UserDA udDTO)
        {
            ud.Id = udDTO.Id.GetValueOrDefault();
            ud.Name = udDTO.Name;
            ud.Password = udDTO.Password;
            ud.Role = 2;
            return ud;
        }
    }
}