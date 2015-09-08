using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Factory;
using Aquarium.Model.Entities;

namespace Aquarium.Model.Enums
{
	public enum AquariumObjectType
	{
		[ObjectType(typeof(Fish))]
		Fish = 0,

		[ObjectType(typeof(Seaweed))]
		Seaweed = 1
	}
}
