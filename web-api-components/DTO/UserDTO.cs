using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_components.DTO
{
    public class UserDTO
    {
        public int ?Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public UserDTO() {}

        public UserDTO(Users ur)
        {
            Id = ur.Id;
            Name = ur.Name;
            Password = ur.Password;
            Role = ur.Role;
        }

        public static Users Convert(UserDTO ud)
        {

            return Update(new Users(), ud);
        }

        public static Users Update(Users ud, UserDTO udDTO)
        {
            ud.Id = udDTO.Id.GetValueOrDefault();
            ud.Name = udDTO.Name;
            ud.Password = udDTO.Password;
            ud.Role = 2;
            return ud;
        }

    }
}