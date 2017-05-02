using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoW.Api;

namespace WoW.Api.Test
{
    [TestClass]
    public class BaseApiTest
    {
        [TestMethod]
        public void GetBosses_WithValidUri_ShouldSuccess()
        {
            var url = "https://eu.api.battle.net/wow/boss/";
            using (var apiClient = new ApiClient())
            {
                var task = apiClient.GetAsync(url);
                task.Wait();

                Assert.IsNotNull(task.Result);
            }
        }
    }
}
