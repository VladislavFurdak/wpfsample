using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Graph;

namespace ReferenceData.Config
{
    public static class Registration
    {
        public static void RegisterAll()
        {
        ObjectFactory.Initialize(x =>
        {
            x.Scan(s =>
           {
               s.TheCallingAssembly();
           });
        });
            //ObjectFactory.Initialize(cfg =>
            //{
            //    cfg.Scan(assembly =>
            //    {
            //        assembly.TheCallingAssembly();
            //        assembly.LookForRegistries();
            //    });
            //});
        }
    }
}
