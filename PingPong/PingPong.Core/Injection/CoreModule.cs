using Autofac;
using System.Linq;
using PingPong.Core.BigText;
using PingPong.Core.Contracts;
using PingPong.Core.Factories;
using PingPong.Core.Menus.GameMenus;
using PingPong.Core.Menus.ShopMenus;
using System.Reflection;

namespace PingPong.Core.Injection
{
    public class CoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();

            this.RegisterCoreComponents(builder);
            this.RegisterCommands(builder);

            base.Load(builder);
        }

        private void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.RegisterType<Engine>().AsSelf().SingleInstance();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
            builder.RegisterType<ChoiceFactory>().As<IChoiceFactory>().SingleInstance();
            builder.RegisterType<Shop>().As<IShop>().SingleInstance();
            builder.RegisterType<BigWords>().As<IBigWords>().SingleInstance();
			builder.RegisterGeneric(typeof(GameMenu<>)).As(typeof(IGameMenu<>)).SingleInstance();
			builder.RegisterGeneric(typeof(ShopItemMenu<>)).As(typeof(IShopItemMenu<>)).SingleInstance();
		}

        public void RegisterCommands(ContainerBuilder builder)
        {
			Assembly assmebly = Assembly.GetAssembly(typeof(ICommand));

			var commandTypes = assmebly.DefinedTypes
								.Where(x => x.ImplementedInterfaces
									.Any(i => i == typeof(ICommand)))
								.Where(x => !x.IsAbstract);
			foreach (var commandType in commandTypes)
			{
				builder.RegisterType(commandType.UnderlyingSystemType)
					.Named<ICommand>(commandType.Name
										.ToLower()
										.Substring(7))
					.SingleInstance();
			}
		}
	}
}
