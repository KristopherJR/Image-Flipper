using System.Drawing;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.2, 04-12-21
/// </summary>
namespace Server
{
    /// <summary>
    /// Class ImageHandler. Processes the Images stored of the Server.
    /// </summary>
    public class ImageHandler : IImageHandler
    {
        /// <summary>
        /// Constructor for ImageHandler.
        /// </summary>
        public ImageHandler()
        {
            // Do nothing
        }
        /// <summary>
        /// Rotates the provided image 90 degrees clockwise.
        /// </summary>
        /// <param name="pImageToRotate">The image to rotate.</param>
        /// <returns>The rotated image.</returns>
        public Image RotateClockwise(Image pImageToRotate)
        {
            // ROTATE the image 90 degrees:
            pImageToRotate.RotateFlip(RotateFlipType.Rotate90FlipNone);
            // RETURN the rotated image:
            return pImageToRotate;
        }
        /// <summary>
        /// Rotates the provided image 90 degrees counter clockwise.
        /// </summary>
        /// <param name="pImageToRotate">The image to rotate.</param>
        /// <returns>The rotated image.</returns>
        public Image RotateCounterClockwise(Image pImageToRotate)
        {
            // ROTATE the image 270 degrees clockwise (same as 90 degrees counterclockwise):
            pImageToRotate.RotateFlip(RotateFlipType.Rotate270FlipNone);
            // RETURN the rotated image:
            return pImageToRotate;
        }
        /// <summary>
        /// Flips the provided image about its horizontal axis.
        /// </summary>
        /// <param name="pImageToFlip">The image to flip.</param>
        /// <returns>The flipped image.</returns>
        public Image FlipImageHorizontal(Image pImageToFlip)
        {
            // FLIP the image about its Y (Horizontal) Axis:
            pImageToFlip.RotateFlip(RotateFlipType.RotateNoneFlipY);
            // RETURN the flipped image:
            return pImageToFlip;
        }
        /// <summary>
        /// Flips the provided image about its vertical axis.
        /// </summary>
        /// <param name="pImageToFlip">The image to flip.</param>
        /// <returns>The flipped image.</returns>
        public Image FlipImageVertical(Image pImageToFlip)
        {
            // FLIP the image about its X (Vertical) Axis:
            pImageToFlip.RotateFlip(RotateFlipType.RotateNoneFlipX);
            // RETURN the flipped image:
            return pImageToFlip;
        }   
    }
}
