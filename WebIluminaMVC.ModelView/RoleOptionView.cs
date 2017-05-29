using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.ModelView
{
    public class RoleOptionView
    {
        public Role role { get; set; }
        public IList<RoleOption> roleOptionList { get; set; }
        public IList<Option> options { get; set; }
    }
}
