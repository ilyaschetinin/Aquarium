using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Position;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Strategies
{
	public interface IMovementStrategy
	{
		/// <summary>
		/// Подвинуть объект
		/// </summary>
		void Move(IAquariumPositionContext aquarium, IAquariumMovableObjectEditable obj);
	}
}
