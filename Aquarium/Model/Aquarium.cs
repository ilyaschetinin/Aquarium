using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;
using System.Collections.ObjectModel;

namespace Aquarium.Model
{
	public class Aquarium : IAquarium
	{
		private const int DEFAULT_FISH_COUNT = 10;

		private static Aquarium _instance;
		public static Aquarium Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Aquarium();
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
		
		private List<Fish> _fishes = new List<Fish>();
		public ReadOnlyCollection<Fish> Fishes
		{
			get
			{
				return _fishes.AsReadOnly();
			}
		}

		private Aquarium()
		{
		}

		public void Init(int sizeX, int sizeY, int fishCount = DEFAULT_FISH_COUNT)
		{
			SizeX = sizeX;
			SizeY = sizeY;

			GenerateFishes(fishCount);
		}

		private void GenerateFishes(int fishCount)
		{
			Random random = new Random();

			for (int fishNumber = 0; fishNumber <= fishCount; fishNumber++)
			{
				// TODO: в константы
				int posX = random.Next(0, SizeX + 1);
				int posY = random.Next(0, SizeY + 1);
				Direction movementDirection = (Direction)random.Next(0, 2);
				int id = fishNumber;

				Fish fish = new Fish(this, id, posX, posY, movementDirection);
				_fishes.Add(fish);
			}
		}
	}
}
