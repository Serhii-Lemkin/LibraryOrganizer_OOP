using System;
using System.Windows.Input;

namespace BookLib
{
    public class MyCommand : ICommand
    {
        private Action act;
        public MyCommand(Action act) => this.act = act;

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => act?.Invoke();
    }

}
