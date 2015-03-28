using System;
using System.Data;

namespace Caching.AOP
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CacheAttribute : Attribute
    {
        public TimeSpan LifeSpan
        {
            get {return new TimeSpan(Days, Hours, Minutes, Seconds);}
        }

        public bool Disabled { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public string CacheRegion { get; set; }

        public SerializationFormat SerializationFormat { get; set; }
    }
}
