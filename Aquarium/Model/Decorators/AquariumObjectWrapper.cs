using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Rendering;

namespace Aquarium.Model.Decorators
{
	public class AquariumObjectWrapper : IAquariumObjectWrapper
	{
		private IAquariumObjectRenderer _healthRenderer;

		public AquariumObjectWrapper(IAquariumObjectRenderer healthRenderer)
		{
			_healthRenderer = healthRenderer;
		}

		public IAquariumObject Wrap(IAquariumObject obj)
		{
			IAquariumObject result = obj;
			
			IAquariumMovableObjectEditable movableObjEditable = obj as IAquariumMovableObjectEditable;
			if (movableObjEditable != null)
			{
				result = new AquariumHealthDecorator(movableObjEditable, _healthRenderer);
			}

			return result;
		}
	}
}
