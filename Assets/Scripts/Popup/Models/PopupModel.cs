using System;
using ARApp.Common.Model;
using ARApp.Utils;
using Cysharp.Threading.Tasks;
using UniRx;

namespace ARApp.Popup
{
    public class PopupModel : Model<PopupState>, IPopupModel
    {
        public PopupModel(PopupState initialState) : base(initialState)
        {
        }

        public void ShowMessage(string message, float seconds = 1f)
        {
            resetMessageCancel?.Dispose();

            ChangeState(new PopupState(message: Option.Some(message)));

            resetMessageCancel = ResetMessage(seconds)
                .ToObservable()
                .Subscribe();
        }

        private IDisposable resetMessageCancel;

        private async UniTask ResetMessage(float seconds)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(seconds));
            ChangeState(new PopupState(message: Option<string>.None));
        }


    }

}

