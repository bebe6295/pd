using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;
using RestSharp;

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

    public class LabelItemsOnlineProvider : IGameItemsProvider<Source>
    {
        private readonly IRestClient _restClient;

        public LabelItemsOnlineProvider(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public IEnumerable<Source> GetGameItems()
        {
            var request = new RestRequest("Games/GetLabelItems", Method.GET);

            var response = _restClient.Execute<List<Source>>(request);

            return response.Data;
        }
    }
}
