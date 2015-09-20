using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Position;
using System.Drawing;
using Aquarium.Model.Rendering;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Decorators
{
	public class AquariumHealthDecorator : AquariumMovableObjectDecoratorBase
	{
		#region Private Fields

		private const int HEALTH_DECREASE_TICK_INITIAL_COUNT = 10;
		private int _currentHealthDecreaseTick = HEALTH_DECREASE_TICK_INITIAL_COUNT;

		private IAquariumObjectRenderer _healthRenderer;

		public int Health
		{
			get;
			private set;
		}

		public int HealthDecreaseModifier
		{
			get;
			private set;
		}

		#endregion Private Fields


		#region Public Methods

		public override void Move(IAquariumPositionContext aquarium)
		{
			base.Move(aquarium);

			Tick();
		}

		public override void Draw(IDrawingControl control, Graphics graphics)
		{
			base.Draw(control, graphics);

			_healthRenderer.Render(this, control, graphics);
		}

		private void Tick()
		{
			_currentHealthDecreaseTick--;
			if (_currentHealthDecreaseTick <= 0)
			{
				DecreaseHealth();

				_currentHealthDecreaseTick = HEALTH_DECREASE_TICK_INITIAL_COUNT;
			}
		}

		private void DecreaseHealth()
		{
			Health -= HealthDecreaseModifier;
		}
		
		#endregion Public Methods


		#region Constructor

		public AquariumHealthDecorator(IAquariumMovableObjectEditable aquariumObject, IAquariumObjectRenderer healthRenderer, int health = 100, int healthDecreaseModifier = 1)
			: base(aquariumObject)
		{
			_healthRenderer = healthRenderer;

			Health = health;
			HealthDecreaseModifier = healthDecreaseModifier;
		}

		#endregion Constructor
	}
}
