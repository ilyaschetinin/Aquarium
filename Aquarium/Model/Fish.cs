using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;

namespace Aquarium.Model
{
	public class Fish : IFish
	{
		#region Constants

		/// <summary>
		/// Скорость рыбки по умолчанию
		/// </summary>
		public const int DEFAULT_SPEED = 10;

		#endregion Constants

		#region Properties

		private IAquarium Aquarium
		{
			get;
			set;
		}

		/// <summary>
		/// Id рыбки
		/// </summary>
		public int Id
		{
			get;
			private set;
		}

		/// <summary>
		/// Позиция рыбки по оси X
		/// </summary>
		public int X
		{
			get;
			private set;
		}

		/// <summary>
		/// Позиция рыбки по оси Y
		/// </summary>
		public int Y
		{
			get;
			private set;
		}

		/// <summary>
		/// Напраление движения рыбки
		/// </summary>
		public Direction MovementDirection
		{
			get;
			private set;
		}

		/// <summary>
		/// Скорость рыбки
		/// </summary>
		public int Speed
		{
			get;
			private set;
		}

		#endregion Properties

		#region Constructor

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="aquarium">Ссылка на аквариум</param>
		/// <param name="id">Id рыбки</param>
		/// <param name="posX">Позиция рыбки по оси X</param>
		/// <param name="posY">Позиция рыбки по оси Y</param>
		/// <param name="direction">Напраление движения рыбки</param>
		/// <param name="speed">Скорость рыбки</param>
		public Fish(IAquarium aquarium, int id, int posX, int posY, Direction direction, int speed = DEFAULT_SPEED)
		{
			Aquarium = aquarium;
			Id = id;
			X = posX;
			Y = posY;
			MovementDirection = direction;
			Speed = speed;
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Подвинуть рыбку
		/// </summary>
		public void Move()
		{
			if (!CanMove())
			{
				// Если рыбка не может двигаться в данном направлении, то меняем его на противоположное
				MovementDirection = MovementDirection.GetOpposite();
			}

			// На всякий случай проверяем еще раз
			if (CanMove())
			{
				// Передвигаемся
				X = GetNextPosX(MovementDirection);
			}
		}

		#endregion Public Methods
		
		#region Private Methods

		/// <summary>
		/// Может ли рыбка передвинуться в данном направлении
		/// </summary>
		private bool CanMove()
		{
			int nextPosX = GetNextPosX(MovementDirection);
			return IsValid(nextPosX, Y);
		}

		/// <summary>
		/// Получить следующую координату при движении в заданном направлении
		/// </summary>
		private int GetNextPosX(Direction direction)
		{
			int shift = MovementDirection == Direction.Right ? 1 : -1;
			return X + Speed * shift;
		}

		/// <summary>
		/// Координата находится внутри аквариума
		/// </summary>
		private bool IsValid(int posX, int posY)
		{
			return 0 <= posX && posX <= Aquarium.SizeX &&
				0 <= posY && posY <= Aquarium.SizeY;
		}

		#endregion Private Methods			
	}
}
