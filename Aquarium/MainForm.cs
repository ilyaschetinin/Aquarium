using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aquarium.View;
using Aquarium.Controllers;
using Aquarium.Model;

namespace Aquarium
{
	public partial class MainForm : Form, IView
	{
		private IAquariumController _controller;

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Задать контроллер
		/// </summary>
		public void SetController(Controllers.IAquariumController controller)
		{
			_controller = controller;
		}

		/// <summary>
		/// Обновить рыбок
		/// </summary>
		public void UpdateFishes(List<IFish> fishes)
		{
			aquariumControl.UpdateFishes(fishes);
		}

		/// <summary>
		/// Обработать исключение
		/// </summary>
		public void HandleException(Exception ex)
		{
			string msg = ex.ToString();
			MessageBox.Show(msg);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			// Задаем размеры аквариума
			int x = aquariumControl.Size.Width;
			int y = aquariumControl.Size.Height;
			_controller.Init(x, y);

			// Запускаем аквариум
			_controller.Start();
		}
	}
}
