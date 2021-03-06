﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Rendering;
using Aquarium.Model.Enums;
using Aquarium.Model.Entities.Parameters;
using System.Drawing;
using Aquarium.Properties;
using Aquarium.Model.Strategies;

namespace Aquarium.View.Drawers
{
	public class ImageRendererSelector : IRendererSelector
	{
		private Dictionary<string, ImageRenderer> _renderers = new Dictionary<string, ImageRenderer>();

		/// <summary>
		/// Получить рендерер
		/// </summary>
		public virtual IAquariumObjectRenderer Get(AquariumObjectType aquariumObjectType, BaseParameters parameters)
		{
			string key = GetKey(aquariumObjectType, parameters);

			ImageRenderer renderer;
			if (!_renderers.TryGetValue(key, out renderer))
			{
				renderer = CreateRenderer(aquariumObjectType, parameters);
				_renderers.Add(key, renderer);
			}

			return renderer;
		}

		/// <summary>
		/// Получить ключ рендерера
		/// </summary>
		private string GetKey(AquariumObjectType aquariumObjectType, BaseParameters parameters)
		{
			string key = ((int)aquariumObjectType).ToString();
			
			// Здесь получаются слишком большие строки
			FishParameters fishParameters = parameters as FishParameters;
			if (fishParameters != null && fishParameters.MovementStrategy != null)
			{
				Type movementStrategyType = fishParameters.MovementStrategy.GetType();
				key += movementStrategyType.GUID;
			}

			return key;
		}

		/// <summary>
		/// Создать рендерер
		/// </summary>
		/// <param name="aquariumObjectType"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		private ImageRenderer CreateRenderer(AquariumObjectType aquariumObjectType, BaseParameters parameters)
		{
			ImageRenderer renderer = null;

			Image image = GetImage(aquariumObjectType, parameters);
			if (image != null)
			{
				renderer = new ImageRenderer(image);
			}

			return renderer;
		}

		/// <summary>
		/// Получить изображение объекта
		/// </summary>
		private Image GetImage(AquariumObjectType aquariumObjectType, BaseParameters parameters)
		{
			Image image = null;

			switch (aquariumObjectType)
			{
				case AquariumObjectType.Fish:
					image = GetFishImage(aquariumObjectType, parameters);
					break;
				case AquariumObjectType.Seaweed:
					image = Resources.Seaweed;
					break;
			}

			return image;
		}
		
		/// <summary>
		/// Получить изображение рыбки
		/// </summary>
		private Image GetFishImage(AquariumObjectType aquariumObjectType, BaseParameters parameters)
		{
			FishParameters fishParameters = parameters as FishParameters;
			if (fishParameters != null)
			{
				Type movementStategyType = fishParameters.MovementStrategy.GetType();
				if (movementStategyType == typeof(SinMovementStrategyAdapter))
				{
					return Resources.FishRed;
				}
			}

			return Resources.Fish;
		}
	}
}
