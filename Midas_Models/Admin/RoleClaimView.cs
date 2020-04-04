using System;
using System.Collections.Generic;
using System.Text;

namespace Midas_Models.Admin
{
    public class RoleClaimView
    {
        public RoleClaimView()
        {
            Claims = new List<RoleClaim>();
        }

        public string RoleId { get; set; }
        public List<RoleClaim> Claims { get; set; }
    }
}
