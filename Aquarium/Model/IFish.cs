using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;

namespace Aquarium.Model
{
	public interface IFish
	{
		int Id { get; }
		int X { get; }
		int Y { get; }
		Direction MovementDirection { get; }
		int Speed { get; }
	}
}
