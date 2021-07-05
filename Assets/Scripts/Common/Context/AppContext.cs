using System;
using ARApp.Common.DI;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace ARApp.Common.Context
{
    public abstract class AppContext : MonoBehaviour
    {
        private static Subject<AppContext> currentContext = new Subject<AppContext>();
        public static IObservable<AppContext> CurrentContext => currentContext;        

        public TType Resolve<TType>() => container.Resolve<TType>();

        protected Container container = new Container();
        protected abstract UniTask OnInit();

        private async UniTask Init()
        {
            await OnInit();
            currentContext.OnNext(this);
        }

        private void Awake()
        {
            Init()
                .ToObservable()
                .Subscribe()
                .AddTo(this);
        }
    }

}
