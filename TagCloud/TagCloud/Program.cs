using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;


namespace TagCloud
{
	class ConfigProvider : Provider<Config>
	{
		protected override Config CreateInstance(IContext context)
		{
			return new Config(context.Kernel.Get<CommandLineArgs>().ConfigFile);
		}
	}

	public class CommandLineArgsModule : NinjectModule
	{
		public override void Load()
		{
			var options = new CommandLineArgs();
			Parser.Default.ParseArguments(Environment.GetCommandLineArgs(), options);
			Bind<CommandLineArgs>().ToConstant(options);
		}
	}

	public class FileParserProvider : Provider<IFileParser>
	{
		protected override IFileParser CreateInstance(IContext context)
		{
			var commandLineArgs = context.Kernel.Get<CommandLineArgs>();
			var inputFile = commandLineArgs.TextFile;
			if (inputFile.EndsWith(".txt"))
			{
				return context.Kernel.Get<TextFileParser>();
			}
			else if (inputFile.EndsWith(".pdf"))
			{
				return context.Kernel.Get<PdfWordsReader>();
			}
			throw new InvalidOperationException("invalid file format");
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			var kernel = new Ninject.StandardKernel();
			kernel.Load(AppDomain.CurrentDomain.GetAssemblies());

			kernel.Bind<Config>().ToProvider<ConfigProvider>();
			kernel.Bind<IFileParser>().ToProvider<FileParserProvider>();
			kernel.Bind<PdfWordsReader>().ToSelf().InSingletonScope();
			kernel.Bind<TextFileParser>().ToSelf().InSingletonScope();
			kernel.Bind<IWordPreparer>().To<SimplePreparer>();
			kernel.Bind<IDrawer>().To<SimpleDrawer>(); 
			kernel.Bind<ISaver>().To<ImageSaver>(); 

			kernel.Bind<IApplication>().To<ConsoleApp>();
			kernel.Get<IApplication>().Start();
		}

	}
}
