using System;
using System.Collections.Generic;
using System.Text;

namespace TDKRSports.UseCases.PluginInterfaces.StateStore
{
    public interface IStateStore
    {
        void AddStateChangeListeners(Action listener); // registracija za listenere
        void RemoveStateChangeListeners(Action listener);
        void BroadCastStateChange(); //broadcastanje svih listenera
    }
}
