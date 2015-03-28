using System;

namespace Caching
{
    public class NullCache<T> : CacheBase<T>
    {
        public override CacheType CacheType
        {
            get { return CacheType.Null; }
        }

        protected override void InitialiseInternal(){}

        protected override void SetInternal(string key, T value, DateTime expireAt){}

        protected override void SetInternal(string key, T value, TimeSpan expireAt){}

        protected override T GetInternal(string key)
        {
            return default(T);
        }

        protected override void RemoveInternal(string key){}

        protected override bool ExistsInternal(string key)
        {
            return true;
        }
    }
}