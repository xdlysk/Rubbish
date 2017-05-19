using System.Collections.Generic;

namespace Rubbish
{
    /// <summary>
    /// 不做变换
    /// </summary>
    public class FixedTransform:Transform
    {
        public FixedTransform(string words) : base(words)
        {
        }

        public FixedTransform(IEnumerable<ITransform> subTransforms) : base(subTransforms)
        {
        }
    }
}
