using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Author: Kristopher Randle
    /// Version: 0.1, 02-12-21
    /// </summary>
    public class ImageHandler : IImageHandler
    {
        public ImageHandler()
        {

        }

        public Image RotateClockwise(Image pImageToRotate)
        {
            pImageToRotate.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return pImageToRotate;
        }

        public Image RotateCounterClockwise(Image pImageToRotate)
        {
            pImageToRotate.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return pImageToRotate;
        }

        public Image FlipImageHorizontal(Image pImageToFlip)
        {
            pImageToFlip.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return pImageToFlip;
        }

        public Image FlipImageVertical(Image pImageToFlip)
        {
            pImageToFlip.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return pImageToFlip;
        }

        
    }
}
