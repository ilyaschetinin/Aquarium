using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model.Initialization
{
	public class AquariumInitializationParametersSinFishes : AquariumInitializationParameters
	{
		#region Constants

		/// <summary>
		/// Количество рыбок, движущихся по синусоиде
		/// </summary>
		protected const int SIN_FISH_COUNT = 4;

		#endregion Constants
				
		#region Properties

		/// <summary>
		/// Количество рыбок, движущихся по синусоиде
		/// </summary>
		public int SinFishCount { get; set; }

		#endregion Properties
		
		#region Constructor

		public AquariumInitializationParametersSinFishes(int aquariumSizeX, int aquariumSizeY)
			: base(aquariumSizeX, aquariumSizeY)
		{
			SinFishCount = SIN_FISH_COUNT;
		}

		#endregion Constructor
	}
}
