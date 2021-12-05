using Server.UserExceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.6, 05-12-21
/// </summary>
namespace Server
{
    /// <summary>
    /// Class ImageStorage. Acts as the Server main storage unit.
    /// </summary>
    public class ImageStorage : IImageStorage
    {
        #region FIELDS
        // DECLARE a Dictionary<string, Image>, call it _images. Serves as the programs main image storage:
        private Dictionary<String, Image> _images;
        #endregion

        #region PROPERTIES
        // Declare a get-only property for _images. Returns the dictionary of all images currently loaded into storage.
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
            // CHECK the imagePaths are in an acceptable range
            if(pImagePaths.Count >= 1 &&  pImagePaths.Count <= 10)
            {
                // ITERATE through the IList:
                foreach (String path in pImagePaths)
                {
                    // CHECK that the path points to a .PNG image and that it contains back-slashes:
                    if(path.EndsWith(".png") && path.Contains(@"\"))
                    {
                        // IF the list contains an image path that has already been loaded:
                        if (_images.ContainsKey(path))
                        {
                            // THROW an exception to prevent it and inform the user:
                            throw new ImageAlreadyLoadedException("SERVER: Image (" + path + ") has already been loaded into the collection. You can not load it twice.");
                        }
                        else
                        {
                            try
                            {
                                // ELSE the image has not been loaded, so add it to the load the image and assign the path as its unique key:
                                _images.Add(path, Image.FromFile(path));
                                Console.WriteLine("SERVER: Image (" + path + ") succesfully loaded from path and added to storage.");
                            }
                            catch (FileNotFoundException e)
                            {
                                // PRINT the error message:
                                Console.WriteLine(e.Message);
                                // THROW the new exception for unit testing:
                                throw new FileNotFoundException("SERVER: Image (" + path + ") could not be loaded from path. The file does not exist.");
                            }
                        }
                    }
                    else
                    {
                        // THROW an InvalidParameterException if the provided path is not in a proper format:
                        throw new InvalidParameterException("SERVER: The path (" + path + ") is not in a valid format. Valid paths should reference a .PNG image and contain " + @"\.");
                    }
                }
            }
            // IF the provided paths aren't in an acceptable range:
            else
            {
                // IF there are more than 10 paths:
                if(pImagePaths.Count > 10)
                {
                    // THROW a new InvalidParameterException stating there can't be more than 10 paths:
                    throw new InvalidParameterException("SERVER: List contains too many paths (Strings). The maximum amount of paths is 10. Current path count: " + pImagePaths.Count + ".");
                }
                // IF there are less than 1 path:
                if(pImagePaths.Count < 1)
                {
                    // THROW a new InvalidParameterException stating there can't be less than 1 path:
                    throw new InvalidParameterException("SERVER: List contains too few paths (Strings). List must contain at least 1 path. Current path count: " + pImagePaths.Count + ".");
                }
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
            // IF the requested image has been loaded into storage:
            if(_images.ContainsKey(pUid))
            {
                // GRAB the image from the dictionary:
                Image retrievedImage = _images[pUid];
                // PRINT a confirmation that the image was retrieved to the console:
                Console.WriteLine("SERVER: Image (" + pUid + ") was retrieved from the collection and sent back to the caller.");
                // RETURN it:
                return retrievedImage;
            }
            else
            {
                // THROW an ElementNotFoundException if the requested image has not been loaded into storage:
                throw new ElementNotFoundException("SERVER: Image could not be retrieved as the uId (" + pUid + ") could not be found in the list.");
            }      
        }
    }
}
