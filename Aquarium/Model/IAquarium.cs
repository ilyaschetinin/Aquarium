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
		event EventHandler<ModelUpdatedEventArgs> ModelUpdated;
		event EventHandler<UnhandledErrorEventArgs> UnhandledError;
			
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
