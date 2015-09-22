using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Population
{
	/// <summary>
	/// Интерфейс для контроля популяции аквариума
	/// </summary>
	public interface IAquariumPopulationController
	{
		/// <summary>
		/// Убрать объект
		/// </summary>
		/// <param name="obj">Объект, который надо убрать</param>
		void Remove(IAquariumObject obj);
	}
}
