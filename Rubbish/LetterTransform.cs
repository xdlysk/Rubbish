using System.Collections.Generic;
using System.Linq;

namespace Rubbish
{
    /// <summary>
    /// 针对字母的异形变换
    /// </summary>
    public class LetterTransform : ProbabilityTransform
    {
        private static readonly string[] Transform =
        {
            "⒜ⓐαа",
            "⒝ⓑΒвЬьЪъ",
            "⒞ⓒ",
            "⒟ⓓ",
            "⒠ⓔёЁ",
            "⒡ⓕ",
            "⒢ⓖ",
            "⒣ⓗн",
            "⒤ⓘΙ",
            "⒥ⓙ",
            "⒦ⓚκΚ",
            "⒧ⓛ",
            "⒨ⓜΜм",
            "⒩ⓝΝ",
            "⒪ⓞ○◎οΟ",
            "⒫ⓟρ",
            "⒬ⓠ",
            "⒭ⓡ",
            "⒮ⓢ",
            "⒯ⓣΤт",
            "⒰ⓤμцЦ",
            "⒱ⓥν",
            "⒲ⓦ",
            "⒳ⓧχ",
            "⒴ⓨУ",
            "⒵ⓩ"
        };

        public LetterTransform(string words, double rate) : base(words, rate)
        {
        }

        public LetterTransform(string words) : base(words)
        {
        }

        public LetterTransform(IEnumerable<ITransform> subTransforms, double rate) : base(subTransforms, rate)
        {
        }

        public LetterTransform(IEnumerable<ITransform> subTransforms) : base(subTransforms)
        {
        }

        public override string GetString()
        {
            var origin = base.GetString().ToUpper().ToArray();
            for (int i = 0; i < origin.Length; i++)
            {
                var echar = origin[i];
                if (echar < 65 || echar > 90)
                {
                    continue;
                }
                if (Rnd.NextDouble() < Rate)
                {
                    
                    var rstring = Transform[echar - 65];
                    origin[i] = rstring[Rnd.Next(1, 140) % rstring.Length];
                    
                }
            }
            return string.Join("", origin);
        }
    }
}
