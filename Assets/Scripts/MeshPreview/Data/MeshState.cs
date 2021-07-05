using UnityEngine;

namespace ARApp.MeshPreview
{
    public struct MeshState
    {
        public readonly Vector3 worldPosition;
        public readonly bool isHidden;

        public MeshState(Vector3 worldPosition, bool hidden)
        {
            this.worldPosition = worldPosition;
            this.isHidden = hidden;
        }
    }

}
