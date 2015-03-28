using System;

namespace Caching
{
    public abstract class CacheBase<T> : ICache<T>
    {
        private readonly NullCache<T> _nullCache = new NullCache<T>();
        private CacheBase<T> _current;
        private bool _intialised;



        protected CacheBase<T> Current
        {
            get
            {
                if (!_intialised)
                {
                    Initialise();
                    _intialised = true;
                }
                return this;
            }
        } //Config return null cache if disabled

        public abstract CacheType CacheType { get; }
        protected abstract void InitialiseInternal();
        protected abstract void SetInternal(string key, T value, DateTime expireAt);
        protected abstract void SetInternal(string key, T value, TimeSpan expireAt);
        protected abstract T GetInternal(string key);
        protected abstract void RemoveInternal(string key);
        protected abstract bool ExistsInternal(string key);
        
        public void Initialise()
        {
            try
            {
                InitialiseInternal();
            }
            catch (Exception)
            {
                //Log Error
                _current = _nullCache;
            }
        }

        public T Get(string key)
        {
            return Current.GetInternal(key);
        }

        public void Set(string key, T value, DateTime expireAt)
        {
            Current.SetInternal(key, value, expireAt);
        }

        public void Set(string key, T value, TimeSpan validFor)
        {
            Current.SetInternal(key, value, validFor);
        }

        public void Remove(string key)
        {
            Current.RemoveInternal(key);
        }

        public bool Exists(string key)
        {
            return Current.ExistsInternal(key);
        }
    }
}