using PracaDyplomowa.Mobile.TouchTracking;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracaDyplomowa.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrawingGamePage : ContentPage
    {
        class Draw
        {
            public SKPaint Paint { get; set; }
            public SKPath SKPath { get; set; }
        }

        Dictionary<long, Draw> inProgressPaths = new Dictionary<long, Draw>();
        List<Draw> completedPaths = new List<Draw>();

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 10,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };

        public DrawingGamePage()
        {
            InitializeComponent();
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (!inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = new SKPath();
                        path.MoveTo(ConvertToPixel(args.Location));
                        inProgressPaths.Add(args.Id, new Draw { SKPath = path, Paint = paint.Clone() });
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Moved:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = inProgressPaths[args.Id].SKPath;
                        path.LineTo(ConvertToPixel(args.Location));
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Released:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        completedPaths.Add(inProgressPaths[args.Id]);
                        inProgressPaths.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Cancelled:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        inProgressPaths.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKCanvas canvas = args.Surface.Canvas;

            //args.Surface.Snapshot().ToShader().;
            canvas.Clear();

            foreach (var draw in completedPaths)
            {
                canvas.DrawPath(draw.SKPath, draw.Paint);
            }

            foreach (var draw in inProgressPaths.Values)
            {
                canvas.DrawPath(draw.SKPath, draw.Paint);
            }
        }

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                               (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            paint.Color = ((Button)sender).BackgroundColor.ToSKColor();
        }
    }
}