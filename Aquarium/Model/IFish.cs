using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;

namespace Aquarium.Model
{
	public interface IFish
	{
		/// <summary>
		/// Id рыбки
		/// </summary>
		int Id { get; }

		/// <summary>
		/// Позиция рыбки по оси X
		/// </summary>
		int X { get; }

		/// <summary>
		/// Позиция рыбки по оси Y
		/// </summary>
		int Y { get; }

		/// <summary>
		/// Напраление движения рыбки
		/// </summary>
		Direction MovementDirection { get; }

		/// <summary>
		/// Скорость рыбки
		/// </summary>
		int Speed { get; }
	}
}
