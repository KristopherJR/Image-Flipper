﻿using System;
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
    public partial class ImageGallery : Form
    {
        private Dictionary<string,Image> _images;
        private Dictionary<string, PictureBox> _pictureBoxes;
        private PictureBox _selectedPictureBox;
        private PictureBox _previouslySelectedPictureBox;
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
                        newPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                        newPicture.Size = new Size(150, 150);

                        // ADD newPicture to the flowLayoutPanel:
                        flowLayoutPanel1.Controls.Add(newPicture);

                        // display the image in the picture box:
                        newPicture.Image = new Bitmap(open.FileName);
                        // image file path  
                        textBox1.Text = Path.GetFileName(open.FileName);
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

        private void EditImageButton_Click(object sender, EventArgs e)
        {
            if(_selectedPictureBox == null)
            {
                Console.WriteLine("Click an image first that you wish to edit.");
            }
            else
            {
                ImageEditor newEditor = new ImageEditor(_selectedPictureBox.Image);
                newEditor.Show();
            }
        }
    }
}
