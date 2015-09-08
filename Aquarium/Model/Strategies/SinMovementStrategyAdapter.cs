using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Position;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Strategies
{
	public class SinMovementStrategyAdapter : IMovementStrategy
	{
		private SinMovementStrategy _strategy;

		public SinMovementStrategyAdapter()
			: this(new SinMovementStrategy())
		{
		}

		public SinMovementStrategyAdapter(SinMovementStrategy strategy)
		{
			_strategy = strategy;
		}

		/// <summary>
		/// Подвинуть объект
		/// </summary>
		public void Move(IAquariumPositionContext aquarium, IAquariumMovableObjectEditable obj)
		{
			_strategy.MoveBySin(aquarium, obj);
		}
	}
}
