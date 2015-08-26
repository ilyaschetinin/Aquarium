using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.View
{
	public interface IView
	{		
		/// <summary>
		/// Обработать исключение
		/// </summary>
		void HandleException(Exception ex);

		/// <summary>
		/// Вызывается перед обновлением
		/// </summary>
		void OnBeforeUpdate();
	}
}
