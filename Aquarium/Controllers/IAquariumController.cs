using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Controllers
{
	public interface IAquariumController
	{
		/// <summary>
		/// Инициализация аквариума
		/// </summary>
		/// <param name="aquariumSizeX">Ширина аквариума</param>
		/// <param name="aquariumSizeY">Высота аквариума</param>
		void Init(int aquariumSizeX, int aquariumSizeY);

		/// <summary>
		/// Запуск акавариума
		/// </summary>
		void Start();

		/// <summary>
		/// Остановка акавариума
		/// </summary>
		void Stop();	
	}
}
