using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aquarium.Model;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Rendering;

namespace Aquarium.View.Controls
{
	public partial class AquariumControl : UserControl, IDrawingControl
	{
		private const int SCALE_MULTIPLIER = 5;

		private List<IAquariumDrawableObject> _objects;
		
		public AquariumControl()
		{
			InitializeComponent();
			this.SetStyle(
				System.Windows.Forms.ControlStyles.UserPaint |
				System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
				System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
				true);
		}

		public void Draw(List<IAquariumDrawableObject> objects)
		{
			_objects = objects;
			
			Invalidate();
			Update();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (_objects == null)
				return;

			foreach (IAquariumDrawableObject obj in _objects)
			{
				obj.Draw(this, e.Graphics);
			}
		}
	}
}
