using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;

namespace PracaDyplomowa.Mobile.Services
{
    public class LabelItemsProvider : IGameItemsProvider<Source>
    {
        public IEnumerable<Source> GetGameItems()
        {
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceNames()
                           .Where(x => x.StartsWith("PracaDyplomowa.Mobile.Assets.Labeling"))
                           .Select(x => new Source
                           {
                               ImageUri = x,
                               Label = x.Split('.').Reverse().Skip(1).First()
                           });
        }
    }
}
