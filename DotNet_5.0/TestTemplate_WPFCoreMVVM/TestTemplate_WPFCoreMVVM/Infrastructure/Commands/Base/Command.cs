using System;
using System.Windows.Input;

namespace TestTemplate_WPFCoreMVVM.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        private bool _Executable = true;

        public bool Executable
        {
            get => _Executable;
            set
            {
                if (_Executable == value) return;
                _Executable = value;
                ExecutableChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler ExecutableChanged;

        event EventHandler ICommand.CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object parameter) => _Executable && CanExecute(parameter);

        void ICommand.Execute(object parameter)
        {
            if (!((ICommand)this).CanExecute(parameter)) return;
            Execute(parameter);
        }

        protected virtual bool CanExecute(object p) => true;

        protected abstract void Execute(object p);
    }
}
