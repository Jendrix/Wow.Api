using WoW.Api;

namespace WoW.Bosses
{
    public class DaoFactory
    {
        public static BossDao GetBossDao()
        {
            return new BossDao();
        }
    }
}