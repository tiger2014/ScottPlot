﻿namespace ScottPlot.Primitives;

public class BackgroundStyle : IDisposable
{
    private SKBitmap? SKBitmap { get; set; } = null;
    public ImageScaleMode ImageScaling { get; set; } = ImageScaleMode.Stretch;
    public Color Color { get; set; } = Colors.White;

    public Image? _Image;
    public Image? Image
    {
        get => _Image; set
        {
            _Image = value;

            if (value is not null)
            {
                byte[] bytes = value.GetImageBytes();
                SKBitmap = SKBitmap.Decode(bytes); // TODO: SKImage instead?
            }
        }
    }

    public void Dispose()
    {
        SKBitmap?.Dispose();
    }

    public PixelRect GetImageRect(PixelRect targetRect)
    {
        return SKBitmap is null
            ? PixelRect.Zero
            : ImageScaling.GetImageRect(SKBitmap.Width, SKBitmap.Height, targetRect);
    }
}
