using Main;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.4, 05-12-21
/// </summary>
namespace Client
{
    /// <summary>
    /// Interface for Client.
    /// </summary>
    public interface IClient
    {
        #region PROPERTIES
        // DECLARE a get-only property for ImageGallery that returns an IImageGallery.
        IImageGallery ImageGallery
        {
            get;
        }
        // DECLARE a get-only property for ImageEditor that returns an IImageEditor.
        IImageEditor ImageEditor
        {
            get;
        }
        #endregion
        /// <summary>
        /// Run method called from the Controller when the program starts. Initialises the ImageGallery and returns the form for Application. 
        /// Provides the Clients components with their delegates.
        /// </summary>
        /// <param name="pSendPathToServer">The SendPathToServerDelegate.</param>
        /// <param name="pRCW">The RotateImageClockwiseDelegate.</param>
        /// <param name="pRCCW">The RotateImageCounterClockwiseDelegate.</param>
        /// <param name="pFIH">The FlipImageHorizontalDelegate.</param>
        /// <param name="pFIV">The FlipImageVerticalDelegate.</param>
        /// <param name="pSaveImage">The SaveImageDelegate.</param>
        /// <param name="pSaveImageCopy">The SaveImageCopyDelegate.</param>
        /// <returns>The ImageGallery Form to be run.</returns>
        Form Run(SendPathToServerDelegate pSendPathToServer, RotateImageClockwiseDelegate pRCW, RotateImageCounterClockwiseDelegate pRCCW, FlipImageHorizontalDelegate pFIH, FlipImageVerticalDelegate pFIV, SaveImageDelegate pSaveImage, SaveImageCopyDelegate pSaveImageCopy);
        /// <summary>
        /// Adds an image to the GUI Image Gallery, this should be provided by the server.
        /// </summary>
        /// <param name="pPictureBoxID">The ID of the pictureBox for the image to be added to.</param>
        /// <param name="pImage">The image to be added to the GUI Image Gallery.</param>
        void AddImage(string pPictureBoxID, Image pImage);
    }
}
