using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RandomAsyncNumberGeneration
{
	public partial class MainWindow : Window
	{
		private CancellationTokenSource source;

		public MainWindow()
		{
			InitializeComponent();
			this.cancelGeneration.IsEnabled = false;
		}

		private void cancelGeneration_Click(object sender, RoutedEventArgs e)
		{
			this.source.Cancel(false);
			this.start.IsEnabled = true;
			this.cancelGeneration.IsEnabled = false;
		}

		private async void start_Click(object sender, RoutedEventArgs e)
		{
			this.start.IsEnabled = false;
			this.source = new CancellationTokenSource();
			this.cancelGeneration.IsEnabled = true;

			try
			{
				await this.GenerateAsync(this.source.Token);
			}
			catch (OperationCanceledException) { }
      }

		private async Task GenerateAsync(CancellationToken token)	
		{
			while(true)
			{
				token.ThrowIfCancellationRequested();
				var random = new Random();
				var delay = random.Next(1000);
				await Task.Delay(delay);
				this.numbers.Items.Add(delay);
			}
		}
	}
}
