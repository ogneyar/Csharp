namespace Ex1.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _synchronizedText;
        public string SynchronizedText
        {
            get => _synchronizedText;
            set
            {
                _synchronizedText = value;
                OnPropertyChanged(nameof(SynchronizedText));
            }
        }
    }
}