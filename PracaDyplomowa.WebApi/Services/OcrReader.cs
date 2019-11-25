using IronOcr;
using System;
using System.Drawing;

namespace PracaDyplomowa.WebApi.Services
{
    public interface IOcrReader
    {
        string GetLetter(Bitmap image);
    }

    public class OcrReader : IOcrReader
    {
        public string GetLetter(Bitmap image)
        {
            var ocr = new AutoOcr();

            var result = ocr.Read(image);

            return result.Text;
        }
    }
}