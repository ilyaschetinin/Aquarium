using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;
using Aquarium.Model.Strategies;
using Aquarium.Model.Entities.Parameters;
using Aquarium.Model.Entities.Interfaces;
using System.Drawing;
using Aquarium.Model.Rendering;
using Aquarium.Model.Position;

namespace Aquarium.Model.Entities
{
	/// <summary>
	/// Рыбка
	/// </summary>
	public class Fish : AquariumObject, IAquariumMovableObjectEditable, IAquariumObject, IAquariumMovableObject, IAquariumDrawableObject
	{
		#region Properties
		
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
		public IAquariumObjectRenderer Renderer
		{
			get;
			set;
		}

		#endregion Properties

		#region Constructor

		/// <summary>
		/// Конструктор
		/// </summary>
		public Fish(IAquariumObjectRenderer renderer, FishParameters parameters)
			: base(parameters)
		{
			Renderer = renderer;

			MovementDirection = parameters.MovementDirection;
			Speed = parameters.Speed;
			MovementStrategy = parameters.MovementStrategy;
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Подвинуть рыбку
		/// </summary>
		public void Move(IAquariumPositionContext aquarium)
		{
			if (MovementStrategy != null)
			{
				MovementStrategy.Move(aquarium, this);
			}
		}

		/// <summary>
		/// Нарисовать рыбку
		/// </summary>
		public void Draw(IDrawingControl control, Graphics graphics)
		{
			if (Renderer != null)
			{
				Renderer.Render(this, control, graphics);
			}
		}

		#endregion Public Methods
	}
}
