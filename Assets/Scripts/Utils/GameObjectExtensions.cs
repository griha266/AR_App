using UnityEngine;
using System.Collections.Generic;

namespace ARApp.Utils
{
    public static class GameObjectExtensions
    {
        public static IEnumerable<GameObject> GetAllChilds(this GameObject gameObject)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i).gameObject;
                yield return child;
                foreach (var nestedChild in child.GetAllChilds())
                {
                    yield return nestedChild;
                }
            }
        }

       
    }
}