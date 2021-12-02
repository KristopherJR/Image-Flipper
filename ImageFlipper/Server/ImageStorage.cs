using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ImageStorage : IImageStorage
    {
        #region FIELDS
        // DECLARE a Dictionary<string, Image>, call it _images. Serves as the programs main image storage:
        private Dictionary<string, Image> _images;
        #endregion

        #region PROPERTIES
        // Returns the dictionary of all images currently loaded into storage.
        public Dictionary<string, Image> Images
        {
            get { return _images; }
        }
        #endregion
        /// <summary>
        /// Constructor for ImageStorage.
        /// </summary>
        public ImageStorage()
        {
            // INITIALISE the _images Dictionary:
            _images = new Dictionary<string, Image>();
        }
        /// <summary>
        /// Adds an image to the collection.
        /// </summary>
        /// <param name="pUid">The unique identifier for the image in the dictionary. This should be the filepath.</param>
        /// <param name="pImage">The image to be added to the images dictionary.</param>
        public void Add(String pUid, Image pImage)
        {
            // ADD the Images to the dictionary and assign it the pUid as its key:
            _images.Add(pUid, pImage);
        }
        /// <summary>
        /// Remove an image from the collection.
        /// </summary>
        /// <param name="pUid">The Uid key of the image to be removed from the dictionary.</param>
        public void Remove(string pUid)
        {
            // REMOVE the image from the dictionary with the parameter key:
            _images.Remove(pUid);
        }
    }
}
