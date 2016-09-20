using System;

namespace LDVELH_WPF.Helpers
{
    interface IClosableViewModel
    {
        event EventHandler CloseWindowEvent;
    }
}
