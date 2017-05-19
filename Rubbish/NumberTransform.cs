using System.Collections.Generic;
using System.Linq;

namespace Rubbish
{
    public class NumberTransform:ProbabilityTransform 
    {
        private readonly string[] _transform =
        {
            "0oO〇零Ⅺº○οΟоО㈄○⒪ⓞ",
            "1一壹Ⅰ①㈠⑴❶¹₁┃",
            "2二贰Ⅱ②㈡⑵❷²₂㉣",
            "3三叁Ⅲ③㈢⑶❸³₃зЗшщШЩ",
            "4四肆Ⅳ④㈣⑷❹⁴₄",
            "5五伍Ⅵ⑤㈤⑸❺",
            "6六陆Ⅶ⑥㈥⑹❻",
            "7七柒Ⅷ⑦㈦⑺❼㉠",
            "8八捌Ⅸ⑧㈧⑻❽",
            "9九玖Ⅹ⑨㈨⑼❾"
        };

        public NumberTransform(string words, double rate) : base(words, rate)
        {
        }

        public NumberTransform(string words) : base(words)
        {
        }

        public NumberTransform(IEnumerable<ITransform> subTransforms, double rate) : base(subTransforms, rate)
        {
        }

        public NumberTransform(IEnumerable<ITransform> subTransforms) : base(subTransforms)
        {
        }

        public override string GetString()
        {
            var origin = base.GetString().ToArray();
            for (int i = 0; i < origin.Length; i++)
            {
                var echar = origin[i];
                if (echar <48 || echar >57)
                {
                    continue;
                }
                if (Rnd.NextDouble() < Rate)
                {
                    var rstring = _transform[echar - 48];
                    origin[i] = rstring[Rnd.Next(1, 140)%rstring.Length];
                }
            }
            return string.Join("", origin);
        }
    }
}
