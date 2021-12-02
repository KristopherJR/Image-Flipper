using System;
using System.Collections.Generic;
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
        #endregion
        #region PROPERTIES
        public IImageGallery ImageGallery
        {
            get { return _imageGallery; }
        }
        #endregion
        public Client()
        {
            
        }
        /// <summary>
        /// Run method called from the Controller when the program starts. Initialises the ImageGallery and returns the form for Application.
        /// </summary>
        /// <returns>The ImageGallery Form.</returns>
        public Form Run()
        {
            // INITIALISE the _imageGallery:
            _imageGallery = new ImageGallery();
            // RETURN it as a form to start the application:
            return _imageGallery as Form;
        }  
    }
}
