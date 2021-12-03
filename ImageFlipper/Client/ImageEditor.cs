using Main;
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
    public partial class ImageEditor : Form, IImageEditor
    {
        private Image _editImage;
        private String _editImageUid;
        private RotateImageClockwiseDelegate _RCW;
        private RotateImageCounterClockwiseDelegate _RCCW;
        private FlipImageHorizontalDelegate _FIH;
        private FlipImageVerticalDelegate _FIV;

        #region PROPERTIES
        public Image EditImage
        {
            get { return _editImage; }
            set { _editImage = value;
                pictureBox1.Image = _editImage; }
        }
        public String EditImageUid
        {
            get { return _editImageUid; }
            set
            {
                _editImageUid = value;
            }
        }
        #endregion
        public ImageEditor(RotateImageClockwiseDelegate pRCW, RotateImageCounterClockwiseDelegate pRCCW, FlipImageHorizontalDelegate pFIH, FlipImageVerticalDelegate pFIV)
        {
            // SUBSCRIBE to the delegates:
            _RCW = pRCW;
            _RCCW = pRCCW;
            _FIH = pFIH;
            _FIV = pFIV;
            InitializeComponent();
            
        }
        private void ImageEditor_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void RotateClockwiseButton_Click(object sender, EventArgs e)
        {
            _RCW(_editImageUid);
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
