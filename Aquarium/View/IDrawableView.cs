using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Aquarium.View.Entities;

namespace Aquarium.View
{
	public interface IDrawableView
	{
		void Draw(ImageInfo imageInfo);
	}
}
