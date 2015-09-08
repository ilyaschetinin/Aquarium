using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Factory;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Enums;
using Aquarium.Model.Entities.Parameters;
using Aquarium.Model.Strategies;
using Aquarium.Model.Position;

namespace Aquarium.Model.Initialization
{
	public class AquariumObjectListInitializer
	{
		#region Fields

		protected Random _random = new Random(); 

		#endregion Fields

		#region Public Methods

		/// <summary>
		/// Инициализация списка объектов
		/// </summary>
		public virtual List<IAquariumObject> Init(AquariumInitializationParameters parameters, IAquariumPositionContext positionContext, AquariumObjectFactory factory)
		{
			List<IAquariumObject> aquariumObjects = new List<IAquariumObject>();

			GenerateFishes(parameters, aquariumObjects, positionContext, factory);
			GenerateSeaweeds(parameters, aquariumObjects, positionContext, factory);

			return aquariumObjects;
		}

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// Генерация рыбок
		/// </summary>
		protected virtual void GenerateFishes(AquariumInitializationParameters parameters, List<IAquariumObject> aquariumObjects, IAquariumPositionContext positionContext, AquariumObjectFactory factory)
		{
			for (int fishNumber = 0; fishNumber < parameters.FishCount; fishNumber++)
			{
				// выбираем все параметры рыбок случайным образом
				FishParameters fishParameters = GetFishParameters(parameters, aquariumObjects, positionContext);
				IAquariumObject fish = factory.Create(AquariumObjectType.Fish, fishParameters);
				aquariumObjects.Add(fish);
			}
		}

		/// <summary>
		/// Генерация водорослей
		/// </summary>
		protected virtual void GenerateSeaweeds(AquariumInitializationParameters parameters, List<IAquariumObject> aquariumObjects, IAquariumPositionContext positionContext, AquariumObjectFactory factory)
		{
			Random random = new Random();
			for (int seaweedNumber = 0; seaweedNumber < parameters.SeaweedCount; seaweedNumber++)
			{
				// выбираем все параметры водорослей случайным образом
				SeaweedParameters seaweedParameters = GetSeaweedParameters(parameters, aquariumObjects, positionContext);
				IAquariumObject seaweed = factory.Create(AquariumObjectType.Seaweed, seaweedParameters);
				aquariumObjects.Add(seaweed);
			}
		}

		/// <summary>
		/// Генерация параметров рыбок
		/// </summary>
		protected virtual FishParameters GetFishParameters(AquariumInitializationParameters parameters, List<IAquariumObject> aquariumObjects, IAquariumPositionContext positionContext)
		{
			return new FishParameters()
			{
				X = positionContext.GetRandomPosX(),
				Y = positionContext.GetRandomPosY(),
				SizeX = _random.Next(parameters.FishMinSizeX, parameters.FishMaxSizeX + 1),
				SizeY = _random.Next(parameters.FishMinSizeY, parameters.FishMaxSizeY + 1),
				Speed = _random.Next(parameters.FishMinSpeed, parameters.FishMaxSpeed + 1),
				MovementDirection = (Direction)_random.Next(DirectionHelper.DirectionCount),
				MovementStrategy = new SimpleMovementStrategy()
			};
		}

		/// <summary>
		/// Генерация параметров водорослей
		/// </summary>
		protected virtual SeaweedParameters GetSeaweedParameters(AquariumInitializationParameters parameters, List<IAquariumObject> aquariumObjects, IAquariumPositionContext positionContext)
		{
			SeaweedParameters seaweedParameters = new SeaweedParameters()
			{
				X = positionContext.GetRandomPosX(),
				SizeX = _random.Next(parameters.SeaweedMinSizeX, parameters.SeaweedMaxSizeX + 1),
				SizeY = _random.Next(parameters.SeaweedMinSizeY, parameters.SeaweedMaxSizeY + 1),
			};

			seaweedParameters.Y = seaweedParameters.SizeY / 2;

			return seaweedParameters;
		}

		#endregion Private Methods
	}
}
