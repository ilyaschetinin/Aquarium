using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Aquarium.Model.Rendering;

namespace Aquarium.Model.Entities.Interfaces
{
	public interface IAquariumDrawableObject
	{
		/// <summary>
		/// Нарисовать объект
		/// </summary>
		void Draw(IDrawingControl control, Graphics graphics);
	}
}
