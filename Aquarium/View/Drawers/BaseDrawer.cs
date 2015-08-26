using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Utils;
using Aquarium.View.Controls;
using System.Drawing;
using Aquarium.View.Entities;

namespace Aquarium.View.Drawers
{
	public abstract class BaseDrawer : IAquariumObjectDrawer
	{
		private IDrawableView _drawView;

		protected abstract ImageInfo GetImage(IAquariumObject obj);

		public BaseDrawer(IDrawableView drawView)
		{
			_drawView = drawView;
		}

		public void Draw(IAquariumObject obj)
		{
			ImageInfo image = GetImage(obj);
			_drawView.Draw(image);
		}
	}
}
