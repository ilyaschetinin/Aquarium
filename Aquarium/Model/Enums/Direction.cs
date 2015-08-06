using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model.Enums
{
	/// <summary>
	/// Направление
	/// </summary>
	public enum Direction
	{
		Left = 0,
		Right = 1
	}

	public static class DirectionExtension
	{
		/// <summary>
		/// Получить противоположное направление
		/// </summary>
		public static Direction GetOpposite(this Direction direction)
		{
			return direction == Direction.Left ? Direction.Right : Direction.Left;
		}
	}
}
