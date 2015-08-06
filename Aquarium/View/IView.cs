using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Controllers;
using Aquarium.Model;

namespace Aquarium.View
{
	public interface IView
	{
		IAsyncResult BeginInvoke(Delegate method);
		IAsyncResult BeginInvoke(Delegate method, params object[] args);

		void SetController(IAquariumController controller);
		void UpdateFishes(List<IFish> fishes);
		void HandleException(Exception ex);
	}
}
