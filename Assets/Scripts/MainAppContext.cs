using UnityEngine;
using Cysharp.Threading.Tasks;
using ARApp.Common.Context;
using ARApp.Common.Model;
using ARApp.Tracking;
using ARApp.MeshPreview;
using ARApp.Popup;
using ARApp.Utils;
using TimeSpan = System.TimeSpan;

namespace ARApp
{
    public class MainAppContext : AppContext
    {
        protected override async UniTask OnInit()
        {
            container
                .Register<IModel<TrackingMode>, ITrackingModeModel, TrackingModeModel>(
                    new TrackingModeModel(TrackingMode.ARPlane)
                );

            
            container
                .Register<IModel<MeshState>, IMeshModel, MeshModel>(
                    new MeshModel(
                        new MeshState(
                            worldPosition: Vector3.zero,
                            hidden: true
                        )
                    )
                );
            
            container
                .Register<IModel<PopupState>, IPopupModel, PopupModel>(
                    new PopupModel(
                        new PopupState(
                            message: Option<string>.None
                        )
                    )
                );
            
            // For showing loading screen
            await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
        }
    }


}
