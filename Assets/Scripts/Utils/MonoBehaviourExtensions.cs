using System;
using UnityEngine;

namespace ARApp.Utils
{
    public static class MonoBehaviourExtensions
    {
        public static TComponent GetComponentStrict<TComponent>(this MonoBehaviour monoBehaviour) 
            where TComponent : Component
        {
            var component = monoBehaviour.GetComponent<TComponent>();
            
            if (!component)
                throw new NullReferenceException($"Cannot find component of type {typeof(TComponent).Name}");
            
            return component;
        }
    }
}