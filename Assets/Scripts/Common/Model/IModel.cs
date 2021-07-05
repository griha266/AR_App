using System;

namespace ARApp.Common.Model
{
    public interface IModel<TState>
    {
        TState CurrentState { get; }
        IObservable<TState> StateStream { get; }
    }

}
