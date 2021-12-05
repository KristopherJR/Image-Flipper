using Main;
using System;
using System.Drawing;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.3, 05-12-21
/// </summary>
namespace Client
{
    /// <summary>
    /// Interface for IImageEditor.
    /// </summary>
    public interface IImageEditor
    {
        #region PROPERTIES
        /// <summary>
        /// Property for returning and setting the ImageEditors EditImage.
        /// </summary>
        Image EditImage { get; set; }
        /// <summary>
        /// Property for the edit image unique ID.
        /// </summary>
        String EditImageUid { get; set; }
        #endregion

        /// <summary>
        /// Used to subscribe the ImageEditor to its delegates.
        /// </summary>
        /// <param name="pRCW">The RotateImageClockwiseDelegate.</param>
        /// <param name="pRCCW">The RotateImageCounterClockwiseDelegate.</param>
        /// <param name="pFIH">The FlipImageHorizontalDelegate.</param>
        /// <param name="pFIV">The FlipImageVerticalDelegate.</param>
        /// <param name="pSaveImage">The SaveImageDelegate.</param>
        /// <param name="pSaveImageCopy">The SaveImageCopyDelegate.</param>
        void Subscribe(RotateImageClockwiseDelegate pRCW,
                       RotateImageCounterClockwiseDelegate pRCCW,
                       FlipImageHorizontalDelegate pFIH,
                       FlipImageVerticalDelegate pFIV,
                       SaveImageDelegate pSaveImage,
                       SaveImageCopyDelegate pSaveImageCopy);
    }
}
