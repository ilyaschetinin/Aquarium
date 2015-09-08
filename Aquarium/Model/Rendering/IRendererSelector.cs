using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Enums;
using Aquarium.Model.Entities.Parameters;

namespace Aquarium.Model.Rendering
{
	public interface IRendererSelector
	{
		IAquariumObjectRenderer Get(AquariumObjectType aquariumObjectType, BaseParameters parameters); 
	}
}
