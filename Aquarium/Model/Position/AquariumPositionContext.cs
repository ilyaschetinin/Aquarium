using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Position
{
	public class AquariumPositionContext : IAquariumPositionContext
	{
		#region Constants

		/// <summary>
		/// Наименьшее значение координаты по оси X
		/// </summary>
		private const int MIN_X = 0;

		/// <summary>
		/// Наименьшее значение координаты по оси Y
		/// </summary>
		private const int MIN_Y = 0;

		#endregion Constants

		#region Fields

		private volatile int _sizeX;
		private volatile int _sizeY;

		private Random _random = new Random();

		#endregion Fields

		#region Properties

		/// <summary>
		/// Получить наименьшее значение координаты по оси X
		/// </summary>
		public int MinX
		{
			get
			{
				return MIN_X;
			}
		}

		/// <summary>
		/// Получить наименьшее значение координаты по оси Y
		/// </summary>
		public int MinY
		{
			get
			{
				return MIN_Y;
			}
		}

		/// <summary>
		/// Ширина аквариума
		/// </summary>
		public int SizeX
		{
			get
			{
				return _sizeX;
			}
			private set
			{
				_sizeX = value;
			}
		}

		/// <summary>
		/// Высота аквариума
		/// </summary>
		public int SizeY
		{
			get
			{
				return _sizeY;
			}
			private set
			{
				_sizeY = value;
			}
		}

		#endregion Properties

		#region Public Methods

		/// <summary>
		/// Задать размер аквариума
		/// </summary>
		public void SetSize(int sizeX, int sizeY)
		{
			this.SizeX = sizeX;
			this.SizeY = sizeY;
		}

		/// <summary>
		/// Можно ли передвинуться в указанную позицию
		/// </summary>
		public bool IsValidPosition(int posX, int posY)
		{
			return MinX <= posX && posX <= SizeX &&
				MinY <= posY && posY <= SizeY;
		}

		/// <summary>
		/// Находится ли позиция за границей аквариума
		/// </summary>
		public bool IsPositionOutsideBorders(int posX, int posY)
		{
			return !IsValidPosition(posX, posY);
		}

		/// <summary>
		/// Получить случайную позицию по оси X
		/// </summary>
		public int GetRandomPosX()
		{
			return _random.Next(MinX, SizeX + 1);
		}

		/// <summary>
		/// Получить случайную позицию по оси Y
		/// </summary>
		public int GetRandomPosY()
		{
			return _random.Next(MinY, SizeY + 1);
		}

		/// <summary>
		/// Скорректировать позицию объекта
		/// </summary>
		public void FixPosition(IAquariumMovableObjectEditable obj)
		{
			obj.X = Coerce(obj.X, MinX + obj.SizeX / 2, SizeX - obj.SizeX / 2);
			obj.Y = Coerce(obj.Y, MinY + obj.SizeY / 2, SizeY - obj.SizeY / 2);
		}

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// Подправить текущую координату при необходимости
		/// </summary>
		private int Coerce(int current, int min, int max)
		{
			int result = current;

			if (current < min)
			{
				result = min;
			}
			else if (current > max)
			{
				result = max;
			}

			return result;
		}

		#endregion Private Methods
	}
}
