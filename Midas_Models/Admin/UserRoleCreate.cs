using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.Admin
{
    public class UserRoleCreate
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

    }
}
