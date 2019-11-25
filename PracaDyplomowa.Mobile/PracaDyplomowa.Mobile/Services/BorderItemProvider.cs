using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;

namespace PracaDyplomowa.Mobile.Services
{
    public class BorderItemProvider : IGameItemsProvider<Source>
    {
        public IEnumerable<Source> GetGameItems()
        {
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceNames()
                           .Where(x => x.StartsWith("PracaDyplomowa.Mobile.Assets.Matching.Border"))
                           .Select(x => new Source
                           {
                               ImageUri = x,
                               Label = x.Split('.').Reverse().Skip(1).First()
                           });
        }
    }

    public class FigureItemProvider : IGameItemsProvider<Source>
    {
        public IEnumerable<Source> GetGameItems()
        {
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceNames()
                           .Where(x => x.StartsWith("PracaDyplomowa.Mobile.Assets.Matching.Figure"))
                           .Select(x => new Source
                           {
                               ImageUri = x,
                               Label = x.Split('.').Reverse().Skip(1).First()
                           });
        }
    }
}
