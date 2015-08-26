using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;
using System.Collections.ObjectModel;
using Aquarium.Utils;
using Aquarium.Model.Entities;
using Aquarium.Model.Initialization;
using Aquarium.Model.Factory;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Strategies;
using System.Threading.Tasks;
using System.Threading;
using Aquarium.View;

namespace Aquarium.Model
{
	public sealed class AquariumModel : IAquarium, IAquariumContext
	{
		#region Constants

		/// <summary>
		/// Частота обновления аквариума в миллисекундах
		/// </summary>
		private const int REFRESH_FREQUENCY_MS = 50;

		#endregion Constants

		#region Fields
		
		private static volatile AquariumModel _instance;
		private static object syncObj = new Object();

		private Task _task;
		private CancellationTokenSource _cancellationTokenSource;

		private IView _view;

		#endregion Fields

		#region Properties
		
		public static AquariumModel Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (syncObj)
					{
						if (_instance == null)
						{
							_instance = new AquariumModel();
						}
					}
				}

				return _instance;
			}
		}

		/// <summary>
		/// Ширина аквариума
		/// </summary>
		public int SizeX
		{
			get;
			private set;
		}

		/// <summary>
		/// Высота аквариума
		/// </summary>
		public int SizeY
		{
			get;
			private set;
		}

		/// <summary>
		/// Объекты
		/// </summary>
		private List<IAquariumObject> Objects
		{
			get;
			set;
		}

		#endregion Properties

		#region Constructor

		private AquariumModel()
		{
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Инициализация аквариума
		/// </summary>
		public void Init(AquariumInitializationParameters parameters, AquariumObjectListInitializer aquariumObjectListInitializer, AquariumObjectFactory factory, IView view)
		{
			_view = view;

			SizeX = parameters.AquariumSizeX;
			SizeY = parameters.AquariumSizeY;

			Objects = aquariumObjectListInitializer.Init(parameters, factory);
		}

		/// <summary>
		/// Запуск аквариума
		/// </summary>
		public void Start()
		{
			if (_task == null)
			{
				_cancellationTokenSource = new CancellationTokenSource();

				CancellationToken token = _cancellationTokenSource.Token;

				_task = new Task(Loop, token, token);
				_task.ContinueWith(HandleTaskException, token, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
				_task.Start();
			}
		}

		/// <summary>
		/// Остановка аквариума
		/// </summary>
		public void Stop()
		{
			if (_cancellationTokenSource != null)
			{
				_cancellationTokenSource.Cancel();
			}
		}

		/// <summary>
		/// Можно ли передвинуться в указанную позицию
		/// </summary>
		public bool IsValidPosition(int posX, int posY)
		{
			return 0 <= posX && posX <= SizeX &&
				0 <= posY && posY <= SizeY;
		}
				
		/// <summary>
		/// Получить случайную позицию по оси X
		/// </summary>
		public int GetRandomPosX()
		{
			Random random = new Random();
			return random.Next(0, SizeX + 1);
		}

		/// <summary>
		/// Получить случайную позицию по оси Y
		/// </summary>
		public int GetRandomPosY()
		{
			Random random = new Random();
			return random.Next(0, SizeY + 1);
		}

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// Метод для обновления модели и представления
		/// </summary>
		private void Loop(object obj)
		{
			CancellationToken token = (CancellationToken)obj;
			while (true)
			{
				if (token.IsCancellationRequested)
				{
					return;
				}

				// Обновление модели
				Update();

				Thread.Sleep(REFRESH_FREQUENCY_MS);
			}
		}

		/// <summary>
		/// Обновиться
		/// </summary>
		private void Update()
		{
			var movableObjects = Objects.OfType<IAquariumMovableObject>();
			foreach (IAquariumMovableObject movableObject in movableObjects)
			{
				IAquariumContext aquariumContext = this;
				movableObject.Move(aquariumContext);
			}

			_view.OnBeforeUpdate();

			var drawableObjects = Objects.OfType<IAquariumDrawableObject>();
			foreach (IAquariumDrawableObject drawableObject in drawableObjects)
			{
				drawableObject.Draw();
			}
		}

		/// <summary>
		/// Передать в представление исключение из потока модели
		/// </summary>
		private void HandleTaskException(Task task)
		{
			_view.HandleException(task.Exception);
		}
		
		#endregion Private Methods
	}
}
