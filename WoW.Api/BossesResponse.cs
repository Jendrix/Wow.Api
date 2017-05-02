using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Domain;

namespace WoW.Api
{
    public class BossesResponse
    {
        public IEnumerable<Boss> Bosses { get; set; }
    }
}
