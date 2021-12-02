using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Author: Kristopher Randle
    /// Version: 0.1, 02-12-21
    /// </summary>
    public interface IImageStorage
    {
        /// <summary>
        /// Property for the images main storage. Returns the Dictionary of images.
        /// </summary>
        Dictionary<String,Image> Images
        {
            get;
        }
        /// <summary>
        /// Adds an image to the collection.
        /// </summary>
        /// <param name="pUid">The unique identifier for the image in the dictionary. This should be the filepath.</param>
        /// <param name="pImage">The image to be added to the images dictionary.</param>
        void Add(String pUid, Image pImage);
        /// <summary>
        /// Remove an image from the collection.
        /// </summary>
        /// <param name="pUid">The Uid key of the image to be removed from the dictionary.</param>
        void Remove(String pUid);
    }
}
