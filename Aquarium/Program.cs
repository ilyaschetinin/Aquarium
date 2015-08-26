using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Aquarium.Model;
using Aquarium.Model.Factory;
using Aquarium.Model.Enums;
using Aquarium.View.Drawers;

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

			AquariumObjectFactory factory = GetFactory(form);

			AquariumModel model = AquariumModel.Instance;
			model.Init(new Model.Initialization.AquariumInitializationParameters(form.Size.Width, form.Size.Height), new Model.Initialization.AquariumObjectListInitializer(), factory, form);

			model.Start();

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

		private static AquariumObjectFactory GetFactory(Aquarium.View.IDrawableView drawView)
		{
			AquariumObjectFactory factory = new AquariumObjectFactory();

			factory.Register(AquariumObjectType.Fish, new FishDrawer(drawView));
			factory.Register(AquariumObjectType.Seaweed, new SeaweedDrawer(drawView));

			return factory;
		}
	}
}
