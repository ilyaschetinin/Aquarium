using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aquarium.Utils
{
 	public static class ColorHelper
	{
		private static readonly Random _random = new Random();
		private static readonly KnownColor[] _colorNames = (KnownColor[])Enum.GetValues(typeof(KnownColor));

		/// <summary>
		/// Получить случайный цвет
		/// </summary>
		public static Color GetRandomColor()
		{
			int length = _colorNames.Length;
			int index = _random.Next(length);
			KnownColor randomColorName = _colorNames[index];
			Color randomColor = Color.FromKnownColor(randomColorName);
			return randomColor;
		}
	}
}
