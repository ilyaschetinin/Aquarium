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
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Events;

namespace Aquarium
{
	public partial class MainForm : Form
	{
		private IAquarium _aquariumModel;
		
		public MainForm(IAquarium aquariumModel)
		{
			InitializeComponent();
			
			_aquariumModel = aquariumModel;
			_aquariumModel.UnhandledError += HandleException;
			_aquariumModel.ModelUpdated += HandleModelUpdated;

			_aquariumModel.SetSize(aquariumControl.ClientSize.Width, aquariumControl.ClientSize.Height);
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			_aquariumModel.Start();
		}

		/// <summary>
		/// Обновить представление
		/// </summary>
		private void HandleModelUpdated(object sender, ModelUpdatedEventArgs e)
		{
			aquariumControl.Draw(e.Objects);
		}

		/// <summary>
		/// Обработать исключение
		/// </summary>
		private void HandleException(object sender, UnhandledErrorEventArgs e)
		{
			string msg = e.Ex.ToString();
			MessageBox.Show(msg);
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			_aquariumModel.SetSize(aquariumControl.ClientSize.Width, aquariumControl.ClientSize.Height);
		}
	}
}
