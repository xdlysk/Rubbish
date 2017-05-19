using System;
using System.Linq;

namespace Rubbish
{
    /// <summary>
    /// 将给定字符融入原字符中
    /// </summary>
    public class InsertTransform:ITransform
    {
        private readonly string _words;
        private readonly string[] _insert;

        public InsertTransform(string words,string[] insert)
        {
            _words = words;
            _insert = insert;
        }

        public string GetString()
        {
            var words = _words;
            var length = _words.Length;
            var insertlength = _insert.Length;
            var randomposi = Enumerable
                .Range(1, length - 1)
                .OrderBy(x => Guid.NewGuid())
                .Take(insertlength)
                .OrderByDescending(x => x);
            int ii = 0;
            foreach (var i in randomposi)
            {
                words = words.Insert(i, _insert[ii]);
            }
            return words;
        }
    }
}
