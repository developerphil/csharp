using System;

namespace Caching
{
    public interface ICache<T>
    {
        T Get(string key);
        void Set(string key, T value, DateTime expireAt);
        void Set(string key, T value, TimeSpan validFor);
        void Remove(string key);
        bool Exists(string key);
    }
}
