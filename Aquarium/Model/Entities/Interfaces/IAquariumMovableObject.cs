using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Strategies;
using Aquarium.Model.Enums;
using Aquarium.Model.Position;

namespace Aquarium.Model.Entities.Interfaces
{
	public interface IAquariumMovableObject : IAquariumObject
	{
		/// <summary>
		/// Напраление движения
		/// </summary>
		Direction MovementDirection { get; }

		/// <summary>
		/// Скорость
		/// </summary>
		int Speed { get; }

		/// <summary>
		/// Подвинуть
		/// </summary>
		void Move(IAquariumPositionContext aquarium);
	}
}
