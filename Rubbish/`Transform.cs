using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubbish
{
    public abstract class Transform:ITransform
    {
        protected readonly Random Rnd = new Random();
        private readonly string _words;
        private readonly IEnumerable<ITransform> _subTransforms;
        protected Transform(string words)
        {
            _words = words;
        }

        protected Transform(IEnumerable<ITransform> subTransforms)
        {
            _subTransforms = subTransforms;
        }


        //protected Transform(ITransform transform,params ITransform[] transforms)
        //{
        //    _subTransforms = new[] {transform};
        //    if (transforms != null)
        //    {
        //        _subTransforms = _subTransforms.Concat(transforms);
        //    }
        //}

        /// <summary>
        /// 确保每次调用都会将所有内部变换重新计算
        /// </summary>
        /// <returns></returns>
        public virtual string GetString()
        {
            if (!string.IsNullOrEmpty(_words))
            {
                return _words;
            }
            return string.Join("", _subTransforms.Select(x => x.GetString()));
        }
    }
}
