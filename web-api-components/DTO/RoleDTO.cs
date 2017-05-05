using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_components.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RoleDTO()
        {

        }

        public RoleDTO(Roles pd)
        {
            Id = pd.Id;
            Name = pd.Name;
        }
    }
}