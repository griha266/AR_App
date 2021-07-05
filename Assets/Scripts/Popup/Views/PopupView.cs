using ARApp.Common.Context;
using ARApp.Common.Model;
using ARApp.Utils;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ARApp.Popup.Views
{
    [RequireComponent(typeof(Animator))]
    public class PopupView : ContextMonoBehaviour
    {

        [SerializeField]
        private Text popupText;

        private Animator animator;
        private int isShowAnimParameterId;
        protected override void OnAwake()
        {
            isShowAnimParameterId = Animator.StringToHash("isShow");
            animator = this.GetComponentStrict<Animator>();
        }

        protected override void OnContextInitialized(AppContext context)
        {
            context
                .Resolve<IModel<PopupState>>()
                .StateStream
                .Select(state => state.Message)
                .Subscribe(OnPopupMessageChange)
                .AddTo(this);
        }

        private void OnPopupMessageChange(Option<string> message)
        {
            message.Fold(
                onSome: message =>
                {
                    animator.SetBool(isShowAnimParameterId, true);
                    popupText.text = message;
                },
                onNone: () =>
                {
                    popupText.text = string.Empty;
                    animator.SetBool(isShowAnimParameterId, false);
                }
            );
        }
    }
}
