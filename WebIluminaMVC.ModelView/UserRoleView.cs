using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.ModelView
{
    public class UserRoleView
    {
        public User user { get; set; }
        public IList<UserRole> userRoleList { get; set; }
        public IList<Role> roles  { get; set; }
    }
}
