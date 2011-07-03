using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace FubuCore.StructureMap.ConsoleTestApp
{
    public class SampleSettings
    {
        /// <summary>
        /// Initializes a new instance of the SampleSettings class.
        /// </summary>
        public SampleSettings()
        {
            Message = "Configure me!";
        }

        public string Message { get; set; }
    }

    public class SampleController
    {
        SampleSettings settings;

        /// <summary>
        /// Initializes a new instance of the SampleController class.
        /// </summary>
        /// <param name="settings"></param>
        public SampleController(SampleSettings settings)
        {
            this.settings = settings;
        }

        public void SampleAction()
        {
            Console.WriteLine(settings.Message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ObjectFactory.Configure(cfg =>
            {
                cfg.Scan(a =>
                {
                    a.TheCallingAssembly();

                    a.AssemblyContainingType<FubuCore.StructureMap.SettingsScanner>();
                    a.LookForRegistries();

                    a.Convention<SettingsScanner>();
                });
            });

            var controller = ObjectFactory.Container.GetInstance<SampleController>();

            controller.SampleAction();
        }
    }
}
