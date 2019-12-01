using IronOcr;
using System;
using System.Drawing;
using System.IO;
using System.Web;
using Tesseract;

namespace PracaDyplomowa.WebApi.Services
{
    public interface IOcrReader
    {
        string GetLetter(Stream image);
    }

    public class TesseractOcrReader : IOcrReader
    {
        private readonly string _path;

        public TesseractOcrReader(string path)
        {
            _path = path;
        }

        public string GetLetter(Stream imageFile)
        {
            using (var engine = new TesseractEngine(_path, "eng", EngineMode.Default))
            {
                // have to load Pix via a bitmap since Pix doesn't support loading a stream.
                using (var image = new Bitmap(imageFile))
                {
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = engine.Process(pix, PageSegMode.SingleChar))
                        {
                            return page.GetText().Replace("\n", "");
                        }
                    }
                }
            }
        }
    }
}