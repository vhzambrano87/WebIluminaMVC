using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LightInject;
using System.Reflection;

namespace WebIluminaMVC
{
	public partial class Startup
	{
        public void ConfigInjector()
        {
            var container = new ServiceContainer();
            container.RegisterAssembly(Assembly.GetExecutingAssembly());
            container.RegisterAssembly("WebIluminaMVC.DataAccess*.dll");
            container.RegisterAssembly("WebIluminaMVC.Model*.dll");
            container.RegisterControllers();
            container.EnableMvc();
        }
    }
}