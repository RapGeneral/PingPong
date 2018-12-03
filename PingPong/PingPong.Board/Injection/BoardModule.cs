using Autofac;
using PingPong.Board.Contracts;
using PingPong.Board.Factories;
using System.Reflection;

namespace PingPong.Board.Injection
{
	public class BoardModule : Autofac.Module
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
			builder.RegisterType<BoardFactory>().As<IBoardFactory>().SingleInstance();
		}
	}
}
