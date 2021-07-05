using UnityEngine;

namespace ARApp.MeshPreview
{
    public interface IMeshModel
    {
        void ChangeMeshVisibility(bool isHidden);
        void ChangeMeshWorldPosition(Vector3 position);
    }

}

