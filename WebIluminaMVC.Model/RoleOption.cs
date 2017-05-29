using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIluminaMVC.Model
{
    public class RoleOption
    {
        public int roleOptionID { get; set; }
        public int roleID { get; set; }
        public int optionID { get; set; }
        public virtual Role role { get; set; }
        public virtual Option option { get; set; }
    }
}
