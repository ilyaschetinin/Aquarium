﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;

namespace Aquarium.Utils
{
	public static class DirectionHelper
	{
		public static readonly int DirectionCount = Enum.GetNames(typeof(Direction)).Length;
	}
}