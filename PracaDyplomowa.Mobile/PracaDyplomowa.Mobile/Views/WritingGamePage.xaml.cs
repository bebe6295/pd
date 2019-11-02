using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracaDyplomowa.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WritingGamePage : ContentPage
    {
        Dictionary<long, SKPath> inProgressPaths = new Dictionary<long, SKPath>();
        List<SKPath> completedPaths = new List<SKPath>();

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 10,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };

        SKBitmap saveBitmap;

        public WritingGamePage()
        {
            InitializeComponent();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            // Create bitmap the size of the display surface
            if (saveBitmap == null)
            {
                saveBitmap = new SKBitmap(info.Width, info.Height);
            }
            // Or create new bitmap for a new size of display surface
            else if (saveBitmap.Width < info.Width || saveBitmap.Height < info.Height)
            {
                SKBitmap newBitmap = new SKBitmap(Math.Max(saveBitmap.Width, info.Width),
                                                  Math.Max(saveBitmap.Height, info.Height));

                using (SKCanvas newCanvas = new SKCanvas(newBitmap))
                {
                    newCanvas.Clear();
                    newCanvas.DrawBitmap(saveBitmap, 0, 0);
                }

                saveBitmap = newBitmap;
            }

            // Render the bitmap
            canvas.Clear();
            canvas.DrawBitmap(saveBitmap, 0, 0);
        }

        //void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        //{
        //    switch (args.Type)
        //    {
        //        case TouchActionType.Pressed:
        //            if (!inProgressPaths.ContainsKey(args.Id))
        //            {
        //                SKPath path = new SKPath();
        //                path.MoveTo(ConvertToPixel(args.Location));
        //                inProgressPaths.Add(args.Id, path);
        //                UpdateBitmap();
        //            }
        //            break;

        //        case TouchActionType.Moved:
        //            if (inProgressPaths.ContainsKey(args.Id))
        //            {
        //                SKPath path = inProgressPaths[args.Id];
        //                path.LineTo(ConvertToPixel(args.Location));
        //                UpdateBitmap();
        //            }
        //            break;

        //        case TouchActionType.Released:
        //            if (inProgressPaths.ContainsKey(args.Id))
        //            {
        //                completedPaths.Add(inProgressPaths[args.Id]);
        //                inProgressPaths.Remove(args.Id);
        //                UpdateBitmap();
        //            }
        //            break;

        //        case TouchActionType.Cancelled:
        //            if (inProgressPaths.ContainsKey(args.Id))
        //            {
        //                inProgressPaths.Remove(args.Id);
        //                UpdateBitmap();
        //            }
        //            break;
        //    }
        //}

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                               (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));
        }

        void UpdateBitmap()
        {
            using (SKCanvas saveBitmapCanvas = new SKCanvas(saveBitmap))
            {
                saveBitmapCanvas.Clear();

                foreach (SKPath path in completedPaths)
                {
                    saveBitmapCanvas.DrawPath(path, paint);
                }

                foreach (SKPath path in inProgressPaths.Values)
                {
                    saveBitmapCanvas.DrawPath(path, paint);
                }
            }

            canvasView.InvalidateSurface();
        }

        }
}