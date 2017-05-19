using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubbish
{
    /// <summary>
    /// 在两端添加强调符号
    /// </summary>
    public class EmphasisTransform:Transform
    {
        private static readonly UnicodeRange[] Special = {
            //new UnicodeRange(0xa1,0x17e),
            new UnicodeRange(0x192,0x21b), 
            new UnicodeRange(0x251,0x2a4),
            new UnicodeRange(0x401,0x451),
            new UnicodeRange(0x2500,0x2573),
            new UnicodeRange(0x2581,0x2595),
            new UnicodeRange(0x25a0,0x25e5),
            new UnicodeRange(0x2605,0x2642),
            new UnicodeRange(0x3001,0x303e),
            new UnicodeRange(0x3041,0x309e),    
            new UnicodeRange(0x30a1,0x30fe),
            new UnicodeRange(0x3105,0x3129),   
        };

        struct UnicodeRange
        {
            public UnicodeRange(short start, short end)
            {
                Start = start;
                End = end;
            }

            public short Start;
            public short End;
        }

        private readonly int maxcount = 5;
        
        public EmphasisTransform(string words) : base(words)
        {
        }

        public EmphasisTransform(IEnumerable<ITransform> subTransforms) : base(subTransforms)
        {
        }

        public override string GetString()
        {
            var count = (Rnd.Next(1, 100)%maxcount) + 1;
            return $"{GetSymbols(count)}{base.GetString()}。" ;
        }

        private string GetSymbols(int count)
        {
            var slength = Special.Length;
            return string.Join("",
                Enumerable.Repeat(1,count)
                    .Select(x => Special[Rnd.Next(1, 100)%slength])
                    .Select(x => Encoding.Unicode.GetString(BitConverter.GetBytes((short)Rnd.Next(x.Start, x.End)))));
        }
    }
}
