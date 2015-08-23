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

namespace Aquarium.Controls
{
	public partial class AquariumControl : UserControl
	{
		private const int FISH_WIDTH = 20;
		private const int FISH_HEIGHT = 20;

		private List<IFish> _fishes;
		private Dictionary<int, Color> _fishColors = new Dictionary<int,Color>();		

		public AquariumControl()
		{
			InitializeComponent();
		}
		
		/// <summary>
		/// Обновить рыбок
		/// </summary>
		public void UpdateFishes(List<IFish> fishes)
		{
			_fishes = fishes;
			this.Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (_fishes == null)
				return;

			foreach (IFish fish in _fishes)
			{
				Color color = GetColor(fish.Id);
				using (Brush brush = new SolidBrush(color))
				{
					int x = fish.X - FISH_WIDTH / 2;
					int y = fish.Y - FISH_HEIGHT / 2;
					Rectangle rectangle = new Rectangle(x, y, FISH_WIDTH, FISH_HEIGHT);

					e.Graphics.FillEllipse(brush, rectangle);
				}
			}
		}

		/// <summary>
		/// Получение цвета рыбки
		/// </summary>
		private Color GetColor(int fishId)
		{
			Color color;

			if (_fishColors.ContainsKey(fishId))
			{
				// За данной рыбкой уже закреплен цвет
				color = _fishColors[fishId];
			}
			else
			{
				// Присваиваем рыбке случайный цвет
				color = ColorHelper.GetRandomColor();
				_fishColors[fishId] = color;				
			}

			return color;
		}
	}
}
