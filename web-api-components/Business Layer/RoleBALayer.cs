using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api_components.DTO;

namespace web_api_components.Models
{
    public class RoleBALayer
    {
        public List<RoleDTO> findAll()
        {
            using (appstoreEntities1 db = new appstoreEntities1())
            {
                return db.Roles.ToList().Select(p => new RoleDTO(p)).ToList();
            }
        }
    }
}