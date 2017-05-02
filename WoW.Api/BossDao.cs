using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WoW.Domain;

namespace WoW.Api
{
    public class BossDao
    {
        private const string ApiUrl = "https://eu.api.battle.net/wow/boss/";

        public async Task<IEnumerable<Boss>> GetBossesAsync()
        {
            string bossesJson;
            using (var apiClient = new ApiClient())
            {
                bossesJson = await apiClient.GetAsync(ApiUrl);
            }

            var response = JsonConvert.DeserializeObject<BossesResponse>(bossesJson, new JsonSerializerSettings {});
            return response.Bosses;
        }
    }
}
