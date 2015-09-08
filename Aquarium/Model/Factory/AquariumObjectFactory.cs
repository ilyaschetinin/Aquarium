using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Entities;
using Aquarium.Model.Entities.Parameters;
using Aquarium.Model.Enums;
using Aquarium.Model.Strategies;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Rendering;

namespace Aquarium.Model.Factory
{
	public class AquariumObjectFactory
	{
		private readonly List<AquariumTypeDescription> _typeDescriptions;

		private IRendererSelector _rendererSelector;

		public AquariumObjectFactory(IRendererSelector rendererSelector)
		{
			_typeDescriptions = InitTypes();
			_rendererSelector = rendererSelector;
		}

		public IAquariumObject Create(AquariumObjectType aquariumObjectType, BaseParameters parameter)
		{
			AquariumTypeDescription typeDescription = GetTypeDescription(aquariumObjectType);
			
			Type type = typeDescription.ObjectType;
			IAquariumObjectRenderer renderer = _rendererSelector.Get(aquariumObjectType, parameter);
			return (IAquariumObject)Activator.CreateInstance(type, parameter, renderer);
		}
		
		protected List<AquariumTypeDescription> InitTypes()
		{
			List<AquariumTypeDescription> result = new List<AquariumTypeDescription>();

			var aquariumObjectTypes = Enum.GetValues(typeof(AquariumObjectType)).Cast<AquariumObjectType>();
			foreach (var aquariumObjectType in aquariumObjectTypes)
			{
				ObjectTypeAttribute attribute = aquariumObjectType.GetAttribute<ObjectTypeAttribute>();

				result.Add(new AquariumTypeDescription() { AquariumObjectType = aquariumObjectType, ObjectType = attribute.ObjectType });
			}

			return result;
		}

		private AquariumTypeDescription GetTypeDescription(AquariumObjectType aquariumObjectType)
		{
			AquariumTypeDescription typeDescription = _typeDescriptions.FirstOrDefault(t => t.AquariumObjectType == aquariumObjectType);
			if (typeDescription == null)
			{
				throw new ArgumentException("Указанный тип отсутсвует в словаре");
			}
			return typeDescription;
		}

		protected class AquariumTypeDescription
		{
			public AquariumObjectType AquariumObjectType { get; set; }
			public Type ObjectType { get; set; }
		}		
	}
}
