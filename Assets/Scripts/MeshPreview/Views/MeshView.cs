using UnityEngine;
using UniRx;
using ARApp.Common.Context;
using ARApp.Common.Model;

namespace ARApp.MeshPreview.Views
{
    public class MeshView : ContextMonoBehaviour
    {
        [SerializeField]
        private GameObject meshRoot;

        protected override void OnAwake()
        {
            meshRoot.SetActive(false);
        }

        protected override void OnContextInitialized(AppContext context)
        {
            context
                .Resolve<IModel<MeshState>>()
                .StateStream
                .DistinctUntilChanged()
                .Subscribe(OnMeshPreviewStateChange)
                .AddTo(this);
        }

        private void OnMeshPreviewStateChange(MeshState stateData)
        {
            meshRoot.SetActive(!stateData.isHidden);
            meshRoot.transform.position = stateData.worldPosition;
        }
    }
}
