using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.View;
using Aquarium.Model;
using System.Threading.Tasks;
using System.Threading;

namespace Aquarium.Controllers
{
	public class AquariumController : IAquariumController
	{
		#region Constants

		/// <summary>
		/// Частота обновления аквариума в миллисекундах
		/// </summary>
		private const int REFRESH_FREQUENCY_MS = 50;

		#endregion Constants

		#region Fields

		private IView _view;
		private IAquarium _aquarium;

		private Task _task;
		private CancellationTokenSource _cancellationTokenSource;

		#endregion Fields

		#region Constructor

		public AquariumController(IView view, IAquarium aquarium)
		{
			_view = view;
			_aquarium = aquarium;

			view.SetController(this);
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Инициализация аквариума
		/// </summary>
		/// <param name="aquariumSizeX">Ширина аквариума</param>
		/// <param name="aquariumSizeY">Высота аквариума</param>
		public void Init(int aquariumSizeX, int aquariumSizeY)
		{
			_aquarium.Init(aquariumSizeX, aquariumSizeY);
		}

		/// <summary>
		/// Запуск акавариума
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
		/// Остановка акавариума
		/// </summary>
		public void Stop()
		{
			if (_cancellationTokenSource != null)
			{
				_cancellationTokenSource.Cancel();
			}
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

				// Обновление модель
				_aquarium.Move();

				// Обновление представления
				UpdateView(_aquarium.Fishes);

				Thread.Sleep(REFRESH_FREQUENCY_MS);
			}
		}

		/// <summary>
		/// Обновление представления в UI-потоке 
		/// </summary>
		private void UpdateView(List<IFish> fishes)
		{
			Action action = (Action)(() => _view.UpdateFishes(fishes));
			_view.BeginInvoke(action);
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
