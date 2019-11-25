using PracaDyplomowa.Mobile.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracaDyplomowa.Mobile.Services
{
    public class MatchItemsProvider
    {
        public IEnumerable<MatchItem> GetMatchItems()
        {
            var borders = new BorderItemProvider();
            var figures = new FigureItemProvider();

            var f = figures.GetGameItems();
            return borders.GetGameItems().Select(x => new MatchItem
            {
                Border = x,
                Figure = f.FirstOrDefault(y => y.Label.Equals(x.Label, StringComparison.CurrentCultureIgnoreCase))
            }).Where(x => x.Figure != null).OrderBy(x => Guid.NewGuid());
        }
    }

    public class MatchItem
    {
        public Source Border { get; set; }
        public Source Figure { get; set; }
    }
}
