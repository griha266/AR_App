using System;

namespace ARApp.Utils
{
    public struct Option<T>
    {
        private readonly T value;
        private readonly bool hasValue;

        private Option(bool hasValue, T value)
        {
            this.hasValue = hasValue;
            this.value = value;
        }

        public bool HasValue => hasValue;
        public bool TryGetValue(out T value)
        {
            value = this.value;
            return hasValue;
        }

        public static Option<T> Some(T value) => new Option<T>(hasValue: true, value);

        public static Option<T> None = new Option<T>(hasValue: false, value: default(T));

    }
    public static class Option
    {

        public static Option<T> Some<T>(T value) => Option<T>.Some(value);

        public static void Fold<T>(this Option<T> option, Action<T> onSome, Action onNone)
        {
            if (option.TryGetValue(out var value))
                onSome?.Invoke(value);
            else
                onNone?.Invoke();
        }

        public static TResult When<TResult, TValue>(this Option<TValue> option, Func<TValue, TResult> onSome, Func<TResult> onNone)
        {
            if (option.TryGetValue(out var value))
                return onSome(value);
            else
                return onNone();

        }

        public static Option<TResult> Map<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> onSome, Func<TResult> onNone)
        {
            if (option.TryGetValue(out var value))
                return Option.Some(onSome(value));
            else
                return Option<TResult>.None;
        }
    }
}
