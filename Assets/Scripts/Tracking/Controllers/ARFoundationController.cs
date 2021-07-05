using UnityEngine;
using UniRx;
using UnityEngine.XR.ARFoundation;
using ARApp.Common.Context;
using ARApp.Common.Model;
using ARApp.MeshPreview;
using ARApp.Utils;

namespace ARApp.Tracking.Controllers
{  
    [RequireComponent(typeof(ARTrackedImageManager))]
    [RequireComponent(typeof(ARPlaneManager))]
    public class ARFoundationController : ContextMonoBehaviour
    {
        private ARTrackedImageManager arTrackedImageManager;
        private ARPlaneManager arPlaneManager;

        private TrackingMode currentMode;
        private IMeshModel meshPreviewModel;

        protected override void OnAwake()
        {
            arTrackedImageManager = this.GetComponentStrict<ARTrackedImageManager>();
            arPlaneManager = this.GetComponentStrict<ARPlaneManager>();

            arTrackedImageManager.enabled = false;
            arPlaneManager.enabled = false;

            arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
            arPlaneManager.planesChanged += OnPlanesChanged;
        }

        protected override void OnContextInitialized(AppContext context)
        {
            context
                .Resolve<IModel<TrackingMode>>()
                .StateStream
                .Subscribe(OnTrackingModeChange)
                .AddTo(this);

            meshPreviewModel = context.Resolve<IMeshModel>();
        }

        private void OnDestroy()
        {
            if (arTrackedImageManager)
                arTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
            if (arPlaneManager)
                arPlaneManager.planesChanged -= OnPlanesChanged;
        }

        private void OnTrackingModeChange(TrackingMode trackingMode)
        {
            currentMode = trackingMode;
            var isArPlane = trackingMode == TrackingMode.ARPlane;
            arTrackedImageManager.enabled = !isArPlane;
            arPlaneManager.enabled = isArPlane;
        }

        private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
        {
            if (currentMode == TrackingMode.ARPlane)
                return;

            var meshHidden = args.added.Count == 0 && args.updated.Count == 0;
            var meshPosition = Vector3.zero;

            foreach (var updatedImage in args.updated)
            {
                meshPosition = updatedImage.transform.position;
            }

            foreach (var addedImage in args.added)
            {
                meshPosition = addedImage.transform.position;
            }

            meshPreviewModel.ChangeMeshVisibility(isHidden: meshHidden);
            meshPreviewModel.ChangeMeshWorldPosition(meshPosition);
        }

        private void OnPlanesChanged(ARPlanesChangedEventArgs args)
        {
            if (currentMode == TrackingMode.ImagePlane)
                return;

            var meshHidden = args.added.Count == 0 && args.updated.Count == 0;
            var meshPosition = Vector3.zero;

            foreach (var updatedPlane in args.updated)
            {
                meshPosition = updatedPlane.center;
            }

            foreach (var addedPlane in args.added)
            {
                meshPosition = addedPlane.center;
            }

            meshPreviewModel.ChangeMeshVisibility(isHidden: meshHidden);
            meshPreviewModel.ChangeMeshWorldPosition(meshPosition);
        }
    }
}



