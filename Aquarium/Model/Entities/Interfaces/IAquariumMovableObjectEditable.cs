using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;
using Aquarium.Model.Position;

namespace Aquarium.Model.Entities.Interfaces
{
	public interface IAquariumMovableObjectEditable : IAquariumObjectEditable, IAquariumDrawableObject
	{
		/// <summary>
		/// Напраление движения объекта
		/// </summary>
		Direction MovementDirection { get; set; }

		/// <summary>
		/// Скорость объекта
		/// </summary>
		int Speed { get; set; }

		/// <summary>
		/// Подвинуть
		/// </summary>
		void Move(IAquariumPositionContext aquarium);
	}
}
