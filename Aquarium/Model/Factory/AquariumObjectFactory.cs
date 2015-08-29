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

		public AquariumObjectFactory()
		{
			_typeDescriptions = InitTypes();
		}

		public IAquariumObject Create(AquariumObjectType aquariumObjectType, BaseParameters parameter)
		{
			AquariumTypeDescription typeDescription = GetTypeDescription(aquariumObjectType);
			
			Type type = typeDescription.ObjectType;
			IAquariumObjectRenderer renderer = typeDescription.Renderer;
			return (IAquariumObject)Activator.CreateInstance(type, renderer, parameter);
		}

		public void Register(AquariumObjectType aquariumObjectType, IAquariumObjectRenderer renderer)
		{
			AquariumTypeDescription typeDescription = GetTypeDescription(aquariumObjectType);
			typeDescription.Renderer = renderer;
		}
		
		protected virtual List<AquariumTypeDescription> InitTypes()
		{
			return new List<AquariumTypeDescription>()
			{
				new AquariumTypeDescription() { AquariumObjectType = AquariumObjectType.Fish, ObjectType = typeof(Fish) },
				new AquariumTypeDescription() { AquariumObjectType = AquariumObjectType.Seaweed, ObjectType = typeof(Seaweed) }
			};
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
			public IAquariumObjectRenderer Renderer { get; set; }
		}		
	}
}
