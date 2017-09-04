using System;

using Autofac;

using WebJob.Settings;

namespace WebJob.Functions
{
    /// <summary>
    /// This represents the module entity for Autofac to register dependencies.
    /// </summary>
    public class WebJobModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            RegisterSettings(builder);
            RegisterFunction(builder);
        }

        private static void RegisterSettings(ContainerBuilder builder)
        {
            builder.RegisterType<WebJobConfigurationSettings>()
                   .As<IWebJobSettings>()
                   .SingleInstance();
        }

        private static void RegisterFunction(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IFunction).Assembly)
                   .Where(t => t.Name.EndsWith("Function", StringComparison.CurrentCultureIgnoreCase))
                   .AsSelf()
                   .OnActivating(p => ((FunctionBase)p.Instance)
                                          .SetWebJobSettings(p.Context.Resolve<IWebJobSettings>()))
                   .InstancePerDependency();
        }
    }
}