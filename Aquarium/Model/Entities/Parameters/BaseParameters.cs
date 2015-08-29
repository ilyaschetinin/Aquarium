using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Strategies;

namespace Aquarium.Model.Entities.Parameters
{
	public class BaseParameters
	{
		/// <summary>
		/// Позиция по оси X
		/// </summary>
		public int X
		{
			get;
			set;
		}

		/// <summary>
		/// Позиция по оси Y
		/// </summary>
		public int Y
		{
			get;
			set;
		}

		/// <summary>
		/// Размер по оси X
		/// </summary>
		public int SizeX
		{
			get;
			set;
		}

		/// <summary>
		/// Размер по оси Y
		/// </summary>
		public int SizeY
		{
			get;
			set;
		}
	}
}
