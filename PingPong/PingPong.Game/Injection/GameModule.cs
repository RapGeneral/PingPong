using Autofac;
using PingPong.Game.Contracts;
using System.Reflection;

namespace PingPong.Game.Injection
{
	public class GameModule : Autofac.Module
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
			builder.RegisterType<GameParameters>().As<IGameParameters>().SingleInstance();
		}
	}
}
