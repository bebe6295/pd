using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PracaDyplomowa.Mobile.Services
{
    public class LetterItemsProvider : IGameItemsProvider<Source>
    {
        public IEnumerable<Source> GetGameItems()
        {
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceNames()
                           .Where(x => x.StartsWith("PracaDyplomowa.Mobile.Assets.Letters.Small") ||
                                       x.StartsWith("PracaDyplomowa.Mobile.Assets.Letters.Large"))
                           .Select(x => new Source
                           {
                               ImageUri = x,
                               Label = x.Split('.').Reverse().Skip(1).First()
                           });
        }
    }
}
