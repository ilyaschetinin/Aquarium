using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;
using System.Collections.ObjectModel;
using Aquarium.Utils;

namespace Aquarium.Model
{
	public sealed class AquariumModel : IAquarium
	{
		#region Constants

		/// <summary>
		/// Число рыбок в аквариуме по умолчанию
		/// </summary>
		private const int DEFAULT_FISH_COUNT = 10;

		/// <summary>
		/// Минимальная скорость генерируемых рыбок
		/// </summary>
		private const int MIN_SPEED = 1;

		/// <summary>
		/// Максимальная скорость генерируемых рыбок
		/// </summary>
		private const int MAX_SPEED = 20;

		/// Минимальный размер генерируемых рыбок по оси X
		/// </summary>
		private const int MIN_SIZE_X = 1;

		/// <summary>
		/// Максимальный размер генерируемых рыбок по оси X
		/// </summary>
		private const int MAX_SIZE_X = 20;

		/// Минимальный размер генерируемых рыбок по оси Y
		/// </summary>
		private const int MIN_SIZE_Y = 1;

		/// <summary>
		/// Максимальный размер генерируемых рыбок по оси Y
		/// </summary>
		private const int MAY_SIZE_Y = 20;

		#endregion Constants

		#region Fields

		private List<Fish> _fishes = new List<Fish>();

		private static volatile AquariumModel _instance;
		private static object syncObj = new Object();

		#endregion Fields

		#region Properties
		
		public static AquariumModel Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (syncObj)
					{
						if (_instance == null)
						{
							_instance = new AquariumModel();
						}
					}
				}

				return _instance;
			}
		}

		/// <summary>
		/// Ширина аквариума
		/// </summary>
		public int SizeX
		{
			get;
			private set;
		}

		/// <summary>
		/// Высота аквариума
		/// </summary>
		public int SizeY
		{
			get;
			private set;
		}

		/// <summary>
		/// Рыбки
		/// </summary>
		List<IFish> IAquarium.Fishes
		{
			get
			{
				return _fishes.OfType<IFish>().ToList();
			}
		}

		#endregion Properties

		#region Constructor

		private AquariumModel()
		{
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Инициализация аквариума
		/// </summary>
		/// <param name="sizeX">Ширина аквариума</param>
		/// <param name="sizeY">Высота аквариума</param>
		public void Init(int sizeX, int sizeY)
		{
			Init(sizeX, sizeY, DEFAULT_FISH_COUNT);
		}
		
		/// <summary>
		/// Инициализация аквариума
		/// </summary>
		/// <param name="sizeX">Ширина аквариума</param>
		/// <param name="sizeY">Высота аквариума</param>
		/// <param name="fishCount">Количество рыбок</param>
		public void Init(int sizeX, int sizeY, int fishCount)
		{
			SizeX = sizeX;
			SizeY = sizeY;

			GenerateFishes(fishCount);
		}

		/// <summary>
		/// Передвинуть всех рыбок
		/// </summary>
		public void Move()
		{
			foreach (Fish fish in _fishes)
			{
				fish.Move();
			}
		}

		#endregion Public Methods

		#region Private Methods
		
		/// <summary>
		/// Генерация рыбок
		/// </summary>
		private void GenerateFishes(int fishCount)
		{
			Random random = new Random();

			for (int fishNumber = 0; fishNumber < fishCount; fishNumber++)
			{
				// выбираем все параметры рыбок случайным образом
				int posX = random.Next(SizeX + 1);
				int posY = random.Next(SizeY + 1);
				int sizeX = random.Next(MIN_SIZE_X, MAX_SIZE_X + 1);
				int sizeY = random.Next(MIN_SIZE_Y, MAY_SIZE_Y + 1);
				Direction movementDirection = (Direction)random.Next(DirectionHelper.DirectionCount);
				int id = fishNumber;
				int speed = random.Next(MIN_SPEED, MAX_SPEED + 1);
				
				Fish fish = new Fish(id, posX, posY, sizeX, sizeY, movementDirection, speed);
				_fishes.Add(fish);
			}
		}
		
		#endregion Private Methods
	}
}
