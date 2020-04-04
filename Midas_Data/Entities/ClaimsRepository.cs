using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Midas_Data.Entities
{
    public class ClaimsRepository
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Can Create User", "CanCreateUser"),
            new Claim("Can Create Role", "CanCreateRole"),
            new Claim("Can Assign Claim", "CanAssignClaim"),

        };
    }
}
