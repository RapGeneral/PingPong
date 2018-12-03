using Autofac;
using PingPong.Providers.Contracts;
using PingPong.Providers.Data;
using PingPong.Providers.Display;
using PingPong.Providers.Keyboard;
using System.Reflection;

namespace PingPong.Providers.Injection
{
	public class ProvidersModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.AsImplementedInterfaces();

			this.RegisterCoreComponents(builder);

			base.Load(builder);
		}

		private void RegisterCoreComponents(ContainerBuilder builder)
		{
			builder.RegisterType<ConsoleDisplay>().As<IDisplay>().SingleInstance();
			builder.RegisterType<ConsoleKeyReader>().As<IKeyReader>().SingleInstance();
			builder.RegisterType<FileWriter>().As<IDataWriter>().SingleInstance();
			builder.RegisterType<FileReader>().As<IDataReader>().SingleInstance();
		}
	}
}
