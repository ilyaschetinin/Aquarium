using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Parameters;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Strategies;

namespace Aquarium.Model.Entities
{
	public class Seaweed : IAquariumObject, IAquariumDrawableObject
	{
		#region Properties

		/// <summary>
		/// Id рыбки
		/// </summary>
		public int Id
		{
			get;
			private set;
		}

		/// <summary>
		/// Позиция рыбки по оси X
		/// </summary>
		public int X
		{
			get;
			private set;
		}

		/// <summary>
		/// Позиция рыбки по оси Y
		/// </summary>
		public int Y
		{
			get;
			private set;
		}

		/// <summary>
		/// Размер рыбки по оси X
		/// </summary>
		public int SizeX
		{
			get;
			private set;
		}

		/// <summary>
		/// Размер рыбки по оси Y
		/// </summary>
		public int SizeY
		{
			get;
			private set;
		}

		/// <summary>
		/// Рисователь
		/// </summary>
		public IAquariumObjectDrawer Drawer
		{
			get;
			set;
		}

		#endregion Properties

		#region Constructor

		/// <summary>
		/// Конструктор
		/// </summary>
		public Seaweed(IAquariumObjectDrawer drawer, SeaweedParameters parameters)
		{
			Drawer = drawer;

			Id = parameters.Id;
			X = parameters.X;
			Y = parameters.Y;
			SizeX = parameters.SizeX;
			SizeY = parameters.SizeY;
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Нарисовать водоросль
		/// </summary>
		public void Draw()
		{
			if (Drawer != null)
			{
				Drawer.Draw(this);
			}
		}

		#endregion Public Methods
	}
}
