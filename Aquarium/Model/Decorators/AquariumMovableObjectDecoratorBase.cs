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
	public class AquariumMovableObjectDecoratorBase : IAquariumMovableObjectEditable, IAquariumDrawableObject, IAquariumObjectEditable, IAquariumMovableObject, IAquariumObject
	{
		#region Private Fields

		protected IAquariumMovableObjectEditable _aquariumObject;

		#endregion Private Fields


		#region IAquariumObject

		public int X
		{
			get { return _aquariumObject.X; }
			set { _aquariumObject.X = value; }
		}

		public int Y
		{
			get { return _aquariumObject.Y; }
			set { _aquariumObject.Y = value; }
		}

		public int SizeX
		{
			get { return _aquariumObject.SizeX; }
			set { _aquariumObject.SizeX = value; }
		}

		public int SizeY
		{
			get { return _aquariumObject.SizeY; }
			set { _aquariumObject.SizeY = value; }
		}

		#endregion IAquariumObject


		#region IAquariumMovableObject

		public Direction MovementDirection
		{
			get { return _aquariumObject.MovementDirection; }
			set { _aquariumObject.MovementDirection = value; }
		}

		public int Speed
		{
			get { return _aquariumObject.Speed; }
			set { _aquariumObject.Speed = value; }
		}

		public virtual void Move(IAquariumPositionContext aquarium)
		{
			_aquariumObject.Move(aquarium);
		}

		#endregion IAquariumMovableObject


		#region IAquariumDrawableObject

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
