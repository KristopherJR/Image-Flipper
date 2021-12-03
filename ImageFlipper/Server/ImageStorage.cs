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
        private Dictionary<String, Image> _images;
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
        /// Adds images to the collection from the file paths.
        /// </summary>
        /// <param name="pImagePaths">An IList containing strings of image file paths to be loaded into storage.</param>
        public void Add(IList<String> pImagePaths)
        {
            if(_images.Count < 10)
            {
                // ITERATE through the IList:
                foreach (String path in pImagePaths)
                {
                    // IF the list contains an image path that has already been loaded:
                    if (_images.ContainsKey(path))
                    {
                        Console.WriteLine(path);
                        // IF the user tries to load a previously loaded image, print an error message:
                        Console.WriteLine("Sorry! You've already loaded that image.");
                        // THROW an exception to prevent it and inform the user:
                        throw new Exception();

                    }
                    else
                    {
                        // ELSE the image has not been loaded, so add it to the load the image and assign the path as its unique key:
                        _images.Add(path, Image.FromFile(path));
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry fam, only 10 images allowed at a time.");
            }
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
        /// <summary>
        /// Retrieves an image from the ImageStorage.
        /// </summary>
        /// <param name="pUid">The unique identifier of the Image to be retrieved from the dictionary. This will usually be the filepath.</param>
        /// <returns>The image in the dictionary with the specified key.</returns>
        public Image RetrieveImage(String pUid)
        {
            // GRAB the image from the dictionary:
            Image retrievedImage = _images[pUid];
            // RETURN it:
            return retrievedImage;
        }
    }
}
