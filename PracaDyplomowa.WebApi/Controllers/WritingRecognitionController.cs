using PracaDyplomowa.WebApi.Services;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PracaDyplomowa.WebApi.Controllers
{
    public class WritingRecognitionController : ApiController
    {
        private readonly IOcrReader _ocrRead;

        public WritingRecognitionController()
        {
            _ocrRead = new TesseractOcrReader(HttpContext.Current.Server.MapPath(@"~/tessdata"));
        }

        public async Task<CheckWritingResponse> CheckWriting()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var stream = await file.ReadAsStreamAsync();
                var result = _ocrRead.GetLetter(stream);
                return new CheckWritingResponse { Text = result };
            }

            return new CheckWritingResponse { Text = string.Empty };
        }

        public class CheckWritingResponse
        {
            public string Text { get; set; }
        }
    }
}
