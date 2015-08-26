using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Strategies;
using Aquarium.Model.Enums;

namespace Aquarium.Model.Entities.Parameters
{
	public class FishParameters : BaseParameters
	{
		/// <summary>
		/// Напраление движения рыбки
		/// </summary>
		public Direction MovementDirection
		{
			get;
			set;
		}

		/// <summary>
		/// Скорость рыбки
		/// </summary>
		public int Speed
		{
			get;
			set;
		}

		/// <summary>
		/// Стратегия движения
		/// </summary>
		public IMovementStrategy MovementStrategy
		{
			get;
			set;
		}
	}
}
