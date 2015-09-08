using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Events;

namespace Aquarium.Model
{
	public interface IAquarium
	{
		/// <summary>
		/// Модель обновлена
		/// </summary>
		event EventHandler<ModelUpdatedEventArgs> ModelUpdated;

		/// <summary>
		/// Необработанная ошибка
		/// </summary>
		event EventHandler<UnhandledErrorEventArgs> UnhandledError;
		
		/// <summary>
		/// Объекты
		/// </summary>
		IEnumerable<IAquariumObject> Objects { get; }
			
		/// <summary>
		/// Задать размер аквариума
		/// </summary>
		void SetSize(int sizeX, int sizeY);
				
		/// <summary>
		/// Запуск аквариума
		/// </summary>
		void Start();

		/// <summary>
		/// Остановка аквариума
		/// </summary>
		void Stop();
	}
}
