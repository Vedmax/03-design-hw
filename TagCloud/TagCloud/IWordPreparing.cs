using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
	public interface IWordPreparer
	{
		Dictionary<string, int> GetTopWords(CommandLineArgs args, IFileParser parser);
	}
}
