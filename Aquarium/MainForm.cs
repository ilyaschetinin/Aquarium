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

			aquariumControl.Init(_aquariumModel);
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			_aquariumModel.Start();
		}

		/// <summary>
		/// Обработать исключение
		/// </summary>
		private void HandleException(object sender, UnhandledErrorEventArgs e)
		{
			string msg = e.Ex.ToString();
			MessageBox.Show(msg);
		}
	}
}
