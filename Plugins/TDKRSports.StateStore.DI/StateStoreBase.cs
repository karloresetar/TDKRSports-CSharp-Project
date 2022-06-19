using TDKRSports.UseCases.PluginInterfaces.StateStore;
using System;

namespace TDKRSports.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action listeners;
        public void AddStateChangeListeners(Action listener) => this.listeners += listener;
        public void RemoveStateChangeListeners(Action listener) => this.listeners -= listener;

        public void BroadCastStateChange()
        {
            if (this.listeners != null) this.listeners.Invoke();
        }

        
    }
}
