using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.Admin
{
    public class RoleEdit
    {
        public RoleEdit()
        {
            Users = new List<string>();
            Claims = new List<string>();
        }
        public string Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
        public List<string> Claims { get; set; }
    }
}
