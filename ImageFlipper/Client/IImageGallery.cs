using Main;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.3, 05-12-21
/// </summary>
namespace Client
{
    /// <summary>
    /// Interface for IImageGallery.
    /// </summary>
    public interface IImageGallery
    {
        #region PROPERTIES
        /// <summary>
        /// Property for the picture box the user currently has selected.
        /// </summary>
        PictureBox SelectedPictureBox { get; }
        #endregion

        /// <summary>
        /// Used to subscribe the ImageGallery to delegates.
        /// </summary>
        /// <param name="pSendPathToServer">The SendPathToServerDelegate</param>
        /// <param name="pPrimeEditor">The PrimeEditor Delegate</param>
        void Subscribe(SendPathToServerDelegate pSendPathToServer, PrimeEditorDelegate pPrimeEditor);

        /// <summary>
        /// Adds an image to the GUI Image Gallery, this should be provided by the server.
        /// </summary>
        /// <param name="pPictureBoxID">The ID of the pictureBox for the image to be added to.</param>
        /// <param name="pImage">The image to be added to the GUI Image Gallery.</param>
        void AddImage(string pPictureBoxID, Image pImage);
    }
}
