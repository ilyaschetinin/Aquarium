using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Entities.Parameters;

namespace Aquarium.Model.Entities
{
	/// <summary>
	/// Базовый объект аквариума
	/// </summary>
	public abstract class AquariumObject : IAquariumObject
	{
		#region Properties
		
		/// <summary>
		/// Позиция объекта по оси X
		/// </summary>
		public int X
		{
			get;
			set;
		}

		/// <summary>
		/// Позиция объекта по оси Y
		/// </summary>
		public int Y
		{
			get;
			set;
		}

		/// <summary>
		/// Размер объекта по оси X
		/// </summary>
		public int SizeX
		{
			get;
			set;
		}

		/// <summary>
		/// Размер объекта по оси Y
		/// </summary>
		public int SizeY
		{
			get;
			set;
		}

		#endregion Properties
				
		#region Constructor

		/// <summary>
		/// Конструктор
		/// </summary>
		public AquariumObject(BaseParameters parameters)
		{
			X = parameters.X;
			Y = parameters.Y;
			SizeX = parameters.SizeX;
			SizeY = parameters.SizeY;
		}

		#endregion Constructor
	}
}
