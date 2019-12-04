using RestSharp;

namespace PracaDyplomowa.Mobile.Services
{
    public class MobileApiService
    {
        private readonly IRestClient _restClient;

        public MobileApiService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public string CheckWriting(byte[] file)
        {
            var request = new RestRequest("api/WritingRecognition/CheckWriting", Method.POST);
            request.AddFileBytes("photo", file, "photo");

            var response = _restClient.Execute<CheckWritingResponse>(request);

            return response.Data.Text;
        }

        public class CheckWritingResponse
        {
            public string Text { get; set; }
        }
    }
}
