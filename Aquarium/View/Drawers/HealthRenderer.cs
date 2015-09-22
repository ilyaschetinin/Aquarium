using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Rendering;
using Aquarium.Model.Entities.Interfaces;
using System.Drawing;
using Aquarium.Model.Decorators;

namespace Aquarium.View.Drawers
{
	public class HealthRenderer : IAquariumObjectRenderer
	{
		/// <summary>
		/// Нарисовать здоровье рыбки
		/// </summary>
		public void Render(IAquariumObject obj, IDrawingControl control, Graphics graphics)
		{
			AquariumHealthDecorator healthObj = obj as AquariumHealthDecorator;
			if (healthObj != null)
			{
				int x = obj.X - obj.SizeX / 2;
				int y = control.InvertY(obj.Y + obj.SizeY / 2);

				string health = healthObj.Health.ToString();
				Font font = SystemFonts.MenuFont;

				SizeF sizeHealth = graphics.MeasureString(health, font);
				float sizeX = sizeHealth.Width;
				float sizeY = sizeHealth.Height;

				RectangleF rectangle = new RectangleF(x, y, sizeX, sizeY);

				using (SolidBrush brush = new SolidBrush(Color.Green))
				{
					graphics.DrawString(health, SystemFonts.MenuFont, brush, rectangle);
				}
			}
		}
	}
}
