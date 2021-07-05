using System;
using System.Collections.Generic;

namespace ARApp.Common.DI
{
    public class Container
    {
        private Dictionary<Type, object> container = new Dictionary<Type, object>();

        public void Register<TType>(TType value)
        {
            var type = typeof(TType);
            if (container.ContainsKey(type))
                throw new InvalidOperationException($"Type {type.Name} is already register in container!");

            container.Add(type, value);
        }

        public void Register<T1, TValue>(TValue value) where TValue : T1
        {
            Register<T1>(value);
        }

        public void Register<T1, T2, TValue>(TValue value) where TValue : T1, T2
        {
            Register<T1>(value);
            Register<T2>(value);
        }

        public void Register<T1, T2, T3, TValue>(TValue value) where TValue : T1, T2, T3
        {
            Register<T1>(value);
            Register<T2>(value);
            Register<T3>(value);
        }


        public TType Resolve<TType>()
        {
            var type = typeof(TType);

            if (!container.ContainsKey(type))
                throw new KeyNotFoundException($"Type {type.Name} is not register in container!");

            return (TType)container[type];
        }
    }
}

