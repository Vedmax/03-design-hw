﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
	public interface ISaver
	{
		void SaveImage(Config config, string[] words);
	}
}