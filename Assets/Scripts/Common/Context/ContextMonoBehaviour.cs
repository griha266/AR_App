using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

namespace ARApp.Common.Context
{
    public abstract class ContextMonoBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            OnAwake();

            AppContext
                .CurrentContext
                .Subscribe(OnContextInitialized)
                .AddTo(this);
        }

        protected virtual void OnAwake() { }

        protected virtual void OnContextInitialized(AppContext context) { }
    }

}
