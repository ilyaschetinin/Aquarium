using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Rendering;
using Aquarium.Model.Population;

namespace Aquarium.Model.Decorators
{
	/// <summary>
	/// Класс для обертки объектов в декораторы
	/// </summary>
	public class AquariumObjectWrapper : IAquariumObjectWrapper
	{
		/// <summary>
		/// Рендерер здоровья
		/// </summary>
		private IAquariumObjectRenderer _healthRenderer;

		/// <summary>
		/// Контроллер популяции аквариума
		/// </summary>
		private IAquariumPopulationController _aquariumPopulationController;

		public AquariumObjectWrapper(IAquariumObjectRenderer healthRenderer, IAquariumPopulationController aquariumPopulationController)
		{
			_healthRenderer = healthRenderer;
			_aquariumPopulationController = aquariumPopulationController;
		}

		/// <summary>
		/// Обернуть объект в декораторы
		/// </summary>
		public IAquariumObject Wrap(IAquariumObject obj)
		{
			IAquariumObject result = obj;
			
			IAquariumMovableObjectEditable movableObjEditable = obj as IAquariumMovableObjectEditable;
			if (movableObjEditable != null)
			{
				result = new AquariumHealthDecorator(movableObjEditable, _healthRenderer, _aquariumPopulationController);
			}

			return result;
		}
	}
}
