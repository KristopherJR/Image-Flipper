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
    /// ImageEditor serves as the GUI windows form for the user to edit an image they have selected.
    /// 
    /// Author: Kristopher Randle
    /// Version: 0.1, 02-12-2021
    /// </summary>
    public partial class ImageEditor : Form
    {
        private Image _editImage;
        public ImageEditor(Image pEditImage)
        {
            InitializeComponent();
            _editImage = pEditImage;
        }
        private void ImageEditor_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = _editImage;
        }

        private void RotateClockwiseButton_Click(object sender, EventArgs e)
        {
            _editImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = _editImage;
        }

        private void RotateCounterClockwiseButton_Click(object sender, EventArgs e)
        {
            _editImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = _editImage;
        }

        private void FlipHorizontalButton_Click(object sender, EventArgs e)
        {
            _editImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = _editImage;
        }

        private void FlipVerticalButton_Click(object sender, EventArgs e)
        {
            _editImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = _editImage;
        }
    }
}
