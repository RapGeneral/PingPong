using Autofac;
using ImpromptuInterface;
using PingPong.Board.Contracts;
using PingPong.Core.Contracts;
using PingPong.Game;
using PingPong.Providers.Contracts;
using System;
using System.Dynamic;
using System.Reflection;

namespace PingPong.Core.Injection
{
    public sealed class AutofacConfig
    {
        private IContainer container;

        private IContainer Container
        {
            get
            {
                if (this.container == null)
                {
                    throw new InvalidOperationException("You must first build the container before accessing it!");
                }

                return this.container;
            }
        }
        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(Engine)));
            builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(Classic)));
            builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(IBoardFactory)));
            builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(IDisplay)));

            this.RegisterDynamicParser(builder);

            this.container = builder.Build();
            return this.container;
        }

        private delegate bool FuncWithOut(string commandName, Type type, out object command);
        private void RegisterDynamicParser(ContainerBuilder builder)
        {
            dynamic parserProxy = new ExpandoObject();

            Func<string, Type, (bool, object)> methodBody = (commandName, type) => (this.Container.TryResolveNamed(commandName, type, out object instance), instance);

            parserProxy.TryParseCommand = methodBody;

            ICommandParser parserShell = Impromptu.ActLike<ICommandParser>(parserProxy);

            builder.RegisterInstance(parserShell).As<ICommandParser>();
            
        }
    }
}
