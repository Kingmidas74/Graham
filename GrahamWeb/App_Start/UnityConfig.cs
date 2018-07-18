using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrahamAlg;
using Unity;
using Unity.Exceptions;
using Unity.Mvc5;

namespace GrahamWeb.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<SortFactory>();
            container.RegisterType<PointCreator>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}