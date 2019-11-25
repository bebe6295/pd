using PracaDyplomowa.WebApi.Services;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PracaDyplomowa.WebApi.Controllers
{
    public class WritingRecognitionController : ApiController
    {
        private readonly IOcrReader ocrRead;

        public WritingRecognitionController()
        {
            this.ocrRead = new OcrReader();
        }

        public async Task<string> CheckWriting()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                //var buffer = await file.ReadAsByteArrayAsync();
                var bitmap = new Bitmap(await file.ReadAsStreamAsync());
                //new Bitmap(buffer);
                var result = ocrRead.GetLetter(bitmap);
                //Do whatever you want with filename and its binary data.
                return result;
            }

            return string.Empty;
        }
    }
}
