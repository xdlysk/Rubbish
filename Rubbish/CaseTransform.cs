using System.Collections.Generic;
using System.Linq;

namespace Rubbish
{
    /// <summary>
    /// 字母大小写变换
    /// 此变换只针对字符中的英文字母
    /// 效果：将大写转小写，将小写转大写
    /// </summary>
    public class CaseTransform:ProbabilityTransform 
    {
        public override string GetString()
        {
            var origin = base.GetString().ToArray();

            for (int i = 0; i < origin.Length; i++)
            {
                var echar = origin[i];
                if ((echar < 97 && echar > 122) || (echar < 65 && echar > 90))
                {
                    continue;
                }
                if (Rnd.NextDouble() < Rate)
                {
                    if (echar <= 122)
                    {
                        origin[i] = char.ToUpper(echar);
                    }
                    else
                    {
                        origin[i] = char.ToLower(echar);
                    }
                    
                }
            }
            return string.Join("", origin);
        }

        public CaseTransform(string words, double rate) : base(words, rate)
        {
        }

        public CaseTransform(string words) : base(words)
        {
        }

        public CaseTransform(IEnumerable<ITransform> subTransforms, double rate) : base(subTransforms, rate)
        {
        }

        public CaseTransform(IEnumerable<ITransform> subTransforms) : base(subTransforms)
        {
        }
    }
}
