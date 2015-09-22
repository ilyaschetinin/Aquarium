using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Position;
using System.Drawing;
using Aquarium.Model.Rendering;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Population;

namespace Aquarium.Model.Decorators
{
	/// <summary>
	/// Декоратор со здоровьем рыбок
	/// </summary>
	public class AquariumHealthDecorator : AquariumMovableObjectDecoratorBase
	{
		#region Constants

		/// <summary>
		/// Минимальная величина на которую уменьшается здоровье
		/// </summary>
		private const int MIN_HEALTH_DECREASE = 1;

		/// <summary>
		/// Максимальная величина на которую уменьшается здоровье
		/// </summary>
		private const int MAX_HEALTH_DECREASE = 5;

		/// <summary>
		/// Начальное здоровье
		/// </summary>
		private const int INITIAL_HEALTH = 100;

		/// <summary>
		/// Начальное количество тиков до уменьшения здоровья
		/// </summary>
		private const int HEALTH_DECREASE_TICK_INITIAL_COUNT = 5;
		
		#endregion


		#region Private Fields

		/// <summary>
		/// Рандом
		/// </summary>
		private static Random _random = new Random();		

		/// <summary>
		/// Количество тиков до уменьшения здоровья 
		/// </summary>
		private int _currentHealthDecreaseTick = HEALTH_DECREASE_TICK_INITIAL_COUNT;
		
		/// <summary>
		/// Минимальная величина на которую уменьшается здоровье
		/// </summary>
		private int _minHealthDecrease;

		/// <summary>
		/// Максимальная величина на которую уменьшается здоровье
		/// </summary>
		private int _maxHealthDecrease;

		/// <summary>
		/// Рендерер здоровья
		/// </summary>
		private IAquariumObjectRenderer _healthRenderer;

		/// <summary>
		/// Контроллер популяции аквариума
		/// </summary>
		private IAquariumPopulationController _aquariumPopulationController;

		#endregion Private Fields


		#region Properties

		/// <summary>
		/// Здоровье рыбки
		/// </summary>
		public int Health
		{
			get;
			private set;
		}

		#endregion Properties


		#region Public Methods

		/// <summary>
		/// Обработчик движения
		/// </summary>
		public override void Move(IAquariumPositionContext aquarium)
		{
			base.Move(aquarium);

			Tick();
		}

		/// <summary>
		/// Нарисовать здоровье
		/// </summary>
		public override void Draw(IDrawingControl control, Graphics graphics)
		{
			base.Draw(control, graphics);

			_healthRenderer.Render(this, control, graphics);
		}

		/// <summary>
		/// Уменьшить количество тиков до уменьшения здоровья
		/// </summary>
		private void Tick()
		{
			_currentHealthDecreaseTick--;
			if (_currentHealthDecreaseTick <= 0)
			{
				DecreaseHealth();

				// Инициализируем счетчик заново
				_currentHealthDecreaseTick = HEALTH_DECREASE_TICK_INITIAL_COUNT;
			}
		}

		/// <summary>
		/// Уменьшить здоровье
		/// </summary>
		private void DecreaseHealth()
		{
			int healthDecrease = _random.Next(_minHealthDecrease, _maxHealthDecrease + 1);
			Health -= healthDecrease;
			if (Health <= 0)
			{
				Health = 0;

				Die();
			}
		}

		/// <summary>
		/// Умереть
		/// </summary>
		private void Die()
		{
			_aquariumPopulationController.Remove(this);
		}
		
		#endregion Public Methods


		#region Constructor

		/// <summary>
		/// Конструктор
		/// </summary>
		public AquariumHealthDecorator(IAquariumMovableObjectEditable aquariumObject, IAquariumObjectRenderer healthRenderer, IAquariumPopulationController aquariumPopulationController,
			int health = INITIAL_HEALTH, int minHealthDecrease = MIN_HEALTH_DECREASE, int maxHealthDecrease = MAX_HEALTH_DECREASE)
			: base(aquariumObject)
		{
			_healthRenderer = healthRenderer;
			_aquariumPopulationController = aquariumPopulationController;

			Health = health;

			_minHealthDecrease = minHealthDecrease;
			_maxHealthDecrease = maxHealthDecrease;
		}

		#endregion Constructor
	}
}
