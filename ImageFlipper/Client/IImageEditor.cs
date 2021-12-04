using Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Author: Kristopher Randle
    /// Version: 0.1, 02-12-21
    /// </summary>
    public interface IImageEditor
    {
        /// <summary>
        /// Property for returning and setting the ImageEditors EditImage.
        /// </summary>
        Image EditImage { get; set; }
        /// <summary>
        /// Used to subscribe the ImageEditor to its delegates.
        /// </summary>
        /// <param name="pRCW">The RotateImageClockwiseDelegate.</param>
        /// <param name="pRCCW">The RotateImageCounterClockwiseDelegate</param>
        /// <param name="pFIH">The FlipImageHorizontalDelegate</param>
        /// <param name="pFIV">The FlipImageVerticalDelegate</param>
        /// <param name="pSaveImage">The SaveImage Delegate</param>
        /// <param name="pSaveImageCopy">The SaveImageCopy Delegate</param>
        void Subscribe(RotateImageClockwiseDelegate pRCW,
                       RotateImageCounterClockwiseDelegate pRCCW,
                       FlipImageHorizontalDelegate pFIH,
                       FlipImageVerticalDelegate pFIV,
                       SaveImageDelegate pSaveImage,
                       SaveImageCopyDelegate pSaveImageCopy);
        /// <summary>
        /// Property for the edit image unique ID.
        /// </summary>
        String EditImageUid { get; set; }
    }
}
