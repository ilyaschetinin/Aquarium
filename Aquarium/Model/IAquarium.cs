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
		List<IFish> Fishes { get; }

		void Init(int sizeX, int sizeY);
		void Init(int sizeX, int sizeY, int fishCount);

		void Move();
	}
}
