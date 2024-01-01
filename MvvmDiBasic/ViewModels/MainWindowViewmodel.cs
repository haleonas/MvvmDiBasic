using MvvmDiBasic.Services;

namespace MvvmDiBasic.ViewModels
{
    public class MainWindowViewmodel: BaseViewModel
    {
		private string _text = "Hej på dig!";

        public string Text
		{
			get => _text;
			set 
			{
				if (_text == value) return;
				_text = value;
				OnPropertyChanged();
			}
		}

		public MainWindowViewmodel(ITestService testService)
		{
			Text = testService.HelloWorld(); 
		}
    }
}
