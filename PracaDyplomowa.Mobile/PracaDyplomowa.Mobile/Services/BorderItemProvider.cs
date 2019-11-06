using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;

namespace PracaDyplomowa.Mobile.Services
{
    public class BorderItemProvider : IGameItemsProvider<BorderItem>
    {
        public IEnumerable<BorderItem> GetGameItems()
        {
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceNames()
                           .Where(x => x.StartsWith("PracaDyplomowa.Mobile.Assets.Border"))
                           .Select(x => new BorderItem
                           {
                               ImageUri = x,
                               Label = x.Split('.').Reverse().Skip(1).First()
                           });
        }
    }

    public class ItemProvider : IGameItemsProvider<FigureItem>
    {
        public IEnumerable<FigureItem> GetGameItems()
        {
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceNames()
                           .Where(x => x.StartsWith("PracaDyplomowa.Mobile.Assets.Fugure"))
                           .Select(x => new FigureItem
                           {
                               ImageUri = x,
                               Label = x.Split('.').Reverse().Skip(1).First()
                           });
        }
    }
}
