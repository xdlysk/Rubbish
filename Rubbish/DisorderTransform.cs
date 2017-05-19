using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubbish
{
    /// <summary>
    /// 无序变换
    /// </summary>
    public class DisorderTransform:ITransform
    {
        private readonly string _words;
        private readonly IEnumerable<ITransform> _subTransforms;
        public DisorderTransform(string words)
        {
            _words = words;
        }

        public DisorderTransform(IEnumerable<ITransform> subTransforms)
        {
            _subTransforms = subTransforms;
        }

        public string GetString()
        {
            if (!string.IsNullOrEmpty(_words))
            {
                if (_words.Length==1)
                {
                    return _words;
                }
                return string.Join("", _words.OrderBy(x => Guid.NewGuid()));
            }
            return string.Join("", _subTransforms.OrderBy(x => Guid.NewGuid()).Select(x => x.GetString()));
        }
    }
}
