using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Decorators
{
	public interface IAquariumObjectWrapper
	{
		IAquariumObject Wrap(IAquariumObject obj);
	}
}
