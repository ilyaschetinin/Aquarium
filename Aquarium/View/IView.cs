using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Controllers;
using Aquarium.Model;

namespace Aquarium.View
{
	public interface IView
	{
		IAsyncResult BeginInvoke(Delegate method);
		IAsyncResult BeginInvoke(Delegate method, params object[] args);

		/// <summary>
		/// Задать контроллер
		/// </summary>
		void SetController(IAquariumController controller);

		/// <summary>
		/// Обновить рыбок
		/// </summary>
		void UpdateFishes(List<IFish> fishes);
		
		/// <summary>
		/// Обработать исключение
		/// </summary>
		void HandleException(Exception ex);
	}
}
