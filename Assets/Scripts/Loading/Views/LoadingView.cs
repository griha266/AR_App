using UnityEngine;
using ARApp.Common.Context;
using ARApp.Popup;

namespace ARApp.Loading.Views
{
    public class LoadingView : ContextMonoBehaviour
    {
        [SerializeField]
        private GameObject loadingScreen;

        protected override void OnAwake()
        {
            loadingScreen.SetActive(true);
        }

        protected override void OnContextInitialized(AppContext context)
        {
            loadingScreen.SetActive(false);
            context.Resolve<IPopupModel>().ShowMessage("App is loaded", seconds: 3f);
        }

    }

}
