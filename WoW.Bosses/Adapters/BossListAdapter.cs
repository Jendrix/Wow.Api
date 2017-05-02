using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using WoW.Domain;

namespace WoW.Bosses.Adapters
{
    internal class BossListAdapter : BaseAdapter<Boss>
    {
        private readonly IEnumerable<Boss> _bosses;
        private readonly Activity _context;

        public BossListAdapter(Activity activity, IEnumerable<Boss> bosses)
        {
            _bosses = bosses;
            _context = activity;
        }

        public override long GetItemId(int position)
        {
            return _bosses.ElementAt(position).Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _bosses.ElementAt(position);
            var view = convertView ?? _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;
            return view;
        }

        public override int Count => _bosses.Count();

        public override Boss this[int position] => _bosses.ElementAt(position);
    }
}