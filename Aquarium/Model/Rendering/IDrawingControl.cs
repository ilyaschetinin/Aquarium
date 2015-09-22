using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aquarium.Model.Rendering
{
	public interface IDrawingControl
	{
		/// <summary>
		/// Перевернуть ось Y
		/// </summary>
		int InvertY(int currentY);
	}
}
