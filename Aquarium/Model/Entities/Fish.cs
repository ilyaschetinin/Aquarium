using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;
using Aquarium.Model.Strategies;
using Aquarium.Model.Entities.Parameters;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Entities
{
	public class Fish : IFishContext, IAquariumObject, IAquariumMovableObject, IAquariumDrawableObject
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
			set;
		}

		/// <summary>
		/// Позиция рыбки по оси Y
		/// </summary>
		public int Y
		{
			get;
			set;
		}

		/// <summary>
		/// Размер рыбки по оси X
		/// </summary>
		public int SizeX
		{
			get;
			set;
		}

		/// <summary>
		/// Размер рыбки по оси Y
		/// </summary>
		public int SizeY
		{
			get;
			set;
		}

		/// <summary>
		/// Напраление движения рыбки
		/// </summary>
		public Direction MovementDirection
		{
			get;
			set;
		}

		/// <summary>
		/// Скорость рыбки
		/// </summary>
		public int Speed
		{
			get;
			set;
		}

		/// <summary>
		/// Стратегия движения
		/// </summary>
		public IMovementStrategy MovementStrategy
		{
			get;
			set;
		}

		/// <summary>
		/// Рисователь
		/// </summary>
		public IAquariumObjectDrawer Drawer
		{
			get;
			set;
		}

		#endregion Properties

		#region Constructor

		/// <summary>
		/// Конструктор
		/// </summary>
		public Fish(IAquariumObjectDrawer drawer, FishParameters parameters)
		{
			Drawer = drawer;

			Id = parameters.Id;
			X = parameters.X;
			Y = parameters.Y;
			SizeX = parameters.SizeX;
			SizeY = parameters.SizeY;
			MovementDirection = parameters.MovementDirection;
			Speed = parameters.Speed;
			MovementStrategy = parameters.MovementStrategy;
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Подвинуть рыбку
		/// </summary>
		public void Move(IAquariumContext aquarium)
		{
			if (MovementStrategy != null)
			{
				MovementStrategy.Move(aquarium, this);
			}
		}

		/// <summary>
		/// Нарисовать рыбку
		/// </summary>
		public void Draw()
		{
			if (Drawer != null)
			{
				Drawer.Draw(this);
			}
		}

		#endregion Public Methods
	}
}
