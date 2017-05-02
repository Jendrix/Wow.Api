using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WoW.Api.Test
{
    [TestClass]
    public class BossDaoTest
    {
        [TestMethod]
        public void GetBosses_ShouldSuccess()
        {
            var bossDao = new BossDao();

            var result = bossDao.GetBossesAsync().Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }
    }
}
