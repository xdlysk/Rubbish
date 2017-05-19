using System.Collections.Generic;
using System.Linq;

namespace Rubbish
{
    /// <summary>
    /// 用分隔符连接多个变换
    /// </summary>
    public class JoinTransform:ITransform
    {
        private readonly IEnumerable<ITransform> _tranforms;
        private readonly ITransform _seprator;
        public JoinTransform(IEnumerable<ITransform> transforms,ITransform seprator=null)
        {
            _seprator = seprator;
            _tranforms = transforms;
        }

        public string GetString()
        {
            return string.Join(_seprator?.GetString() ?? "", _tranforms.Select(x => x.GetString()));
        }
    }
}
