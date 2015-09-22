using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.Model.Enums;
using System.Collections.ObjectModel;
using Aquarium.Model.Entities;
using Aquarium.Model.Initialization;
using Aquarium.Model.Factory;
using Aquarium.Model.Entities.Interfaces;
using Aquarium.Model.Strategies;
using System.Threading.Tasks;
using System.Threading;
using Aquarium.View;
using Aquarium.Model.Events;
using Aquarium.Model.Rendering;
using Aquarium.Model.Position;
using Aquarium.Model.Population;

namespace Aquarium.Model
{
	public sealed class AquariumModel : IAquarium, IAquariumPopulationController
	{
		#region Constants

		/// <summary>
		/// Частота обновления аквариума в миллисекундах
		/// </summary>
		private const int REFRESH_FREQUENCY_MS = 100;

		#endregion Constants

		#region Fields
		
		private static volatile AquariumModel _instance;
		private static object _syncObj = new Object();

		private Task _task;
		private CancellationTokenSource _cancellationTokenSource;
		private TaskScheduler _taskScheduler;

		private IAquariumPositionContext _positionContext = new AquariumPositionContext();

		private List<IAquariumObject> _objects;

		private List<IAquariumObject> _objectsToRemove = new List<IAquariumObject>();
				
		#endregion Fields

		#region Events

		/// <summary>
		/// Модель обновлена
		/// </summary>
		public event EventHandler<ModelUpdatedEventArgs> ModelUpdated;

		/// <summary>
		/// Необработанная ошибка
		/// </summary>
		public event EventHandler<UnhandledErrorEventArgs> UnhandledError;

		#endregion Events

		#region Properties

		/// <summary>
		/// Экземпляр аквариума
		/// </summary>
		public static AquariumModel Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_syncObj)
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
		/// Объекты
		/// </summary>
		public IEnumerable<IAquariumObject> Objects
		{
			get
			{
				lock (_syncObj)
				{
					foreach (IAquariumObject obj in _objects)
					{
						yield return obj;
					}
				}
			}
		}

		#endregion Properties

		#region Constructor

		/// <summary>
		/// Конструктор
		/// </summary>
		private AquariumModel()
		{
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Инициализация аквариума
		/// </summary>
		public void Init(AquariumInitializationParameters parameters, AquariumObjectListInitializer aquariumObjectListInitializer, AquariumObjectFactory factory)
		{
			_objects = aquariumObjectListInitializer.Init(parameters, _positionContext, factory);

			SetSize(parameters.AquariumSizeX, parameters.AquariumSizeY);
		}

		/// <summary>
		/// Запуск аквариума
		/// </summary>
		public void Start()
		{
			if (_cancellationTokenSource == null)
			{
				_taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

				_cancellationTokenSource = new CancellationTokenSource();
				CancellationToken token = _cancellationTokenSource.Token;

				_task = new Task(Loop, token, token, TaskCreationOptions.LongRunning);
				_task.ContinueWith(HandleTaskException, token, TaskContinuationOptions.OnlyOnFaulted, _taskScheduler);

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
		/// Задать размер аквариума
		/// </summary>
		public void SetSize(int sizeX, int sizeY)
		{
			lock (_syncObj)
			{
				_positionContext.SetSize(sizeX, sizeY);
			}
		}
		
		/// <summary>
		/// Убрать объект
		/// </summary>
		/// <param name="obj">Объект, который надо убрать</param>
		public void Remove(IAquariumObject obj)
		{
			lock (_syncObj)
			{
				_objectsToRemove.Add(obj);
			}
		}		

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// Главный цикл аквариума
		/// </summary>
		private void Loop(object obj)
		{
			CancellationToken token = (CancellationToken)obj;

			while (true)
			{
				if (_cancellationTokenSource.IsCancellationRequested)
					return;

				// Передвигаем объекты
				Move();

				// Удаляем объекты
				ProcessRemovedObjects();

				// Обновляем представление
				Task childTask = Task.Factory.StartNew(RaiseModelUpdated, token, TaskCreationOptions.AttachedToParent, _taskScheduler);
				childTask.Wait();

				Thread.Sleep(REFRESH_FREQUENCY_MS);
			}
		}

		/// <summary>
		/// Передвинуть объекты
		/// </summary>
		private void Move()
		{
			var movableObjects = Objects.OfType<IAquariumMovableObject>();
			foreach (IAquariumMovableObject movableObject in movableObjects)
			{
				IAquariumPositionContext aquariumContext = _positionContext;
				movableObject.Move(aquariumContext);
			}
		}
		
		/// <summary>
		/// Удалить объекты
		/// </summary>
		private void ProcessRemovedObjects()
		{
			lock (_syncObj)
			{
				foreach (IAquariumObject obj in _objectsToRemove)
				{
					_objects.Remove(obj);
				}

				_objectsToRemove.Clear();
			}
		}

		/// <summary>
		/// Передать в представление исключение из потока модели
		/// </summary>
		private void HandleTaskException(Task task)
		{
			RaiseUnhandledError(task.Exception);
		}
		
		/// <summary>
		/// Необработанная ошибка
		/// </summary>
		private void RaiseUnhandledError(Exception ex)
		{
			if (UnhandledError != null)
			{
				UnhandledError(this, new UnhandledErrorEventArgs { Ex = ex });
			}
		}

		/// <summary>
		/// Обновить представление
		/// </summary>
		private void HandleTaskSuccess(Task task)
		{
			RaiseModelUpdated();
		}
		
		/// <summary>
		/// Модель обновлена
		/// </summary>
		private void RaiseModelUpdated()
		{
			if (ModelUpdated != null)
			{
				ModelUpdated(this, new ModelUpdatedEventArgs());
			}
		}

		#endregion Private Methods
	}
}
