using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model
{
	public interface IAquarium
	{
		/// <summary>
		/// Ширина аквариума
		/// </summary>
		int SizeX { get; }

		/// <summary>
		/// Высота аквариума
		/// </summary>
		int SizeY { get; }

		/// <summary>
		/// Рыбки
		/// </summary>
		List<IFish> Fishes { get; }

		/// <summary>
		/// Инициализация аквариума
		/// </summary>
		/// <param name="sizeX">Ширина аквариума</param>
		/// <param name="sizeY">Высота аквариума</param>
		void Init(int sizeX, int sizeY);

		/// <summary>
		/// Инициализация аквариума
		/// </summary>
		/// <param name="sizeX">Ширина аквариума</param>
		/// <param name="sizeY">Высота аквариума</param>
		/// <param name="fishCount">Количество рыбок</param>
		void Init(int sizeX, int sizeY, int fishCount);
		
		/// <summary>
		/// Передвинуть всех рыбок
		/// </summary>
		void Move();
	}
}
