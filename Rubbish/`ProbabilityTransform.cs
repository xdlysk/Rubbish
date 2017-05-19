using System.Collections.Generic;

namespace Rubbish
{
    /// <summary>
    /// 概率性变换
    /// </summary>
    public abstract class ProbabilityTransform :Transform
    {
        
        protected readonly double Rate;

        /// <summary>
        /// 构造一个带变换比例的字母大小写变换器
        /// </summary>
        /// <param name="words">待变换字符串</param>
        /// <param name="rate">变换比例,对于每个英文字母的变换比率，默认0.5</param>
        protected ProbabilityTransform (string words, double rate)
            : base(words)
        {
            Rate = rate;
        }

        protected ProbabilityTransform (string words) 
            :this(words,0.5)
        {
        }

        /// <summary>
        /// 构造一个带变换比例的字母大小写变换器
        /// </summary>
        /// <param name="subTransforms">待变换的子集合</param>
        /// <param name="rate">变换比例,对于每个英文字母的变换比率，默认0.5</param>
        protected ProbabilityTransform (IEnumerable<ITransform> subTransforms, double rate) : base(subTransforms)
        {
            Rate = rate;
        }

        protected ProbabilityTransform (IEnumerable<ITransform> subTransforms) : this(subTransforms,0.5)
        {
        }
    }
}
