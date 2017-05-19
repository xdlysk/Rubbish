using System;
using System.Collections.Generic;
using System.IO;

namespace Rubbish
{
    /// <summary>
    /// 同音，音近字替换
    /// </summary>
    public class HomophoneTransform : ProbabilityTransform
    {
        static readonly Dictionary<char, string> ReplaceDic = new Dictionary<char, string>();

        /// <summary>
        /// 构造字典
        /// </summary>
        static HomophoneTransform()
        {
            var sr = new StringReader(Resources.replacedic);
            string s;
            while (!string.IsNullOrEmpty(s = sr.ReadLine()))
            {
                foreach (var es in s)
                {
                    try
                    {
                        ReplaceDic.Add(es, s);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(es);
                    }
                    
                }
            }
        }

        public HomophoneTransform(string words, double rate) : base(words, rate)
        {
        }

        public HomophoneTransform(string words) : base(words)
        {
        }

        public HomophoneTransform(IEnumerable<ITransform> subTransforms, double rate) : base(subTransforms, rate)
        {
        }

        public HomophoneTransform(IEnumerable<ITransform> subTransforms) : base(subTransforms)
        {
        }

        public override string GetString()
        {
            var os = base.GetString().ToCharArray();

            for (int i = 0; i < os.Length; i++)
            {
                var cc = os[i];
                if (cc < 0x4e00 || cc > 0x9fa5)
                {
                    continue;
                }
                if (Rnd.NextDouble() > Rate)
                {
                    continue;
                }
                string s;
                if (!ReplaceDic.TryGetValue(cc, out s))
                {
                    continue;
                }
                os[i] = s[Rnd.Next(1, 300)%s.Length];
            }
            return string.Join("", os);
        }
    }
}
