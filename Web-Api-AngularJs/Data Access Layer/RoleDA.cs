using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api_AngularJs.Data_Access_Layer
{
    public class RoleDA
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public RoleDA(){}

        public RoleDA(Role pd)
        {
            Id = pd.Id;
            Name = pd.Name;
        }
    }
}