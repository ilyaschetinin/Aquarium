using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model
{
	public interface IAquarium
	{
		int SizeX { get; }
		int SizeY { get; }

		void Init(int sizeX, int sizeY);
	}
}
