using Main;
using System;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.3, 05-12-2021
/// </summary>
namespace Client
{
    /// <summary>
    /// ImageEditor serves as the GUI windows form for the user to edit an image they have selected.
    /// </summary>
    public partial class ImageEditor : Form, IImageEditor
    {
        // DECLARE an Image, call it _editImage:
        private Image _editImage;
        // DECLARE a String, call it _editImageUid:
        private String _editImageUid;
        // DELCARE a RotateImageClockwiseDelegate, call it _RotateImageClockwise:
        private RotateImageClockwiseDelegate _RotateImageClockwise;
        // DELCARE a RotateImageCounterClockwiseDelegate, call it _RotateImageCounterClockwise:
        private RotateImageCounterClockwiseDelegate _RotateImageCounterClockwise;
        // DELCARE a FlipImageHorizontalDelegate, call it _FlipImageHorizontal:
        private FlipImageHorizontalDelegate _FlipImageHorizontal;
        // DELCARE a FlipImageVerticalDelegate, call it _FlipImageVertical:
        private FlipImageVerticalDelegate _FlipImageVertical;
        // DELCARE a SaveImageDelegate, call it _saveImage:
        private SaveImageDelegate _saveImage;
        // DELCARE a SaveImageCopyDelegate, call it _saveImageCopy:
        private SaveImageCopyDelegate _saveImageCopy;

        #region PROPERTIES
        // DECLARE a get-set property for EditImage. When set is called, use it to assign both the picturebox and the image.
        public Image EditImage
        {
            get { return _editImage; }
            set { _editImage = value;
                pictureBox1.Image = _editImage; }
        }
        // DECLARE a get-set property for EditImageUid.
        public String EditImageUid
        {
            get { return _editImageUid; }
            set
            {
                _editImageUid = value;
            }
        }
        #endregion
        /// <summary>
        /// Constructor for class ImageEditor.
        /// </summary>
        public ImageEditor()
        {
            // HIDE the control box so they user can't minimise, close or expand the windows form:
            ControlBox = false;
            // CALL InitializeComponent():
            InitializeComponent();
        }
        /// <summary>
        /// Called when the form is loaded.
        /// </summary>
        /// <param name="sender">Object calling the method.</param>
        /// <param name="e">The EventArgs.</param>
        private void ImageEditor_Load(object sender, EventArgs e)
        {
            // SET the sizeMode of the Editors picturebox to stretch:
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Used to subscribe the ImageEditor to its delegates.
        /// </summary>
        /// <param name="pRCW">The RotateImageClockwiseDelegate.</param>
        /// <param name="pRCCW">The RotateImageCounterClockwiseDelegate</param>
        /// <param name="pFIH">The FlipImageHorizontalDelegate</param>
        /// <param name="pFIV">The FlipImageVerticalDelegate</param>
        /// <param name="pSaveImage">The SaveImage Delegate</param>
        /// <param name="pSaveImageCopy">The SaveImageCopy Delegate</param>
        public void Subscribe(RotateImageClockwiseDelegate pRCW,
                               RotateImageCounterClockwiseDelegate pRCCW,
                               FlipImageHorizontalDelegate pFIH,
                               FlipImageVerticalDelegate pFIV,
                               SaveImageDelegate pSaveImage,
                               SaveImageCopyDelegate pSaveImageCopy)
        {
            // SUBSCRIBE to the delegate parameters:
            _RotateImageClockwise = pRCW;
            _RotateImageCounterClockwise = pRCCW;
            _FlipImageHorizontal = pFIH;
            _FlipImageVertical = pFIV;
            _saveImage = pSaveImage;
            _saveImageCopy = pSaveImageCopy;
        }

        /// <summary>
        /// Triggered when the user clicks RotateClockwiseButton.
        /// </summary>
        /// <param name="sender">Object calling the method.</param>
        /// <param name="e">The EventArgs.</param>
        private void RotateClockwiseButton_Click(object sender, EventArgs e)
        {
            // CALL the _RotateImageClockwise Delegate and pass in the uId of the image to be edited:
            _RotateImageClockwise(_editImageUid);
        }
        /// <summary>
        /// Triggered when the user clicks RotateCounterClockwiseButton.
        /// </summary>
        /// <param name="sender">Object calling the method.</param>
        /// <param name="e">The EventArgs.</param>
        private void RotateCounterClockwiseButton_Click(object sender, EventArgs e)
        {
            // CALL the _RotateImageCounterClockwise Delegate and pass in the uId of the image to be edited:
            _RotateImageCounterClockwise(_editImageUid);
        }
        /// <summary>
        /// Triggered when the user clicks FlipHorizontalButton.
        /// </summary>
        /// <param name="sender">Object calling the method.</param>
        /// <param name="e">The EventArgs.</param>
        private void FlipHorizontalButton_Click(object sender, EventArgs e)
        {
            // CALL the _FlipImageHorizontal Delegate and pass in the uId of the image to be edited:
            _FlipImageHorizontal(_editImageUid);
        }
        /// <summary>
        /// Triggered when the user clicks FlipVerticalButton.
        /// </summary>
        /// <param name="sender">Object calling the method.</param>
        /// <param name="e">The EventArgs.</param>
        private void FlipVerticalButton_Click(object sender, EventArgs e)
        {
            // CALL the _FlipImageVertical Delegate and pass in the uId of the image to be edited:
            _FlipImageVertical(_editImageUid);
        }
        /// <summary>
        /// Triggered when the user clicks SaveButton.
        /// </summary>
        /// <param name="sender">Object calling the method.</param>
        /// <param name="e">The EventArgs.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // CALL the _saveImage Delegate and pass in the uId of the image to be saved:
            _saveImage(_editImageUid);
        }
        /// <summary>
        /// Triggered when the user clicks SaveACopyButton.
        /// </summary>
        /// <param name="sender">Object calling the method.</param>
        /// <param name="e">The EventArgs.</param>
        private void SaveACopyButton_Click(object sender, EventArgs e)
        {
            // CALL the _saveImageCopy Delegate and pass in the uId of the image to be saved:
            _saveImageCopy(_editImageUid);
        }
        /// <summary>
        /// Triggered when the user clicks CloseEditorButton.
        /// </summary>
        /// <param name="sender">Object calling the method</param>
        /// <param name="e">The EventArgs.</param>
        private void CloseEditorButton_Click(object sender, EventArgs e)
        {
            // HIDE the editor:
            this.Hide();
        } 
    }
}
