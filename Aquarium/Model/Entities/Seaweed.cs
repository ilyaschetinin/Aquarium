using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities.Parameters;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Strategies;
using System.Drawing;
using Aquarium.Model.Rendering;

namespace Aquarium.Model.Entities
{
	/// <summary>
	/// Водоросль
	/// </summary>
	public class Seaweed : AquariumObject, IAquariumObject, IAquariumDrawableObject
	{
		#region Properties

		/// <summary>
		/// Рисователь
		/// </summary>
		public IAquariumObjectRenderer Renderer
		{
			get;
			set;
		}

		#endregion Properties

		#region Constructor

		/// <summary>
		/// Конструктор
		/// </summary>
		public Seaweed(SeaweedParameters parameters, IAquariumObjectRenderer renderer)
			: base(parameters)
		{
			Renderer = renderer;
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Нарисовать водоросль
		/// </summary>
		public void Draw(IDrawingControl control, Graphics graphics)
		{
			if (Renderer != null)
			{
				Renderer.Render(this, control, graphics);
			}
		}

		#endregion Public Methods
	}
}
