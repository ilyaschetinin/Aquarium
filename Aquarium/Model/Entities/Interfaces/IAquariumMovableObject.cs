using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Strategies;

namespace Aquarium.Model.Entities.Interfaces
{
	public interface IAquariumMovableObject : IAquariumObject
	{
		void Move(IAquariumContext aquarium);
	}
}
