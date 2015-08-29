using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Position
{
	public interface IAquariumPositionContext
	{
		/// <summary>
		/// Получить наименьшее значение координаты по оси X
		/// </summary>
		int MinX { get; }

		/// <summary>
		/// Получить наименьшее значение координаты по оси Y
		/// </summary>
		int MinY { get; }

		/// <summary>
		/// Ширина аквариума
		/// </summary>
		int SizeX { get; }

		/// <summary>
		/// Высота аквариума
		/// </summary>
		int SizeY { get; }

		/// <summary>
		/// Можно ли передвинуться в указнную позицию
		/// </summary>
		bool IsValidPosition(int posX, int posY);

		/// <summary>
		/// Находится ли позиция за границей аквариума
		/// </summary>
		bool IsPositionOutsideBorders(int posX, int posY);

		/// <summary>
		/// Получить случайную позицию по оси X
		/// </summary>
		int GetRandomPosX();

		/// <summary>
		/// Получить случайную позицию по оси Y
		/// </summary>
		int GetRandomPosY();

		/// <summary>
		/// Задать размер аквариума
		/// </summary>
		void SetSize(int sizeX, int sizeY);

		/// <summary>
		/// Скорректировать позицию объекта
		/// </summary>
		void FixPosition(IAquariumMovableObjectEditable obj);
	}
}
