using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Aquarium.Model;
using Aquarium.Model.Factory;
using Aquarium.Model.Enums;
using Aquarium.View.Drawers;
using Aquarium.Properties;

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

			AquariumObjectFactory factory = GetFactory();
			model.Init(new Model.Initialization.AquariumInitializationParameters(form.Size.Width, form.Size.Height), new Model.Initialization.AquariumObjectListInitializer(), factory);
			
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

		private static AquariumObjectFactory GetFactory()
		{
			AquariumObjectFactory factory = new AquariumObjectFactory();

			factory.Register(AquariumObjectType.Fish, new Renderer(Resources.Fish));
			factory.Register(AquariumObjectType.Seaweed, new Renderer(Resources.Seaweed));

			return factory;
		}
	}
}
