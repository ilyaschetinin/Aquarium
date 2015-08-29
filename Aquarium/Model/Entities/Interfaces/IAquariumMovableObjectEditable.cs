using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;

namespace Aquarium.Model.Entities.Interfaces
{
	public interface IAquariumMovableObjectEditable
	{
		/// <summary>
		/// Позиция объекта по оси X
		/// </summary>
		int X { get; set; }

		/// <summary>
		/// Позиция объекта по оси Y
		/// </summary>
		int Y { get; set; }

		/// <summary>
		/// Размер объекта по оси X
		/// </summary>
		int SizeX { get; }

		/// <summary>
		/// Размер объекта по оси Y
		/// </summary>
		int SizeY { get; }

		/// <summary>
		/// Напраление движения объекта
		/// </summary>
		Direction MovementDirection { get; set; }

		/// <summary>
		/// Скорость объекта
		/// </summary>
		int Speed { get; set; }
	}
}
