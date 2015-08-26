using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model.Strategies
{
	public interface IMovementStrategy
	{
		void Move(IAquariumContext aquarium, IFishContext fish);
	}
}
