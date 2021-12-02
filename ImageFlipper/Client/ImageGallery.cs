using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    /// Version: 02/12/2021
    /// 
    /// OpenFileDialog code from: https://www.c-sharpcorner.com/UploadFile/mirfan00/uploaddisplay-image-in-picture-box-using-C-Sharp/
    /// </summary>
    public partial class ImageGallery : Form
    {
        private Dictionary<string,Image> _images;
        private Dictionary<string, PictureBox> _pictureBoxes;
        private PictureBox _selectedPictureBox;
        private PictureBox _previouslySelectPictureBox;
        public ImageGallery()
        {
            InitializeComponent();    
        }

        private void ImageGallery_Load(object sender, EventArgs e)
        {
            // INITIALISE the Dictionaries:
            _images = new Dictionary<string, Image>();
            _pictureBoxes = new Dictionary<string, PictureBox>();

        }
        /// <summary>
        /// Mouse click handler for each new image that is created. Allows an image to be selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newPicture_Click(object sender, MouseEventArgs e)
        {
            PictureBox clickedBox = sender as PictureBox;

            // if no box is selected
            if (_selectedPictureBox == null && _previouslySelectPictureBox == null)
            {
                // select the clicked box
                _selectedPictureBox = clickedBox;
                _previouslySelectPictureBox = clickedBox;
                _selectedPictureBox.BackColor = Color.FromArgb(142, 205, 117);
                return;
            }

            if (_selectedPictureBox == clickedBox)
            {
                _selectedPictureBox.BackColor = Color.Empty;
                _previouslySelectPictureBox.BackColor = Color.Empty;
                _selectedPictureBox = null;
                _previouslySelectPictureBox = null;
                return;
            }

            if (_selectedPictureBox != clickedBox)
            {
                _previouslySelectPictureBox = _selectedPictureBox;
                _selectedPictureBox = clickedBox;

                _previouslySelectPictureBox.BackColor = Color.Empty;
                _selectedPictureBox.BackColor = Color.FromArgb(142, 205, 117);
            }
        }
        /// <summary>
        /// Called each time the Load Image button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            // CHECK that the user hasn't already loaded 10 images:
            if(_images.Count < 10)
            {
                // CREATE a new OpenFileDialog so that the user can load an image from the File Explorer:
                OpenFileDialog open = new OpenFileDialog();

                // DEFINE images filters to restrict the user to only .PNG file formats:
                open.Filter = "Image Files(*.png;)|*.png;";
                // OPEN the File Explorer and wait for the user to select an image file:
                if (open.ShowDialog() == DialogResult.OK)
                {

                    // CHECK that the image selected has NOT already been loaded:
                    if (!_images.ContainsKey(open.FileName))
                    {
                        // ADD the image to the _images Dictionary. Use the FileName as the key:
                        _images.Add(open.FileName, Image.FromFile(open.FileName));
                        // CREATE a new PictureBox, call it newPicture:
                        PictureBox newPicture = new PictureBox();
                        // CREATE a mouse click handler for the newPicture:
                        
                        
                        newPicture.MouseClick += new MouseEventHandler(newPicture_Click);
                        // ADD newPicture to the _pictureBoxes dict. Use the same FileName as the key:
                        _pictureBoxes.Add(open.FileName, newPicture);
                        // SET its Size and SizeMode:
                        newPicture.SizeMode = PictureBoxSizeMode.CenterImage;
                        newPicture.Size = new Size(150, 150);

                        // ADD newPicture to the flowLayoutPanel:
                        flowLayoutPanel1.Controls.Add(newPicture);

                        // display the image in the picture box:
                        newPicture.Image = new Bitmap(open.FileName);
                        // image file path  
                        textBox1.Text = open.FileName;
                    }
                    else
                    {
                        // IF the user tries to load a previously loaded image, print an error message:
                        Console.WriteLine("Sorry! You've already loaded that image.");
                    }


                }

            }
            else
            {
                Console.WriteLine("Sorry fam, only 10 images allowed at a time.");
            }
            
        }
    }
}
