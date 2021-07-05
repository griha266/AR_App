using ARApp.Common.Model;
using UnityEngine;

namespace ARApp.MeshPreview
{
    public class MeshModel : Model<MeshState>, IMeshModel
    {
        public MeshModel(MeshState initialState) : base(initialState)
        {
        }

        public void ChangeMeshWorldPosition(Vector3 position)
        {
            ChangeState(new MeshState(position, CurrentState.isHidden));
        }

        public void ChangeMeshVisibility(bool isHidden)
        {
            ChangeState(new MeshState(CurrentState.worldPosition, isHidden));
        }
    }
}
