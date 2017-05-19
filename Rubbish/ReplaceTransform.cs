using System;

namespace Rubbish
{
    /// <summary>
    /// 以待替换的字符串随机替代原字符串
    /// </summary>
    public class ReplaceTransform : ITransform
    {
        private readonly string[] _replaces;

        private readonly ITransform[] _transforms;

        public ReplaceTransform(string des, string[] replaces)
        {
            _replaces = replaces;
        }

        public ReplaceTransform(string des, ITransform[] replaces)
        {
            _transforms = replaces;
        }

        public ReplaceTransform(string[] replaces)
        {
            _replaces = replaces;
        }

        public ReplaceTransform(ITransform[] replaces)
        {
            _transforms = replaces;
        }

        private readonly Random _rnd = new Random();

        public string GetString()
        {
            if (_replaces != null)
            {
                var len = _replaces.Length;

                return _replaces[_rnd.Next(0, len*100)%len];
            }
            var len2 = _transforms.Length;
            return _transforms[_rnd.Next(0, len2*100)%len2].GetString();
        }
    }
}
