using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Ninject.Syntax;

namespace TagCloud
{
	public class CommandLineArgs
	{
		[Option('t', "TextFile", DefaultValue = @"../../Default/text.txt",
			HelpText = "Text File")]
		public string TextFile
		{
			get; set;
		}

		[Option('b', "banned", DefaultValue = @"../../Default/blacklist.txt",
			HelpText = "Banned Words File")]
		public string BannedWordsFile
		{
			get; set;
		}


		[Option('c', "config", DefaultValue = @"../../Default/config.txt",
			HelpText = "Config File")]
		public string ConfigFile
		{
			get; set;
		}

		[Option('r', "result", DefaultValue = "image", HelpText = "Result file with image")]
		public string ResultFile
		{
			get; set;
		}
	}
}
