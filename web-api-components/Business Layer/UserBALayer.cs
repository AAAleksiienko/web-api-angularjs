using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api_components.DTO;

namespace web_api_components.Models
{
    public class UserBALayer
    {
        public List<UserDTO> findAll()
        {
            using (appstoreEntities1 db = new appstoreEntities1())
            {
                return db.Users.ToList().Select(p => new UserDTO(p)).ToList();
            }
        }

        public UserDTO addUser(UserDTO user)
        {
            using (appstoreEntities1 db = new appstoreEntities1())
            {
                var result = db.Users.SingleOrDefault(p => p.Name == user.Name);
                if (result == null)
                {
                    var rec = UserDTO.Convert(user);
                    db.Users.Add(rec);
                    db.SaveChanges();
                    return user;
                }

                return new UserDTO { };
            }
        }

        
        public UserDTO login(UserDTO user)
        {
            using (appstoreEntities1 db = new appstoreEntities1())
            {
                var result = db.Users.SingleOrDefault(p => p.Name == user.Name);
                if (result != null && result.Password == user.Password)
                {
                    return new UserDTO(result);
                }
                return new UserDTO { };
            }
        }


    }
}