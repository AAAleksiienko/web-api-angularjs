using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api_AngularJs.Data_Access_Layer;

namespace Web_Api_AngularJs.Business_Layer
{
    public class UserBA
    {

        public List<UserDA> findAll()
        {
            using (appstoreEntities db = new appstoreEntities())
            {
                return db.Users.ToList().Select(p => new UserDA(p)).ToList();
            }
        }

        public UserDA addUser(UserDA user)
        {
            using (appstoreEntities db = new appstoreEntities())
            {
                var result = db.Users.SingleOrDefault(p => p.Name == user.Name);
                if (result == null)
                {
                    var rec = UserDA.Convert(user);
                    db.Users.Add(rec);
                    db.SaveChanges();
                    return user;
                }

                return new UserDA { };
            }
        }


        public UserDA login(UserDA user)
        {
            using (appstoreEntities db = new appstoreEntities())
            {
                var result = db.Users.SingleOrDefault(p => p.Name == user.Name);
                if (result != null && result.Password == user.Password)
                {
                    return new UserDA(result);
                }
                return new UserDA { };
            }
        }


    }
}