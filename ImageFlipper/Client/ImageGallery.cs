using Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    /// <summary>
    /// ImageGallery allows a user to load in images for manipulation.
    /// 
    /// Author: Kristopher Randle
    /// Version: 02/12/2021, 0.2
    /// 
    /// OpenFileDialog code from: https://www.c-sharpcorner.com/UploadFile/mirfan00/uploaddisplay-image-in-picture-box-using-C-Sharp/
    /// </summary>
    public partial class ImageGallery : Form, IImageGallery
    {
        #region FIELDS
        private Dictionary<string, PictureBox> _pictureBoxes;
        private PictureBox _selectedPictureBox;
        private PictureBox _previouslySelectedPictureBox;
        // DECLARE a SendPathToServerDelegate, call it _sendPathToServer:
        private SendPathToServerDelegate _sendPathToServer;
        private PrimeEditorDelegate _primeEditor;
        #endregion

        #region PROPERTIES
        public PictureBox SelectedPictureBox
        {
            get { return _selectedPictureBox; }
        }
        #endregion
        public ImageGallery(SendPathToServerDelegate pSendPathToServer, PrimeEditorDelegate pPrimeEditor)
        {
            _sendPathToServer = pSendPathToServer;
            _primeEditor = pPrimeEditor;
            InitializeComponent();    
        }

        private void ImageGallery_Load(object sender, EventArgs e)
        {
            // INITIALISE the dictionary:   
            _pictureBoxes = new Dictionary<string, PictureBox>();

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            // CREATE a new OpenFileDialog so that the user can load an image from the File Explorer:
            OpenFileDialog open = new OpenFileDialog();

            // DEFINE images filters to restrict the user to only .PNG file formats:
            open.Filter = "Image Files(*.png;)|*.png;";
            // OPEN the File Explorer and wait for the user to select an image file:
            if (open.ShowDialog() == DialogResult.OK)
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
                // image file path
                textBox1.Text = Path.GetFileName(open.FileName);
            }
        }

        /// <summary>
        /// Adds an image to the GUI Image Gallery, this should be provided by the server.
        /// </summary>
        /// <param name="pPictureBoxID">The ID of the pictureBox for the image to be added to.</param>
        /// <param name="pImage">The image to be added to the GUI Image Gallery.</param>
        public void AddImage(string pPictureBoxID, Image pImage)
        {
            foreach(KeyValuePair<string, PictureBox> pb in _pictureBoxes)
            {
                if(pb.Key == pPictureBoxID)
                {
                    pb.Value.Image = pImage;
                }
            }
        }

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
                // SIGNAL for the client to prime the editor:
                _primeEditor();  
            }
        }
    }
}
