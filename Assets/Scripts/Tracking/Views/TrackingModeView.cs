using System.Linq;
using ARApp.Common.Views;
using ARApp.Common.Context;
using ARApp.Common.Model;
using UniRx;
using UnityEngine;

namespace ARApp.Tracking.Views
{
    public class TrackingModeView : ContextMonoBehaviour
    {
        [SerializeField]
        private ToggleButton arPlaneToggle;
        [SerializeField]
        private ToggleButton imagePlaneToggle;


        protected override void OnContextInitialized(AppContext context)
        {
            var trackingModeModel = context.Resolve<ITrackingModeModel>();

            arPlaneToggle
                .OnClickedStream
                .Select(_ => TrackingMode.ARPlane)
                .Subscribe(trackingModeModel.ChangeTracking)
                .AddTo(this);

            imagePlaneToggle
                .OnClickedStream
                .Select(_ => TrackingMode.ImagePlane)
                .Subscribe(trackingModeModel.ChangeTracking)
                .AddTo(this);

            context
                .Resolve<IModel<TrackingMode>>()
                .StateStream
                .DistinctUntilChanged()
                .Subscribe(OnChangeTrackingMode)
                .AddTo(this);
        }

        private void OnChangeTrackingMode(TrackingMode trackingMode)
        {
            var isArPlane = trackingMode == TrackingMode.ARPlane;
            arPlaneToggle.ChangeToggle(isArPlane);
            imagePlaneToggle.ChangeToggle(!isArPlane);
        }
    }
}