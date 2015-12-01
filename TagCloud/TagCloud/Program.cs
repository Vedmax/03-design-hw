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
		// нужно добавить какой нибудь help для аргументов командной строки, а лучше попробуй поиспользовать
		// almost DONE https://github.com/gsscoder/commandline.

		// DONE ну и еще я не вижу реализацию обязательной фичи по указыванию цвета и шрифта на изображении
		static void Main(string[] args)
		{
			var options = new CommandLineArgs();
			Parser.Default.ParseArguments(args, options);

			// DONE? вместо kernel.Get<CommandLineArgs>().ConfigFile) нужно использовать фичу,
			// когда контейнер сам подставляет интерфейсы в аргументы
			var kernel = new Ninject.StandardKernel();
			kernel.Bind<CommandLineArgs>().ToConstant(options);
			kernel.Bind<Config>().ToConstant(new Config(options.ConfigFile));
			kernel.Bind<IFileParser>().To<TextFileParser>();

			//проблема в том, что алгоритм генерации облака и способ сохранения зашиты в ConsoleApp
			//нужно на интерфейсы биндить и алгоритм генерации и способ вывода
			//например
			kernel.Bind<IDrawer>().To<SimpleDrawer>(); 
			//kernel.Bind<ISaver>().To<ImageSaver>(); 

			kernel.Bind<IApplication>().To<ConsoleApp>();
			kernel.Get<IApplication>().Start();
		}

	}
}
