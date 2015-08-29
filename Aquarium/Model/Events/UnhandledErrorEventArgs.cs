using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model.Events
{
	public class UnhandledErrorEventArgs : EventArgs
	{
		public Exception Ex { get; set; }
	}
}
