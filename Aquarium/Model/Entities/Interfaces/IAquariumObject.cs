using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model.Entities.Interfaces
{
	public interface IAquariumObject
	{
		/// <summary>
		/// Позиция объекта по оси X
		/// </summary>
		int X { get; }

		/// <summary>
		/// Позиция объекта по оси Y
		/// </summary>
		int Y { get; }

		/// <summary>
		/// Размер объекта по оси X
		/// </summary>
		int SizeX { get; }

		/// <summary>
		/// Размер объекта по оси Y
		/// </summary>
		int SizeY { get; }
	}
}
