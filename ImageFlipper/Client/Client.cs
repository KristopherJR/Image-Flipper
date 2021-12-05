using Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.4, 05-12-21
/// </summary>
namespace Client
{
    /// <summary>
    /// Client serves at the GUI for the user and communicates with the Server via the Controller.
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
        /// Declare a get property for ImageGallery.
        /// </summary>
        public IImageGallery ImageGallery
        {
            get { return _imageGallery; }
        }
        /// <summary>
        /// Declare a get property for ImageEditor
        /// </summary>
        public IImageEditor ImageEditor
        {
            get { return _imageEditor; }
        }
        /// <summary>
        /// Declare a get-set property for ImageIds
        /// </summary>
        public IList<String> ImageIds
        {
            get { return _imageIds; }
            set { _imageIds = value; }
        }
        #endregion
        /// <summary>
        /// Constructor for class Client.
        /// </summary>
        public Client()
        {
            // INITIALISE the _imageIds list:
            _imageIds = new List<String>();
        }

        /// <summary>
        /// Run() method called from the Controller when the program starts. Initialises the ImageGallery/ImageEditor and returns the form for Application.
        /// Subscribes the Gallery and Editor to their delegates which are called back to the Controller.
        /// </summary>
        /// <param name="pSendPathToServer">Subscribes ImageGallery to the SendPathToServerDelegate. Triggered whenever the user loads a new image path.</param>
        /// <param name="pRCW">Subscribes ImageEditor to the RotateImageClockwiseDelegate. Triggered when the user presses the RotateClockwiseButton.</param>
        /// <param name="pRCCW">Subscribes ImageEditor to the RotateImageCounterClockwiseDelegate. Triggered when the user presses the RotateCounterClockwiseButton.</param>
        /// <param name="pFIH">Subscribes ImageEditor to the FlipImageHorizontalDelegate. Triggered when the user presses the HorizontalFlipButton.</param>
        /// <param name="pFIV">Subscribes ImageEditor to the FlipImageVerticalDelegate. Triggered when the user presses the VerticalFlipButton.</param>
        /// <param name="pSaveImage">Subscribes ImageEditor to the SaveImageDelegate. Triggered when the user presses the SaveButton.</param>
        /// <param name="pSaveImageCopy">Subscribes ImageEditor to the SaveImageCopyDelegate. Triggered when the user presses the SaveACopyButton.</param>
        /// <returns>The ImageGallery Form.</returns>
        public Form Run(SendPathToServerDelegate pSendPathToServer, RotateImageClockwiseDelegate pRCW, RotateImageCounterClockwiseDelegate pRCCW, FlipImageHorizontalDelegate pFIH, FlipImageVerticalDelegate pFIV, SaveImageDelegate pSaveImage, SaveImageCopyDelegate pSaveImageCopy)
        {
            // INITIALISE the _imageGallery:
            _imageGallery = new ImageGallery();
            // CALL the _imageGallerys Subscribe method and pass in the relevant delegates:
            _imageGallery.Subscribe(pSendPathToServer, PrimeEditor);
            // INITIALISE the _imageEditor:
            _imageEditor = new ImageEditor();
            // CALL The _imageEditors Subscribe method and pass in the relevant delegates:
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
            // CALL the _imageGallerys AddImage() method and pass in the parameters:
            _imageGallery.AddImage(pPictureBoxID, pImage);
            // ADD the PictureBox uId to the _imageIds List:
            _imageIds.Add(pPictureBoxID);
        }
        /// <summary>
        /// Delegate method called from ImageGallery. Primes the Editor by passing the selected image to the ImageEditor.
        /// </summary>
        /// <param name="pSelectedImage">The Image the user selected in the Gallery.</param>
        /// <param name="pSelectedImageUid">The uId of the image the user selected in the Gallery.</param>
        public void PrimeEditor(Image pSelectedImage, String pSelectedImageUid)
        {
            // SET the _imageEditors Image to the SelectedImage parameter:
            _imageEditor.EditImage = pSelectedImage;
            // SET the _imageEditors Image uId to the SelectedImages uId Parameter:
            _imageEditor.EditImageUid = pSelectedImageUid;
            // SHOW the form so the user can edit images:
            (_imageEditor as Form).Show();
        }
    }
}
