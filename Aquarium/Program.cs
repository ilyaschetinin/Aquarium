using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Aquarium.Controllers;
using Aquarium.Model;

namespace Aquarium
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			MainForm form = new MainForm();
			AquariumModel model = AquariumModel.Instance;
			AquariumController controller = new AquariumController(form, model);

			Application.Run(form);
		}
	}
}
