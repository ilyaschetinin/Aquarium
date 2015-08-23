using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;
using Aquarium.Model.Strategies;

namespace Aquarium.Model
{
	public class Fish : IFish
	{
		#region Properties

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
		/// Размер рыбки по оси X
		/// </summary>
		public int SizeX
		{
			get;
			private set;
		}

		/// <summary>
		/// Размер рыбки по оси Y
		/// </summary>
		public int SizeY
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

		public IMovementStrategy Strategy
		{
			get;
			private set;
		}

		#endregion Properties

		#region Constructor

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Id рыбки</param>
		/// <param name="posX">Позиция рыбки по оси X</param>
		/// <param name="posY">Позиция рыбки по оси Y</param>
		/// <param name="direction">Напраление движения рыбки</param>
		/// <param name="speed">Скорость рыбки</param>
		public Fish(int id, int posX, int posY, int sizeX, int sizeY, Direction direction, int speed, IMovementStrategy strategy)
		{
			Id = id;
			X = posX;
			Y = posY;
			SizeX = sizeX;
			SizeY = sizeY;
			MovementDirection = direction;
			Speed = speed;
			Strategy = strategy;
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Подвинуть рыбку
		/// </summary>
		public void Move(IAquariumContext aquarium)
		{
			Strategy.Move(aquarium, this);
		}

		/// <summary>
		/// Поменять направление движения рыбки
		/// </summary>
		public void SetDirection(Direction direction)
		{
			MovementDirection = direction;
		}

		#endregion Public Methods
	}
}
