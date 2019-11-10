using Android.Content;
using Android.Graphics;
using FreeWeatherApp.Controls;
using FreeWeatherApp.Droid.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientColorView), typeof(GradientColorViewRenderer))]
namespace FreeWeatherApp.Droid.Renderers
{
    public class GradientColorViewRenderer : BoxRenderer
    {
        private GradientColorView _element;

        public GradientColorViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            _element = (GradientColorView) e.NewElement;
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            if (_element != null)
            {
                LinearGradient gradient;

                switch (_element.GradientOrientation)
                {
                    case GradientColorView.Orientation.Horizontal:
                        gradient = new LinearGradient(
                            0,
                            0,
                            0,
                            Width,
                            _element.GradientStartColor.ToAndroid(),
                            _element.GradientEndColor.ToAndroid(),
                            Shader.TileMode.Clamp);
                        break;
                    case GradientColorView.Orientation.Vertical:
                        gradient = new LinearGradient(
                            0,
                            0,
                            0,
                            Height,
                            _element.GradientStartColor.ToAndroid(),
                            _element.GradientEndColor.ToAndroid(),
                            Shader.TileMode.Clamp);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(
                            $"{nameof(GradientColorView)}.{nameof(GradientColorView.GradientOrientation)} {_element.GradientOrientation} not emplemented.");
                }

                var paint = new Paint
                {
                    Dither = true
                };
                paint.SetShader(gradient);
                canvas.DrawPaint(paint);
            }

            base.DispatchDraw(canvas);
        }
    }
}