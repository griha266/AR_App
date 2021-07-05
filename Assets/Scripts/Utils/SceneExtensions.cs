using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ARApp.Utils
{
    public static class SceneExtensions
    {
        public static IEnumerable<GameObject> GetAllGameObjects(this Scene scene)
        {
            foreach (var rootGO in scene.GetRootGameObjects())
            {
                yield return rootGO;
                foreach (var child in rootGO.GetAllChilds())
                {
                    yield return child;
                }
            }
        }
    }
}