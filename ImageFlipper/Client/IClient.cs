using Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    /// <summary>
    /// Author: Kristopher Randle
    /// Version: 0.1, 02-12-21
    /// </summary>
    public interface IClient
    {
        IImageGallery ImageGallery
        {
            get;
        }

        IImageEditor ImageEditor
        {
            get;
        }
        /// <summary>
        /// Run method called from the Controller when the program starts. Initialises the ImageGallery and returns the form for Application.
        /// </summary>
        /// <returns>The ImageGallery Form.</returns>
        Form Run(SendPathToServerDelegate pSendPathToServer, RotateImageClockwiseDelegate pRCW, RotateImageCounterClockwiseDelegate pRCCW, FlipImageHorizontalDelegate pFIH, FlipImageVerticalDelegate pFIV, SaveImageDelegate pSaveImage, SaveImageCopyDelegate pSaveImageCopy);
        /// <summary>
        /// Adds an image to the GUI Image Gallery, this should be provided by the server.
        /// </summary>
        /// <param name="pPictureBoxID">The ID of the pictureBox for the image to be added to.</param>
        /// <param name="pImage">The image to be added to the GUI Image Gallery.</param>
        void AddImage(string pPictureBoxID, Image pImage);
    }
}
