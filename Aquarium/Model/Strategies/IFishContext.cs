using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;

namespace Aquarium.Model.Strategies
{
	public interface IFishContext
	{
		/// <summary>
		/// Позиция рыбки по оси X
		/// </summary>
		int X { get; set; }

		/// <summary>
		/// Позиция рыбки по оси Y
		/// </summary>
		int Y { get; set; }

		/// <summary>
		/// Напраление движения рыбки
		/// </summary>
		Direction MovementDirection { get; set; }

		/// <summary>
		/// Скорость рыбки
		/// </summary>
		int Speed { get; set; }
	}
}
