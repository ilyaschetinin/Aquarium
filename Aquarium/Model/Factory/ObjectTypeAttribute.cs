using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquarium.Model.Factory
{
	internal class ObjectTypeAttribute : Attribute
	{
		public Type ObjectType { get; set; }

		public ObjectTypeAttribute(Type type)
		{
			ObjectType = type;
		}
	}
}
