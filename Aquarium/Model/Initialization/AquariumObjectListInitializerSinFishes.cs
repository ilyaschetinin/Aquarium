using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Parameters;
using Aquarium.Model.Position;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Strategies;
using Aquarium.Model.Rendering;

namespace Aquarium.Model.Initialization
{
	public class AquariumObjectListInitializerSinFishes : AquariumObjectListInitializer
	{
		private int _sinFishCount = 0;

		/// <summary>
		/// Генерация параметров рыбок
		/// </summary>
		protected override FishParameters GetFishParameters(AquariumInitializationParameters parameters, List<IAquariumObject> aquariumObjects, IAquariumPositionContext positionContext)
		{
			FishParameters fishParameters = base.GetFishParameters(parameters, aquariumObjects, positionContext);

			AquariumInitializationParametersSinFishes aquariumParameters = parameters as AquariumInitializationParametersSinFishes;
			if (aquariumParameters != null)
			{
				if (_sinFishCount < aquariumParameters.SinFishCount)
				{
					fishParameters.MovementStrategy = new SinMovementStrategyAdapter();

					_sinFishCount++;
				}
			}

			return fishParameters;
		}
	}
}
