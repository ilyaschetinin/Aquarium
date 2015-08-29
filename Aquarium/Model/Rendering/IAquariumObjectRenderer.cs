using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Aquarium.Model.Entities.Interfaces;

namespace Aquarium.Model.Rendering
{
	public interface IAquariumObjectRenderer
	{
		void Render(IAquariumObject obj, IDrawingControl control, Graphics graphics);
	}
}
