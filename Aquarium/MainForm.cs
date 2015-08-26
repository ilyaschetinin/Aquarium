using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aquarium.View;
using Aquarium.Model;
using Aquarium.View.Entities;
using Aquarium.Utils;

namespace Aquarium
{
	public partial class MainForm : Form, IView, IDrawableView
	{
		public MainForm()
		{
			InitializeComponent();

			this.DoubleBuffered = true;
		}

		public void Draw(ImageInfo imageInfo)
		{
			this.UIThread(() =>
			{
				aquariumControl.Draw(imageInfo);
			});
		}

		/// <summary>
		/// Вызывается перед обновлением
		/// </summary>
		public void OnBeforeUpdate()
		{
			this.UIThread(() =>
			{
				aquariumControl.Invalidate();
				aquariumControl.Update();
			});
		}

		/// <summary>
		/// Обработать исключение
		/// </summary>
		public void HandleException(Exception ex)
		{
			this.UIThread(() =>
			{
				string msg = ex.ToString();
				MessageBox.Show(msg);
			});
		}

		//protected override void OnShown(EventArgs e)
		//{
		//    base.OnShown(e);

		//    // Задаем размеры аквариума
		//    int x = aquariumControl.Size.Width;
		//    int y = aquariumControl.Size.Height;
		//    _controller.Init(x, y);

		//    // Запускаем аквариум
		//    _controller.Start();
		//}
	}
}
