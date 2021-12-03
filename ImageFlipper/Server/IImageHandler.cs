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
    /// Version: 0.1, 03-12-21
    /// </summary>
    public interface IImageHandler
    {
        /// <summary>
        /// Rotates the provided image 90 degrees clockwise.
        /// </summary>
        /// <param name="pImageToRotate">The image to rotate.</param>
        /// <returns>The rotated image.</returns>
        Image RotateClockwise(Image pImageToRotate);
        /// <summary>
        /// Rotates the provided image 90 degrees counter clockwise.
        /// </summary>
        /// <param name="pImageToRotate">The image to rotate.</param>
        /// <returns>The rotated image.</returns>
        Image RotateCounterClockwise(Image pImageToRotate);
        /// <summary>
        /// Flips the provided image about its horizontal axis.
        /// </summary>
        /// <param name="pImageToFlip">The image to flip.</param>
        /// <returns>The flipped image.</returns>
        Image FlipImageHorizontal(Image pImageToFlip);
        /// <summary>
        /// Flips the provided image about its vertical axis.
        /// </summary>
        /// <param name="pImageToFlip">The image to flip.</param>
        /// <returns>The flipped image.</returns>
        Image FlipImageVertical(Image pImageToFlip);
    }
}
