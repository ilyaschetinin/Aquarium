using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Position;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Enums;

namespace Aquarium.Model.Strategies
{
	internal class SinMovementStrategy
	{
		/// <summary>
		/// Подвинуть объект
		/// </summary>
		public void MoveBySin(IAquariumPositionContext aquarium, IAquariumMovableObjectEditable obj)
		{
			if (aquarium.IsPositionOutsideBorders(obj.X, obj.Y))
			{
				aquarium.FixPosition(obj);
			}
			else
			{
				int shiftX = obj.MovementDirection == Direction.Right ? 1 : -1;
				int nextX = obj.X + shiftX * (obj.Speed / 10 + obj.SizeX / 2);

				int shiftY = Convert.ToInt32(Math.Sin(DateTime.Now.Second) * 10);
				int nextY = obj.Y + shiftY;

				// Можно ли передвинуться в текущем направлении движения
				bool canMove = aquarium.IsValidPosition(nextX, nextY);
				if (!canMove)
				{
					// Пробуем поменять направление движения
					Direction oppositeDirection = obj.MovementDirection.GetOpposite();
					obj.MovementDirection = oppositeDirection;

					shiftX = obj.MovementDirection == Direction.Right ? 1 : -1;
					nextX = nextX = obj.X + shiftX * (obj.Speed / 10 + obj.SizeX / 2);

					canMove = aquarium.IsValidPosition(nextX, nextY);
				}

				// Повторно проверяем, что можем передвинуться
				if (canMove)
				{
					obj.X = nextX;
					obj.Y = nextY;
				}
			}
		}
	}

}
