using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCurs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphPage : ContentPage
    {
        SKPaint blackFilePaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColor.Parse("#222228"),
            StrokeWidth = 20,
            StrokeCap = SKStrokeCap.Round,
            IsAntialias = true
            
        };
        SKPaint twoBlackFilePaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColor.Parse("#222228"),
            StrokeWidth = 230,
            StrokeCap = SKStrokeCap.Square,
            IsAntialias = true

        };

        SKPaint twowhiteFilePaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColor.Parse("#6666CC"),
            StrokeWidth = 15,

            StrokeCap = SKStrokeCap.Round,
            IsAntialias = true
        };
        SKPaint whiteFilePaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColor.Parse("#6666CC"),
            StrokeWidth = 15,

            StrokeCap = SKStrokeCap.Round,
            IsAntialias = true
        };
        SKPaint progFilePaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColor.Parse("#292938"),
            StrokeWidth = 15,

            StrokeCap = SKStrokeCap.Round,
            IsAntialias = true
        };
        public GraphPage()
        {
            InitializeComponent();
            PickerItemsList.Items.Add("WEEKLY BREAKDOWN");
            Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
            {
                canvasV.InvalidateSurface();
                return true;
            });
        }

        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear(SKColor.Parse("#17171A"));

            int width = e.Info.Width;
            int height = e.Info.Height;
            float valueMax = 100;
            double val = 67.60;
            LblPercentToday.Text = Convert.ToInt32(Math.Round(val)).ToString() + "%";
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 250f);
            int m = -10;
            canvas.DrawLine(-valueMax, 0, valueMax, 0, blackFilePaint);
            //canvas.DrawLine(-valueMax, 0, val - valueMax, 0, whiteFilePaint);
            for (int i = 0; i < 10; i++)
            {
                if (i < Convert.ToInt32(Math.Round(val / 10)))
                {
                    canvas.DrawLine(-valueMax + i*22, 0, 1 + (i*22) - valueMax, 0, whiteFilePaint);

                }
                else
                {
                    canvas.DrawLine(-valueMax + i * 22, 0, 1 + (i * 22) - valueMax, 0, progFilePaint);
                }
            }

        }

        private async void PickerItemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            await DisplayAlert("Test2", "Test1", "Ok");
        }

        private void canvasV_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear(SKColor.Parse("#17171A"));

            int width = e.Info.Width;
            int height = e.Info.Height;
            float valueMax = 100;
            double val = 67.60;
            LblPercentToday.Text = Convert.ToInt32(Math.Round(val)).ToString() + "%";
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 250f);
            canvas.DrawLine(-valueMax, 0, valueMax, 0, twoBlackFilePaint);
            Random random = new Random();
            for (int j = 0; j < 7; j++)
            {
                int ran = random.Next(0, 10);
                for (int i = 0; i < 10; i++)
                {

                    if (i < ran)
                    {
                        canvas.DrawLine(-valueMax + j * 33, valueMax - i * 22, 1 + (j * 33) - valueMax, 1 - (i * 22) + valueMax, twowhiteFilePaint);

                    }
                    else
                    {
                        canvas.DrawLine(-valueMax + j * 33, valueMax - i * 22, 1 + (j * 33) - valueMax, 1 - (i * 22) + valueMax, progFilePaint);
                    }
                }

            }
            canvas.Restore();
        }
        private async void Dance(SKPaintSurfaceEventArgs e)
        {
            while (true)
            {
                SKSurface surface = e.Surface;
                SKCanvas canvas = surface.Canvas;
                canvas.Clear(SKColor.Parse("#17171A"));

                int width = e.Info.Width;
                int height = e.Info.Height;
                float valueMax = 100;
                double val = 67.60;
                LblPercentToday.Text = Convert.ToInt32(Math.Round(val)).ToString() + "%";
                canvas.Translate(width / 2, height / 2);
                canvas.Scale(width / 250f);
                canvas.DrawLine(-valueMax, 0, valueMax, 0, twoBlackFilePaint);
                Random random = new Random();
                for (int j = 0; j < 7; j++)
                {
                    int ran = random.Next(0, 10);
                    for (int i = 0; i < 10; i++)
                    {

                        if (i < ran)
                        {
                            canvas.DrawLine(-valueMax + j * 30, valueMax - i * 22, 1 + (j * 30) - valueMax, 1 - (i * 22) + valueMax, twowhiteFilePaint);

                        }
                        else
                        {
                            canvas.DrawLine(-valueMax + j * 30, valueMax - i * 22, 1 + (j * 30) - valueMax, 1 - (i * 22) + valueMax, progFilePaint);
                        }
                    }

                }
                canvas.Restore();
                
                await Task.Delay(500);
            }
        }
    }
}