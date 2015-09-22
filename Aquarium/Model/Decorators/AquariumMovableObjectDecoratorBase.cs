using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Position;
using Aquarium.Model.Rendering;
using System.Drawing;
using Aquarium.Model.Enums;

namespace Aquarium.Model.Decorators
{
	/// <summary>
	/// Базовый класс-декоратор объектов аквариума
	/// </summary>
	public class AquariumMovableObjectDecoratorBase : IAquariumMovableObjectEditable, IAquariumDrawableObject, IAquariumObjectEditable, IAquariumMovableObject, IAquariumObject
	{
		#region Private Fields

		/// <summary>
		/// Объект аквариума
		/// </summary>
		protected IAquariumMovableObjectEditable _aquariumObject;

		#endregion Private Fields


		#region IAquariumObject

		/// <summary>
		/// Позиция объекта по оси X
		/// </summary>
		public int X
		{
			get { return _aquariumObject.X; }
			set { _aquariumObject.X = value; }
		}

		/// <summary>
		/// Позиция объекта по оси Y
		/// </summary>
		public int Y
		{
			get { return _aquariumObject.Y; }
			set { _aquariumObject.Y = value; }
		}

		/// <summary>
		/// Размер объекта по оси X
		/// </summary>
		public int SizeX
		{
			get { return _aquariumObject.SizeX; }
			set { _aquariumObject.SizeX = value; }
		}

		/// <summary>
		/// Размер объекта по оси Y
		/// </summary>
		public int SizeY
		{
			get { return _aquariumObject.SizeY; }
			set { _aquariumObject.SizeY = value; }
		}

		#endregion IAquariumObject


		#region IAquariumMovableObject

		/// <summary>
		/// Напраление движения объекта
		/// </summary>
		public Direction MovementDirection
		{
			get { return _aquariumObject.MovementDirection; }
			set { _aquariumObject.MovementDirection = value; }
		}

		/// <summary>
		/// Скорость объекта
		/// </summary>
		public int Speed
		{
			get { return _aquariumObject.Speed; }
			set { _aquariumObject.Speed = value; }
		}

		/// <summary>
		/// Подвинуть объект
		/// </summary>
		public virtual void Move(IAquariumPositionContext aquarium)
		{
			_aquariumObject.Move(aquarium);
		}

		#endregion IAquariumMovableObject


		#region IAquariumDrawableObject

		/// <summary>
		/// Нарисовать объект
		/// </summary>
		public virtual void Draw(IDrawingControl control, Graphics graphics)
		{
			_aquariumObject.Draw(control, graphics);
		}

		#endregion IAquariumMovableObject


		#region Constructor

		public AquariumMovableObjectDecoratorBase(IAquariumMovableObjectEditable aquariumObject)
		{
			_aquariumObject = aquariumObject;
		}

		#endregion Constructor
	}
}
