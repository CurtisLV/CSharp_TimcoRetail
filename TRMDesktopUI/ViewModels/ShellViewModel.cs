using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRMDesktopUI.EventModels;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private LoginViewModel _loginVM;
        private IEventAggregator _events;

        public ShellViewModel(LoginViewModel loginVM, IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
            _loginVM = loginVM;
            ActivateItem(_loginVM);
        }

        public void Handle(LogOnEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
