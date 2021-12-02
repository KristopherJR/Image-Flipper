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
    public interface IClient
    {
        IImageGallery ImageGallery
        {
            get;
        }
        /// <summary>
        /// Run method called from the Controller when the program starts. Initialises the ImageGallery and returns the form for Application.
        /// </summary>
        /// <returns>The ImageGallery Form.</returns>
        Form Run();
    }
}
