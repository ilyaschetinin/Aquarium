using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Decorators
{
	/// <summary>
	/// Интерфейс класса для обертки объектов в декораторы
	/// </summary>
	public interface IAquariumObjectWrapper
	{
		/// <summary>
		/// Обернуть объект в декораторы
		/// </summary>
		IAquariumObject Wrap(IAquariumObject obj);
	}
}
