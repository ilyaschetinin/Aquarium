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

			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

			MainForm form = new MainForm();
			AquariumModel model = AquariumModel.Instance;
			AquariumController controller = new AquariumController(form, model);

			Application.Run(form);
		}

		/// <summary>
		/// Обработчик необработанных исключений
		/// </summary>
		static private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			string msg = e.ToString();
			MessageBox.Show(msg);
		}
	}
}
