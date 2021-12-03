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
    public class Client : IClient
    {
        #region FIELDS
        // DECLARE an IImageGallery, call it _imageGallery:
        private IImageGallery _imageGallery;
        // DECLARE an IImageEditor, call it _imageEditor:
        private IImageEditor _imageEditor;
        
        #endregion
        #region PROPERTIES
        public IImageGallery ImageGallery
        {
            get { return _imageGallery; }
        }
        #endregion
        public Client()
        {
            
        }
        /// <summary>
        /// Run method called from the Controller when the program starts. Initialises the ImageGallery and returns the form for Application.
        /// </summary>
        /// <returns>The ImageGallery Form.</returns>
        public Form Run(SendPathToServerDelegate pSendPathToServer)
        {
            // INITIALISE the _imageGallery:
            _imageGallery = new ImageGallery(pSendPathToServer);
            // RETURN it as a form to start the application:
            return _imageGallery as Form;
        }
        /// <summary>
        /// Adds an image to the GUI Image Gallery, this should be provided by the server.
        /// </summary>
        /// <param name="pPictureBoxID">The ID of the pictureBox for the image to be added to.</param>
        /// <param name="pImage">The image to be added to the GUI Image Gallery.</param>
        public void AddImage(string pPictureBoxID, Image pImage)
        {
            _imageGallery.AddImage(pPictureBoxID, pImage);
        }
    }
}
