using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Factory;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Enums;
using Aquarium.Model.Entities.Parameters;
using Aquarium.Utils;
using Aquarium.Model.Strategies;

namespace Aquarium.Model.Initialization
{
	public class AquariumObjectListInitializer
	{
		#region Public Methods

		public virtual List<IAquariumObject> Init(AquariumInitializationParameters parameters, AquariumObjectFactory factory)
		{
			List<IAquariumObject> aquariumObjects = new List<IAquariumObject>();

			GenerateFishes(parameters, aquariumObjects, factory);
			GenerateSeaweeds(parameters, aquariumObjects, factory);

			return aquariumObjects;
		}

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// Генерация рыбок
		/// </summary>
		protected virtual void GenerateFishes(AquariumInitializationParameters parameters, List<IAquariumObject> aquariumObjects, AquariumObjectFactory factory)
		{
			Random random = new Random();
			for (int fishNumber = 0; fishNumber < parameters.FishCount; fishNumber++)
			{
				// выбираем все параметры рыбок случайным образом
				FishParameters fishParameters = new FishParameters()
				{
					Id = fishNumber,
					X = random.Next(parameters.AquariumSizeX + 1),
					Y = random.Next(parameters.AquariumSizeY + 1),
					SizeX = random.Next(parameters.FishMinSizeX, parameters.FishMaxSizeX + 1),
					SizeY = random.Next(parameters.FishMinSizeY, parameters.FishMaxSizeY + 1),
					MovementDirection = (Direction)random.Next(DirectionHelper.DirectionCount),
					Speed = random.Next(parameters.FishMinSpeed, parameters.FishMaxSpeed + 1),
					MovementStrategy = new SimpleMovementStrategy()
				};

				IAquariumObject fish = factory.Create(AquariumObjectType.Fish, fishParameters);
				aquariumObjects.Add(fish);
			}
		}

		/// <summary>
		/// Генерация водорослей
		/// </summary>
		protected virtual void GenerateSeaweeds(AquariumInitializationParameters parameters, List<IAquariumObject> aquariumObjects, AquariumObjectFactory factory)
		{
			Random random = new Random();
			for (int seaweedNumber = 0; seaweedNumber < parameters.SeaweedCount; seaweedNumber++)
			{
				// выбираем все параметры водорослей случайным образом
				SeaweedParameters seaweedParameters = new SeaweedParameters()
				{
					Id = seaweedNumber,
					X = random.Next(parameters.AquariumSizeX + 1),
					Y = 0,
					SizeX = random.Next(parameters.SeaweedMinSizeX, parameters.SeaweedMaxSizeX + 1),
					SizeY = random.Next(parameters.SeaweedMinSizeY, parameters.SeaweedMaxSizeY + 1),
				};

				IAquariumObject seaweed = factory.Create(AquariumObjectType.Seaweed, seaweedParameters);
				aquariumObjects.Add(seaweed);
			}
		}

		#endregion Private Methods
	}
}
