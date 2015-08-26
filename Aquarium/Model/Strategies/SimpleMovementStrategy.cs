using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;

namespace Aquarium.Model.Strategies
{
	public class SimpleMovementStrategy : IMovementStrategy
	{
		public void Move(IAquariumContext aquarium, IFishContext fish)
		{
			int x = GetNextPosX(fish);
			if (!aquarium.IsValidPosition(x, fish.Y))
			{
				Direction oppositeDirection = fish.MovementDirection.GetOpposite();
				fish.MovementDirection = oppositeDirection;

				x = GetNextPosX(fish);
			}

			if (aquarium.IsValidPosition(x, fish.Y))
			{
				fish.X = x;
			}
		}

		/// <summary>
		/// Получить следующую координату при движении в заданном направлении
		/// </summary>
		private int GetNextPosX(IFishContext fish)
		{
			int shift = fish.MovementDirection == Direction.Right ? 1 : -1;
			return fish.X + fish.Speed * shift;
		}
	}
}
