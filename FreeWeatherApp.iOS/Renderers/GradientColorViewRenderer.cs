using CoreAnimation;
using CoreGraphics;
using FreeWeatherApp.Controls;
using FreeWeatherApp.iOS.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientColorView), typeof(GradientColorViewRenderer))]
namespace FreeWeatherApp.iOS.Renderers
{
    public class GradientColorViewRenderer : BoxRenderer
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            var element = (GradientColorView) Element;

            CAGradientLayer gradientLayer;

            switch (element.GradientOrientation)
            {
                case GradientColorView.Orientation.Horizontal:
                    gradientLayer = new CAGradientLayer
                    {
                        StartPoint = new CGPoint(0, 0.5),
                        EndPoint = new CGPoint(1, 0.5)
                    };
                    break;
                case GradientColorView.Orientation.Vertical:
                    gradientLayer = new CAGradientLayer();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(GradientColorView)}.{nameof(GradientColorView.GradientOrientation)} {element.GradientOrientation} not emplemented.");
            }

            gradientLayer.Frame = rect;
            gradientLayer.Colors = new[]
            {
                element.GradientStartColor.ToCGColor(),
                element.GradientEndColor.ToCGColor()
            };

            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}