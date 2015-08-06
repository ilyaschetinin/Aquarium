using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;
using System.Collections.ObjectModel;
using Aquarium.Utils;

namespace Aquarium.Model
{
	public class AquariumModel : IAquarium
	{
		private const int DEFAULT_FISH_COUNT = 10;

		private const int MIN_SPEED = 1;
		private const int MAX_SPEED = 20;

		private List<Fish> _fishes = new List<Fish>();
			
		private static volatile AquariumModel _instance;
		private static object syncObj = new Object();

		public static AquariumModel Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (syncObj)
					{
						if (_instance == null)
							_instance = new AquariumModel();
					}
				}

				if (_instance == null)
				{
					_instance = new AquariumModel();
				}

				return _instance;
			}
		}

		public int SizeX
		{
			get;
			private set;
		}

		public int SizeY
		{
			get;
			private set;
		}

		List<IFish> IAquarium.Fishes
		{
			get
			{
				return _fishes.OfType<IFish>().ToList();
			}
		}

		private AquariumModel()
		{
		}

		public void Init(int sizeX, int sizeY)
		{
			Init(sizeX, sizeY, DEFAULT_FISH_COUNT);
		}

		public void Init(int sizeX, int sizeY, int fishCount)
		{
			SizeX = sizeX;
			SizeY = sizeY;

			GenerateFishes(fishCount);
		}

		public void Move()
		{
			foreach (Fish fish in _fishes)
			{
				fish.Move();
			}
		}

		private void GenerateFishes(int fishCount)
		{
			Random random = new Random();

			for (int fishNumber = 0; fishNumber < fishCount; fishNumber++)
			{
				int posX = random.Next(SizeX + 1);
				int posY = random.Next(SizeY + 1);
				Direction movementDirection = (Direction)random.Next(DirectionHelper.DirectionCount);
				int id = fishNumber;
				int speed = random.Next(MIN_SPEED, MAX_SPEED + 1);

				Fish fish = new Fish(this, id, posX, posY, movementDirection, speed);
				_fishes.Add(fish);
			}
		}
	}
}
