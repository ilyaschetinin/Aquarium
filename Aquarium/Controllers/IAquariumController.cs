using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Controllers
{
	public interface IAquariumController
	{
		void Init(int aquariumSizeX, int aquariumSizeY);
		void Start();
		void Stop();	
	}
}
