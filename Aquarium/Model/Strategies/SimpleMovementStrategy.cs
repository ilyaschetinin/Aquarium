using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;
using Aquarium.Model.Position;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Strategies
{
	public class SimpleMovementStrategy : IMovementStrategy
	{
		/// <summary>
		/// Подвинуть объект
		/// </summary>
		public void Move(IAquariumPositionContext aquarium, IAquariumMovableObjectEditable obj)
		{
			if (aquarium.IsPositionOutsideBorders(obj.X, obj.Y))
			{
				MoveBackToAquarium(aquarium, obj);
			}
			else
			{
				MoveAsUsual(aquarium, obj);
			}
		}

		/// <summary>
		/// Объект ушел за пределы акварима
		/// </summary>
		private void MoveBackToAquarium(IAquariumPositionContext aquarium, IAquariumMovableObjectEditable obj)
		{
			aquarium.FixPosition(obj);
		}

		/// <summary>
		/// Обычный алгоритм движения
		/// </summary>
		private void MoveAsUsual(IAquariumPositionContext aquarium, IAquariumMovableObjectEditable obj)
		{
			int nextX = GetNextPosX(obj);

			// Можно ли передвинуться в текущем направлении движения
			bool canMove = aquarium.IsValidPosition(nextX, obj.Y);
			if (!canMove)
			{
				// Пробуем поменять направление движения
				Direction oppositeDirection = obj.MovementDirection.GetOpposite();
				obj.MovementDirection = oppositeDirection;

				nextX = GetNextPosX(obj);

				canMove = aquarium.IsValidPosition(nextX, obj.Y);
			}

			// Повторно проверяем, что можем передвинуться
			if (canMove)
			{
				obj.X = nextX;
			}
		}

		/// <summary>
		/// Получить следующую координату при движении в заданном направлении
		/// </summary>
		private int GetNextPosX(IAquariumMovableObjectEditable obj)
		{
			int shift = obj.MovementDirection == Direction.Right ? 1 : -1;
			return obj.X + shift * (obj.Speed + obj.SizeX / 2); 
		}
	}
}
