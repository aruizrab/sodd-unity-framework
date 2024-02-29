using System;

namespace SODD.Core
{
    [Serializable]
    public struct Void
    {
        public static readonly Void Instance = new();
    }
}