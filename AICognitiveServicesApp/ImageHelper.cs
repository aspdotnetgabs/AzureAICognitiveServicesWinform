using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

public static class ImageHelperExtension
{
    #region DefaultSettings
    private const int MAX_HEIGHT = 720; // default height in pixel
    private const bool QUALITY = true; // true = high quality, false = fast performance
    private const int THUMBNAIL_WIDTH = 200; // Assign 0 to disable
    private const int THUMBNAIL_HEIGHT = 150; // Assign 0 to disable
    #endregion
    
    #region Methods
    /// <summary>
    /// Resize a byte[] image. [BernardGabon.com]
    /// </summary>
    /// <param name="maxHeight">Height in Pixel</param>
    /// <param name="highQuality">True - High quality, False -  Fast performance</param>
    /// <returns>byte[] JpegImage</returns>
    public static byte[] Resize(this byte[] image, int maxHeight = MAX_HEIGHT, bool highQuality = QUALITY)
    {
        if (image != null)
        {
            MemoryStream stream = new MemoryStream(image);
            Image img = Image.FromStream(stream);

            foreach (var prop in img.PropertyItems)
            {
                //if ((prop.Id == 0x0112 || prop.Id == 5029 || prop.Id == 274))
                if (Array.IndexOf(img.PropertyIdList, 274) > -1)
                {
                    var orientation = (int)img.GetPropertyItem(274).Value[0];
                    img = OrientImage(img, orientation);
                }

                img = ScaleImage(img, maxHeight, highQuality);

                var ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                image = ms.ToArray();
            }

            return image;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// Resize and crop a byte[] image. [BernardGabon.com]
    /// </summary>
    /// <param name="Width">Width  in Pixel</param>
    /// <param name="Height">Height in Pixel</param>
    /// <param name="highQuality">True - High quality, False -  Fast performance</param>
    /// <returns>byte[] JpegImage</returns>
    public static byte[] ResizeToThumbnail(this byte[] image, int Width = THUMBNAIL_WIDTH, int Height = THUMBNAIL_HEIGHT, bool Fill = true)
    {
        if (image != null)
        {
            Image img;
            using (var ms = new MemoryStream(image))
            {
                img = Image.FromStream(ms);
            }
            var resizeImage = FixedSize(img, Width, Height, Fill);
            using (var ms = new MemoryStream())
            {
                resizeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        else
        {
            //Byte[] arrBlankImage = new Byte[64];
            //Array.Clear(arrBlankImage, 0, arrBlankImage.Length);
            //return arrBlankImage;
            return null;
        }
    }

    private static Image OrientImage(Image img, int orientation)
    {
        switch (orientation)
        {
            case 1:
                // No rotation required.
                break;
            case 2:
                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                break;
            case 3:
                img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                break;
            case 4:
                img.RotateFlip(RotateFlipType.Rotate180FlipX);
                break;
            case 5:
                img.RotateFlip(RotateFlipType.Rotate90FlipX);
                break;
            case 6:
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                break;
            case 7:
                img.RotateFlip(RotateFlipType.Rotate270FlipX);
                break;
            case 8:
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                break;
        }

        // This EXIF data is now invalid and should be removed.
        img.RemovePropertyItem(274);

        return img;
    }

    private static Image ScaleImage(Image image, int maxHeight = MAX_HEIGHT, bool highQuality = QUALITY)
    {
        var ratio = (double)maxHeight / image.Height;
        var newWidth = (int)(image.Width * ratio);
        var newHeight = (int)(image.Height * ratio);
        var newImage = new Bitmap(newWidth, newHeight);

        using (var g = Graphics.FromImage(newImage))
        {
            if (highQuality)
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            }
            g.DrawImage(image, 0, 0, newWidth, newHeight);
        }

        return newImage;
    }

    private static Image FixedSize(Image image, int Width, int Height, bool needToFill)
    {
        #region calculations
        int sourceWidth = image.Width;
        int sourceHeight = image.Height;
        int sourceX = 0;
        int sourceY = 0;
        double destX = 0;
        double destY = 0;

        double nScale = 0;
        double nScaleW = 0;
        double nScaleH = 0;

        nScaleW = ((double)Width / (double)sourceWidth);
        nScaleH = ((double)Height / (double)sourceHeight);
        if (!needToFill)
        {
            nScale = Math.Min(nScaleH, nScaleW);
        }
        else
        {
            nScale = Math.Max(nScaleH, nScaleW);
            destY = (Height - sourceHeight * nScale) / 2;
            destX = (Width - sourceWidth * nScale) / 2;
        }

        if (nScale > 1)
            nScale = 1;

        int destWidth = (int)Math.Round(sourceWidth * nScale);
        int destHeight = (int)Math.Round(sourceHeight * nScale);
        #endregion

        Bitmap bmPhoto = null;
        try
        {
            bmPhoto = new Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
        }
        catch (Exception ex)
        {
            throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                destWidth, destX, destHeight, destY, Width, Height), ex);
        }
        using (Graphics grPhoto = Graphics.FromImage(bmPhoto))
        {
            if (QUALITY == true)
            {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;
            }

            Rectangle to = new Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
            Rectangle from = new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
            grPhoto.DrawImage(image, to, from, GraphicsUnit.Pixel);

            return bmPhoto;
        }
    }

    #endregion

}
