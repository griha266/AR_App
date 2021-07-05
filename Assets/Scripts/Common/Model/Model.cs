using System;
using UniRx;

namespace ARApp.Common.Model
{
    public abstract class Model<TState> : IModel<TState>
    {
        private BehaviorSubject<TState> currentState;

        public Model(TState initialState)
        {
            currentState = new BehaviorSubject<TState>(initialState);
        }

        public TState CurrentState => currentState.Value;
        public IObservable<TState> StateStream => currentState;

        protected void ChangeState(TState newState) => currentState.OnNext(newState);
    }

}
