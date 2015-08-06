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
		private const int REFRESH_FREQUENCY_MS = 50;

		private IView _view;
		private IAquarium _aquarium;

		private Task _task;
		private CancellationTokenSource _cancellationTokenSource;		

		public AquariumController(IView view, IAquarium aquarium)
		{
			_view = view;
			_aquarium = aquarium;

			view.SetController(this);
		}

		public void Init(int aquariumSizeX, int aquariumSizeY)
		{
			_aquarium.Init(aquariumSizeX, aquariumSizeY);
		}
		
		public void Start()
		{
			if (_task == null)
			{
				_cancellationTokenSource = new CancellationTokenSource();
				
				CancellationToken token = _cancellationTokenSource.Token;

				_task = new Task(Loop, token, token);
				_task.ContinueWith(HandleTaskException, TaskContinuationOptions.OnlyOnFaulted);
				_task.Start();
			}
		}

		public void Stop()
		{
			if (_cancellationTokenSource != null)
			{
				_cancellationTokenSource.Cancel();
			}
		}

		private void Loop(object obj)
		{
			CancellationToken token = (CancellationToken)obj;

			while (true)
			{
				if (token.IsCancellationRequested)
				{
					return;
				}

				_aquarium.Move();

				UpdateView(_aquarium.Fishes);

				Thread.Sleep(REFRESH_FREQUENCY_MS);
			}
		}

		private void UpdateView(List<IFish> fishes)
		{
			Action action = (Action)(() => _view.UpdateFishes(fishes));
			_view.BeginInvoke(action);
		}

		private void HandleTaskException(Task task)
		{
			_view.HandleException(task.Exception);
		}
	}
}
