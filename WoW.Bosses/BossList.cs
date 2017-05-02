using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using WoW.Bosses.Adapters;
using WoW.Api;

namespace WoW.Bosses
{
    [Activity(Label = "WOW Bosses", MainLauncher = true, Icon = "@drawable/icon")]
    public class BossList: AppCompatActivity
    {
        private BossDao _bossDao;
        private EditText _searchText;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.BossList);

            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.BossListToolbar);
            SetSupportActionBar(toolBar);

            _bossDao = DaoFactory.GetBossDao();
            var bosses = await _bossDao.GetBossesAsync();

            var bossList = FindViewById<ListView>(Resource.Id.BossList);
            bossList.Adapter = new BossListAdapter(this, bosses);
            bossList.FastScrollEnabled = true;            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.OptionsMenu, menu);

            return base.OnCreateOptionsMenu(menu);
        }
    }
}

