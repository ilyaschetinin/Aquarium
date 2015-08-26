using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model.Strategies
{
	public interface IAquariumContext
	{
		/// <summary>
		/// Можно ли передвинуться в указнную позицию
		/// </summary>
		bool IsValidPosition(int posX, int posY);

		/// <summary>
		/// Получить случайную позицию по оси X
		/// </summary>
		int GetRandomPosX();

		/// <summary>
		/// Получить случайную позицию по оси Y
		/// </summary>
		int GetRandomPosY();
	}
}
