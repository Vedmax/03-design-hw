using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Ninject;


namespace TagCloud
{
	class Program
	{
		static void Main(string[] args)
		{
			var options = new CommandLineArgs();
			Parser.Default.ParseArguments(args, options);

			var kernel = new Ninject.StandardKernel();
			kernel.Bind<CommandLineArgs>().ToConstant(options);
			kernel.Bind<Config>().ToConstant(new Config(options.ConfigFile));
			kernel.Bind<IFileParser>().To<TextFileParser>();

			// Алгоритм который занимается подготовкой слов и алгоритм сохранения до сих пор лежат внутри ConsoleApp (строки 37-39, 44-50)
			// Если в вынесении алгоритма мы не очень заинтересованы, то алгоритм подготовки слов надо выносить,
			// это обязательное требование к задаче, чтобы он был модульный
			kernel.Bind<IWordPreparer>().To<SimplePreparer>();
			kernel.Bind<IDrawer>().To<SimpleDrawer>(); 
			//kernel.Bind<ISaver>().To<ImageSaver>(); 

			kernel.Bind<IApplication>().To<ConsoleApp>();
			kernel.Get<IApplication>().Start();
		}

	}
}
