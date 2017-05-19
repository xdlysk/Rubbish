using System.Linq;

namespace Rubbish
{
    public class CancatTransform:ITransform
    {
        private readonly ITransform _first;
        private readonly ITransform _second;
        private readonly ITransform[] _left;
        public CancatTransform(ITransform first,ITransform second,params ITransform[] left)
        {
            _first = first;
            _second = second;
            _left = left;
        }

        public string GetString()
        {
            var fs = _first.GetString() + _second.GetString();
            if (_left != null && _left.Any())
            {
                return fs + string.Join("", _left.Select(x => x.GetString()));
            }
            return fs;
        }
    }
}
