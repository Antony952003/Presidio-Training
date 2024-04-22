using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLayer
{
    public class IdGeneration
    {
        public int GenerateId<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary.Count == 0)
                return 101;
            TKey maxKey = dictionary.Keys.Max();
            int id = Convert.ToInt32(maxKey) + 1;
            return id;
        }
    }
}
