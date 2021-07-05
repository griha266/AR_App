using UnityEngine;
using UniRx;
using UnityEngine.UI;
using ARApp.Common.Context;

namespace ARApp.MeshPreview.Views
{
    public class MeshAnimationPlayer : ContextMonoBehaviour
    {
        [SerializeField]
        private Animator meshAnimator;

        [SerializeField]
        private Button touchButton;

        protected override void OnAwake()
        {
            var playTriggerId = Animator.StringToHash("play");

            touchButton
                     .OnClickAsObservable()
                     .Subscribe((_) => meshAnimator.SetTrigger(playTriggerId))
                     .AddTo(this);
        }
    }

}
