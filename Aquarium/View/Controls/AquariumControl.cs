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
using Aquarium.Model.Events;

namespace Aquarium.View.Controls
{
	public partial class AquariumControl : UserControl, IDrawingControl
	{
		private const int SCALE_MULTIPLIER = 5;

		private IAquarium _aquarium;

		public AquariumControl()
		{
			InitializeComponent();

			this.SetStyle(
				System.Windows.Forms.ControlStyles.UserPaint |
				System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
				System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
				true);
		}

		public void Init(IAquarium aquarium)
		{
			if (aquarium == null)
				throw new ArgumentNullException("aquarium");

			_aquarium = aquarium;
			_aquarium.ModelUpdated += HandleModelUpdated;

			RefreshSize();
		}

		private void HandleModelUpdated(object sender, ModelUpdatedEventArgs e)
		{			
			Invalidate();
			Update();
		}

		private void AquariumControl_Resize(object sender, EventArgs e)
		{
			RefreshSize();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			var objects = _aquarium.Objects.OfType<IAquariumDrawableObject>();
			foreach (IAquariumDrawableObject obj in objects)
			{
				obj.Draw(this, e.Graphics);
			}
		}

		private void RefreshSize()
		{
			if (_aquarium != null)
			{
				_aquarium.SetSize(this.ClientSize.Width, this.ClientSize.Height);
			}
		}
	}
}
