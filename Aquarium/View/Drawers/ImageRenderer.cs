using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.View.Controls;
using System.Drawing;
using Aquarium.Model.Rendering;
using Aquarium.Model.Enums;

namespace Aquarium.View.Drawers
{
	public class ImageRenderer : IAquariumObjectRenderer
	{
		private Image _image;

		private Image _mirroredImage;
		private Image MirroredImage
		{
			get
			{
				if (_mirroredImage == null)
				{
					_mirroredImage = (Image)_image.Clone();
					_mirroredImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
				}

				return _mirroredImage;
			}
		}

		public ImageRenderer(Image image)
		{
			_image = image;
		}
		
		public void Render(IAquariumObject obj, IDrawingControl control, Graphics graphics)
		{			
			int x = obj.X - obj.SizeX / 2;
			int y = InvertY(obj.Y + obj.SizeY / 2, control.Size.Height);
			int sizeX = obj.SizeX;
			int sizeY = obj.SizeY;

			Image image = GetImage(obj);
			Rectangle rectangle = new Rectangle(x, y, sizeX, sizeY);
			graphics.DrawImage(image, rectangle);
		}

		private Image GetImage(IAquariumObject obj)
		{
			Image image = _image;

			// Переделать. Работает медленно
			IAquariumMovableObject movableObj = obj as IAquariumMovableObject;
			if (movableObj != null)
			{
			    if (movableObj.MovementDirection == Direction.Left)
			    {
					image = MirroredImage;
			    }
			}

			return image;
		}

		private int InvertY(int y, int maxY)
		{
			return maxY - y;
		}
	}
}
