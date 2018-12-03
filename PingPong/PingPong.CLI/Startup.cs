namespace PingPong.CLI
{
    using Autofac;
	using PingPong.Core;
    using PingPong.Core.Contracts;
    using PingPong.Core.Injection;

    static class Startup
    {
        static void Main()
        {
            var containerConfig = new AutofacConfig();
            var container = containerConfig.Build();

            var engine = container.Resolve<Engine>();
            engine.Start();
        }
    }
}
