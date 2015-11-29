using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;


namespace TagCloud
{
	class Program
	{
		static void Main(string[] args)
		{
			var kernel = new Ninject.StandardKernel();
			kernel.Bind<CommandLineArgs>().ToConstant(new CommandLineArgs(args));
			kernel.Bind<Config>().ToConstant(new Config(kernel.Get<CommandLineArgs>().ConfigFile));
			kernel.Bind<IFileParser>().To<SimpleFileParser>();
			kernel.Bind<IApplication>().To<ConsoleApp>();
			kernel.Get<IApplication>().Start();
		}

	}
}
