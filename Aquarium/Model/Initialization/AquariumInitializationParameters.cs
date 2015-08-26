using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model.Initialization
{
	public class AquariumInitializationParameters
	{
		#region Constants

		/// <summary>
		/// Число рыбок в аквариуме
		/// </summary>
		private const int FISH_COUNT = 10;

		/// <summary>
		/// Число водорослей в аквариуме
		/// </summary>
		private const int SEAWEED_COUNT = 5;

		/// <summary>
		/// Минимальная скорость генерируемых рыбок
		/// </summary>
		private const int FISH_MIN_SPEED = 1;

		/// <summary>
		/// Максимальная скорость генерируемых рыбок
		/// </summary>
		private const int FISH_MAX_SPEED = 20;

		/// Минимальный размер генерируемых рыбок по оси X
		/// </summary>
		private const int FISH_MIN_SIZE_X = 1;

		/// <summary>
		/// Максимальный размер генерируемых рыбок по оси X
		/// </summary>
		private const int FISH_MAX_SIZE_X = 20;

		/// Минимальный размер генерируемых рыбок по оси Y
		/// </summary>
		private const int FISH_MIN_SIZE_Y = 1;

		/// <summary>
		/// Максимальный размер генерируемых рыбок по оси Y
		/// </summary>
		private const int FISH_MAX_SIZE_Y = 20;
		
		/// Минимальный размер генерируемых водорослей по оси X
		/// </summary>
		private const int SEAWEED_MIN_SIZE_X = 1;

		/// <summary>
		/// Максимальный размер генерируемых водорослей по оси X
		/// </summary>
		private const int SEAWEED_MAX_SIZE_X = 20;

		/// Минимальный размер генерируемых водорослей по оси Y
		/// </summary>
		private const int SEAWEED_MIN_SIZE_Y = 1;

		/// <summary>
		/// Максимальный размер генерируемых водорослей по оси Y
		/// </summary>
		private const int SEAWEED_MAX_SIZE_Y = 20;

		#endregion Constants
				
		#region Properties

		/// <summary>
		/// Ширина аквариума
		/// </summary>
		public int AquariumSizeX { get; set; }

		/// <summary>
		/// Высота аквариума
		/// </summary>
		public int AquariumSizeY { get; set; }

		/// <summary>
		/// Число рыбок в аквариуме
		/// </summary>
		public int FishCount { get; set; }

		/// <summary>
		/// Число водорослей в аквариуме
		/// </summary>
		public int SeaweedCount { get; set; }

		/// <summary>
		/// Минимальная скорость генерируемых рыбок
		/// </summary>
		public int FishMinSpeed { get; set; }

		/// <summary>
		/// Максимальная скорость генерируемых рыбок
		/// </summary>
		public int FishMaxSpeed { get; set; }

		/// Минимальный размер генерируемых рыбок по оси X
		/// </summary>
		public int FishMinSizeX { get; set; }

		/// <summary>
		/// Максимальный размер генерируемых рыбок по оси X
		/// </summary>
		public int FishMaxSizeX { get; set; }

		/// Минимальный размер генерируемых рыбок по оси Y
		/// </summary>
		public int FishMinSizeY { get; set; }

		/// <summary>
		/// Максимальный размер генерируемых рыбок по оси Y
		/// </summary>
		public int FishMaxSizeY { get; set; }

		/// Минимальный размер генерируемых водорослей по оси X
		/// </summary>
		public int SeaweedMinSizeX { get; set; }

		/// <summary>
		/// Максимальный размер генерируемых водорослей по оси X
		/// </summary>
		public int SeaweedMaxSizeX { get; set; }

		/// Минимальный размер генерируемых водорослей по оси Y
		/// </summary>
		public int SeaweedMinSizeY { get; set; }

		/// <summary>
		/// Максимальный размер генерируемых водорослей по оси Y
		/// </summary>
		public int SeaweedMaxSizeY { get; set; }

		#endregion Properties

		public AquariumInitializationParameters(int aquariumSizeX, int aquariumSizeY)
		{
			AquariumSizeX = aquariumSizeX;
			AquariumSizeY = aquariumSizeY;

			FishCount = FISH_COUNT;
			SeaweedCount = SEAWEED_COUNT;
			FishMinSpeed = FISH_MIN_SPEED;
			FishMaxSpeed = FISH_MAX_SPEED;
			FishMinSizeX = FISH_MIN_SIZE_X;
			FishMaxSizeX = FISH_MAX_SIZE_X;
			FishMinSizeY = FISH_MIN_SIZE_Y;
			FishMaxSizeY = FISH_MAX_SIZE_Y;
			SeaweedMinSizeX = SEAWEED_MIN_SIZE_X;
			SeaweedMaxSizeX = SEAWEED_MAX_SIZE_X;
			SeaweedMinSizeY = SEAWEED_MIN_SIZE_Y;
			SeaweedMaxSizeY = SEAWEED_MAX_SIZE_Y;
		}
	}
}
