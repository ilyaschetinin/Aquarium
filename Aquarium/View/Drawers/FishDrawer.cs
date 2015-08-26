using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.View.Controls;
using System.Drawing;
using Aquarium.Utils;
using Aquarium.View.Entities;
using Aquarium.Properties;

namespace Aquarium.View.Drawers
{
	public class FishDrawer : BaseDrawer
	{
		public FishDrawer(IDrawableView drawView)
			: base(drawView)
		{
		}

		protected override ImageInfo GetImage(IAquariumObject obj)
		{
			return new ImageInfo()
			{
				Image = Resources.Fish,
				Point = new Point(obj.X, obj.Y),
				Size = new Size(obj.SizeX, obj.SizeY)
			};
		}
	}
}
