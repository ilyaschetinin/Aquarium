using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;

namespace Aquarium.Model
{
	public class Fish : IFish
	{
		public const int DEFAULT_SPEED = 10;

		private IAquarium Aquarium
		{
			get;
			set;
		}

		public int Id
		{
			get;
			private set;
		}

		public int X
		{
			get;
			private set;
		}

		public int Y
		{
			get;
			private set;
		}

		public Direction MovementDirection
		{
			get;
			private set;
		}

		public int Speed
		{
			get;
			private set;
		}

		public Fish(IAquarium aquarium, int id, int posX, int posY, Direction direction, int speed = DEFAULT_SPEED)
		{
			Aquarium = aquarium;
			Id = id;
			X = posX;
			Y = posY;
			MovementDirection = direction;
			Speed = speed;
		}

		public void Move()
		{
			if (!CanMove())
			{
				MovementDirection = MovementDirection.GetOpposite();
			}

			if (CanMove())
			{
				X = GetNextPosX(MovementDirection);
			}
		}

		private bool CanMove()
		{
			int nextPosX = GetNextPosX(MovementDirection);
			return IsValid(nextPosX, Y);
		}

		private int GetNextPosX(Direction direction)
		{
			int shift = MovementDirection == Direction.Right ? 1 : -1;
			return X + Speed * shift;
		}

		private bool IsValid(int posX, int posY)
		{
			return 0 <= posX && posX <= Aquarium.SizeX &&
				0 <= posY && posY <= Aquarium.SizeY;
		}
			
	}
}
