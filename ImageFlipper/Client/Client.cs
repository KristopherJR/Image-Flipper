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
        // DECLARE an IList<String>, all it _imageIds:
        private IList<String> _imageIds;
        #endregion
        #region PROPERTIES
        /// <summary>
        /// Property for ImageGallery.
        /// </summary>
        public IImageGallery ImageGallery
        {
            get { return _imageGallery; }
        }
        /// <summary>
        /// Property for ImageEditor
        /// </summary>
        public IImageEditor ImageEditor
        {
            get { return _imageEditor; }
        }
        /// <summary>
        /// Propery for ImageIds
        /// </summary>
        public IList<String> ImageIds
        {
            get { return _imageIds; }
            set { _imageIds = value; }
        }
        #endregion
        public Client()
        {
            // INITIALISE the _imageIds list:
            _imageIds = new List<String>();
        }
        /// <summary>
        /// Run method called from the Controller when the program starts. Initialises the ImageGallery and returns the form for Application.
        /// </summary>
        /// <returns>The ImageGallery Form.</returns>
        public Form Run(SendPathToServerDelegate pSendPathToServer, RotateImageClockwiseDelegate pRCW, RotateImageCounterClockwiseDelegate pRCCW, FlipImageHorizontalDelegate pFIH, FlipImageVerticalDelegate pFIV, SaveImageDelegate pSaveImage, SaveImageCopyDelegate pSaveImageCopy)
        {
            // INITIALISE the _imageGallery:
            _imageGallery = new ImageGallery();
            _imageGallery.Subscribe(pSendPathToServer, PrimeEditor);
            // INITIALISE the _imageEditor:
            _imageEditor = new ImageEditor();
            _imageEditor.Subscribe(pRCW, pRCCW, pFIH, pFIV, pSaveImage, pSaveImageCopy);
            // RETURN the ImageGallery as a form to start the application:
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
            _imageIds.Add(pPictureBoxID);
        }
        /// <summary>
        /// Delegate method called from ImageGallery. Primes the Editor by passing the selecting image to the ImageEditor.
        /// </summary>
        /// <param name="pSelectedImage">The Image the user selected in the Gallery.</param>
        /// <param name="pSelectedImageUid">The uId of the image the user selected in the Gallery.</param>
        public void PrimeEditor(Image pSelectedImage, String pSelectedImageUid)
        {
            _imageEditor.EditImage = pSelectedImage;
            _imageEditor.EditImageUid = pSelectedImageUid;
            (_imageEditor as Form).Show();
        }
    }
}
