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
        public IImageGallery ImageGallery
        {
            get { return _imageGallery; }
        }

        public IImageEditor ImageEditor
        {
            get { return _imageEditor; }
        }

        public IList<String> ImageIds
        {
            get { return _imageIds; }
            set { _imageIds = value; }
        }

        #endregion
        public Client()
        {
            _imageIds = new List<String>();
        }
        /// <summary>
        /// Run method called from the Controller when the program starts. Initialises the ImageGallery and returns the form for Application.
        /// </summary>
        /// <returns>The ImageGallery Form.</returns>
        public Form Run(SendPathToServerDelegate pSendPathToServer, RotateImageClockwiseDelegate pRCW, RotateImageCounterClockwiseDelegate pRCCW, FlipImageHorizontalDelegate pFIH, FlipImageVerticalDelegate pFIV, SaveImageDelegate pSaveImage, SaveImageCopyDelegate pSaveImageCopy)
        {
            // INITIALISE the _imageGallery:
            _imageGallery = new ImageGallery(pSendPathToServer, PrimeEditor);
            _imageEditor = new ImageEditor(pRCW, pRCCW, pFIH, pFIV, pSaveImage, pSaveImageCopy);
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
            _imageIds.Add(pPictureBoxID);
        }

        public void PrimeEditor(Image pSelectedImage, String pSelectedImageUid)
        {
            _imageEditor.EditImage = pSelectedImage;
            _imageEditor.EditImageUid = pSelectedImageUid;
            (_imageEditor as Form).Show();
        }
    }
}
