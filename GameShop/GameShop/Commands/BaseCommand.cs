using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameShop.Commands
{
    public class BaseCommand : ICommand
    {
        private Action executeMethod;
        public event EventHandler CanExecuteChanged;

        public BaseCommand(Action executeMethod)
        {
            this.executeMethod = executeMethod;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod();
        }
    }
}
