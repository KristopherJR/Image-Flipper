using Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.3, 05-12-2021
/// </summary>
namespace Client
{
    /// <summary>
    /// ImageGallery provides the GUI for the user to load in images for manipulation.
    /// 
    /// OpenFileDialog code from: https://www.c-sharpcorner.com/UploadFile/mirfan00/uploaddisplay-image-in-picture-box-using-C-Sharp/
    /// </summary>
    public partial class ImageGallery : Form, IImageGallery
    {
        #region FIELDS
        // DECLARE a Dictionary<string, PictureBox>, call it _pictureBoxes:
        private Dictionary<string, PictureBox> _pictureBoxes;
        // DECLARE a PictureBox, call it _selectedPictureBox:
        private PictureBox _selectedPictureBox;
        // DECLARE a PictureBox, call it _previouslySelectedPictureBox:
        private PictureBox _previouslySelectedPictureBox;
        // DECLARE a String, call it _selectedImageUid:
        private String _selectedImageUid;
        // DECLARE a SendPathToServerDelegate, call it _sendPathToServer:
        private SendPathToServerDelegate _sendPathToServer;
        // DECLARE a PrimeEditorDelegate, call it _primeEditor:
        private PrimeEditorDelegate _primeEditor;
        #endregion

        #region PROPERTIES
        // DECLARE a get property for SelectedPictureBox:
        public PictureBox SelectedPictureBox
        {
            get { return _selectedPictureBox; }
        }
        #endregion

        // Constructor for class ImageGallery.
        public ImageGallery()
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
        private void ImageGallery_Load(object sender, EventArgs e)
        {
            // INITIALISE the _pictureBoxes Dictionary:   
            _pictureBoxes = new Dictionary<string, PictureBox>();
        }
        /// <summary>
        /// Used to subscribe the ImageGallery to its delegates.
        /// </summary>
        /// <param name="pSendPathToServer">The SendPathToServerDelegate.</param>
        /// <param name="pPrimeEditor">The PrimeEditorDelegate.</param>
        public void Subscribe(SendPathToServerDelegate pSendPathToServer, PrimeEditorDelegate pPrimeEditor)
        {
            // SUBSCRIBE to the delegate parameters:
            _sendPathToServer = pSendPathToServer;
            _primeEditor = pPrimeEditor;
        }

        /// <summary>
        /// Mouse click handler for each new image that is created. Allows an image to be selected.
        /// </summary>
        /// <param name="sender">The picturebox that has been clicked on.</param>
        /// <param name="e">MouseEventArgs</param>
        private void newPicture_Click(object sender, MouseEventArgs e)
        {
            // STORe the sender as a PictureBox, call it clickedBox:
            PictureBox clickedBox = sender as PictureBox;

            // use case #1 - no boxes selected
            if (_selectedPictureBox == null && _previouslySelectedPictureBox == null)
            {
                // SET the selected box to the clicked box:
                _selectedPictureBox = clickedBox;
                // SET the previously selected box to the clicked box:
                _previouslySelectedPictureBox = clickedBox;
                // SET the colour of the selected box to green:
                _selectedPictureBox.BackColor = Color.FromArgb(142, 205, 117);
                // PRINT #1 for debugging:
                Console.WriteLine("#1");
                // BREAK the method execution by returning:
                return;
            }
            // use case #2 - user clicks a different box to the selected box
            if (_selectedPictureBox != clickedBox)
            {
                // SET the previously selected box to the currently selected box:
                _previouslySelectedPictureBox = _selectedPictureBox;
                // SET the selected box to the clicked box:
                _selectedPictureBox = clickedBox;
                // SET the colour of the previous box to empty:
                _previouslySelectedPictureBox.BackColor = Color.Empty;
                // SET the colour of the newly selected box to green:
                _selectedPictureBox.BackColor = Color.FromArgb(142, 205, 117);
                // PRINT #2 for debugging:
                Console.WriteLine("#2");
                // BREAK the method execution by returning:
                return;
            }
            // use case #3 - use clicks the same box as the selected box
            if (_selectedPictureBox == clickedBox)
            {
                // SET the color of the selected box to empty:
                _selectedPictureBox.BackColor = Color.Empty;
                // SET the selected box to null:
                _selectedPictureBox = null;
                // SET the previously selected box to null:
                _previouslySelectedPictureBox = null;
                // PRINT #3 for debugging:
                Console.WriteLine("#3");
            }  
        }

        /// <summary>
        /// Called each time the Load Image button is clicked.
        /// </summary>
        /// <param name="sender">The object calling the method.</param>
        /// <param name="e">the EventArgs.</param>
        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            // CREATE a new OpenFileDialog so that the user can load an image from the File Explorer:
            OpenFileDialog open = new OpenFileDialog();
            // DEFINE images filters to restrict the user to only .PNG file formats:
            open.Filter = "Image Files(*.png;)|*.png;";
            // OPEN the File Explorer and wait for the user to select an image file:
            if (open.ShowDialog() == DialogResult.OK)
            {
                // IF the image hasn't already been added to the gallery:
                if(!_pictureBoxes.ContainsKey(open.FileName))
                {
                    // CREATE a new PictureBox, call it newPicture:
                    PictureBox newPicture = new PictureBox();
                    // CREATE a mouse click handler for the newPicture:
                    newPicture.MouseClick += new MouseEventHandler(newPicture_Click);
                    // ADD newPicture to the _pictureBoxes dict. Use the same FileName as the key:
                    _pictureBoxes.Add(open.FileName, newPicture);
                    // SET its Size and SizeMode:
                    newPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    newPicture.Size = new Size(150, 150);

                    // ADD newPicture to the flowLayoutPanel:
                    flowLayoutPanel1.Controls.Add(newPicture);
                    IList<String> _imageFilePath = new List<String>();
                    _imageFilePath.Add(open.FileName);
                    // SEND the image path to the server by calling the delegate method in controller:
                    _sendPathToServer(_imageFilePath);
                    // Print the Image filepath in the textbox for debugging:
                    textBox1.Text = Path.GetFileName(open.FileName);
                }
                else
                {
                    // IF the user already added that image, give them an error message:
                    Console.WriteLine("Sorry, you've already added that image! blub!");
                } 
            }
        }

        /// <summary>
        /// Adds an image to the ImageGallery GUI, this should be provided by the server.
        /// </summary>
        /// <param name="pPictureBoxID">The ID of the pictureBox for the image to be added to.</param>
        /// <param name="pImage">The image to be added to the GUI Image Gallery.</param>
        public void AddImage(string pPictureBoxID, Image pImage)
        {
            // ITERATE through the _pictureBoxes Dictionary:
            foreach(KeyValuePair<string, PictureBox> pb in _pictureBoxes)
            {
                // IF the current key matches the ID provided as a parameter:
                if(pb.Key == pPictureBoxID)
                {
                    // ASSIGN the Image value of that picturebox to the image provided:
                    pb.Value.Image = pImage;
                }
            }
        }

        /// <summary>
        /// Triggered each time the user clicks the EditImageButton.
        /// </summary>
        /// <param name="sender">The object calling the method.</param>
        /// <param name="e">The EventArgs.</param>
        private void EditImageButton_Click(object sender, EventArgs e)
        {
            // IF the user hasn't selected an image:
            if(_selectedPictureBox == null)
            {
                // OUTPUT an error instructing the user to select an image first:
                Console.WriteLine("Click an image first that you wish to edit.");
            }
            else
            {
                // ITERATE through the _pictureBoxes Dictionary:
                foreach (KeyValuePair<String, PictureBox> p in _pictureBoxes)
                {
                    // CHECK if the pictureboxs Image matches the Image in the selected picturebox:
                    if(p.Value.Image == _selectedPictureBox.Image)
                    {
                        // IF it does, assign the uId of the _selectedImageUid to the key of the picturebox element:
                        _selectedImageUid = p.Key;
                    }
                }
                // SIGNAL for the client to prime the editor and pass in the appropriate parameters:
                _primeEditor(_selectedPictureBox.Image, _selectedImageUid);  
            }
        }
        /// <summary>
        /// Triggered when the user clicks ExitButton.
        /// </summary>
        /// <param name="sender">Object calling the method</param>
        /// <param name="e">The EventArgs.</param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            // CLOSE the application
            this.Close();
        }
    }
}
