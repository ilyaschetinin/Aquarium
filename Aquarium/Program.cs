using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Aquarium.Model;
using Aquarium.Model.Factory;
using Aquarium.Model.Enums;
using Aquarium.View.Drawers;
using Aquarium.Properties;
using Aquarium.Model.Initialization;
using Aquarium.Model.Rendering;
using Aquarium.Model.Decorators;

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

			AquariumModel model = AquariumModel.Instance;
			MainForm form = new MainForm(model);

			IRendererSelector rendererSelector = new ImageRendererSelector();

			IAquariumObjectRenderer healthRenderer = new HealthRenderer();
			IAquariumObjectWrapper aquariumObjectWrapper = new AquariumObjectWrapper(healthRenderer, model);

			AquariumObjectFactory factory = new AquariumObjectFactory(rendererSelector, aquariumObjectWrapper);
			model.Init(new AquariumInitializationParametersSinFishes(form.Size.Width, form.Size.Height), new AquariumObjectListInitializerSinFishes(), factory);
			
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
