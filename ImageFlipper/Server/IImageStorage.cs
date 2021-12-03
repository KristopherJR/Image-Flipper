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
        /// Adds images to the collection from the file paths.
        /// </summary>
        /// <param name="pImagePaths"></param>
        void Add(IList<String> pImagePaths);
        /// <summary>
        /// Remove an image from the collection.
        /// </summary>
        /// <param name="pUid">The Uid key of the image to be removed from the dictionary.</param>
        void Remove(String pUid);
        /// <summary>
        /// Retrieves an image from the ImageStorage.
        /// </summary>
        /// <param name="pUid">The unique identifier of the Image to be retrieved from the dictionary. This will usually be the filepath.</param>
        /// <returns></returns>
        Image RetrieveImage(String pUid);

    }
}
