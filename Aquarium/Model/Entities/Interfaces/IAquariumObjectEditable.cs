using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model.Entities.Interfaces
{
	public interface IAquariumObjectEditable
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
		int SizeX { get; set; }

		/// <summary>
		/// Размер объекта по оси Y
		/// </summary>
		int SizeY { get; set; }
	}
}
