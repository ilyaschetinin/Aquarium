using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aquarium.Model;
using Aquarium.Utils;
using Aquarium.View.Entities;

namespace Aquarium.View.Controls
{
	public partial class AquariumControl : UserControl
	{
		private const int SCALE_MULTIPLIER = 20;

		public AquariumControl()
		{
			InitializeComponent();
		}

		public void Draw(ImageInfo imageInfo)
		{
			using (Graphics graphics = CreateGraphics())
			{
				int x = imageInfo.Point.X - imageInfo.Size.Width / 2;
				//int y = InvertY(imageInfo.Point.Y - imageInfo.Size.Height / 2, this.Height);
				int y = imageInfo.Point.Y - imageInfo.Size.Height / 2;

				int width = imageInfo.Size.Width * SCALE_MULTIPLIER;
				int height = imageInfo.Size.Height * SCALE_MULTIPLIER;
				
				Rectangle rectange = new Rectangle(x, y, width, height);
				graphics.DrawImage(imageInfo.Image, rectange);
			}
		}

		private int InvertY(int y, int maxY)
		{
			return maxY - y;
		}
	}
}
