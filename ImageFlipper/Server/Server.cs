using Server.UserExceptions;
using System;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// Author: Kristopher Randle
/// IServer Author: Dr Marc Price
/// Version: 0.7, 05-12-21
/// </summary>
namespace Server
{
    /// <summary>
    /// Class Server. Acts as the business logic for the ImageFlipper program. It performs the manipulation tasks and provides storage for the assets.
    /// </summary>
    public class Server : IServer
    {
        #region FIELDS
        // DECLARE an IImageStorage, call it _imageStorage:
        private IImageStorage _imageStorage;
        // DECLARE an IImageHandler, call it _imageHandler:
        private IImageHandler _imageHandler;
        #endregion

        #region PROPERTIES
        // DECLARE a get-only property for ImageStorage:
        public IImageStorage ImageStorage
        {
            get { return _imageStorage; }
        }
        // DECLARE a get-only property for ImageHandler:
        public IImageHandler ImageHandler
        {
            get { return _imageHandler; }
        }
        #endregion
        /// <summary>
        /// Constructor for Server.
        /// </summary>
        public Server()
        {
            // INITALISE the storage and handler as their concrete class:
            _imageStorage = new ImageStorage();
            _imageHandler = new ImageHandler();
        }
        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the Server's data store.
		/// The strings in the collection act as unique identifiers for images in the Server's data store.
        /// </summary>
        /// <param name="pPathfilenames">a collection of one or more strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        public IList<string> Load(IList<string> pPathfilenames)
        {
            // ADD the image to the storage
            _imageStorage.Add(pPathfilenames);
            // RETRIEVE the image storage dictionary:
            Dictionary<String, Image> _images = _imageStorage.Images;
            // DECLARE a new list for the image identifer keys:
            IList<string> _imageIdentifiers = new List<string>();
            // ITERATE through the dictionary and grab the keys, add them to the list:
            foreach (KeyValuePair<String, Image> image in _images)
            {
                _imageIdentifiers.Add(image.Key);
            }
            // RETURN the IList of keys:
            return _imageIdentifiers;
        }
        /// <summary>
        /// Request a copy of the image specified by 'pUid', scaled according to the dimensions given by pFrameWidth and pFrameHeight.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image requested</param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixles) of the 'frame' it is to occupy</param>
        /// <returns>the Image identified by pUid</returns>
        public Image GetImage(string pUid, int pFrameWidth, int pFrameHeight)
        {
            // CHECK that the servers storage contains an image with the provided uId:
            if(_imageStorage.Images.ContainsKey(pUid))
            {
                //CHECK that the width and height provided are greater than 0:
                if(pFrameWidth > 0 && pFrameHeight > 0)
                {
                    // DECLARE an Image, call it retrievedImage. Retrieve the image from the Servers image storage with the uId:
                    Image retrievedImage = _imageStorage.RetrieveImage(pUid);
                    // DECLARE an Image, call it scaledImage. Set it to a scale version of retrievedImage based on the width and height provided:
                    Image scaledImage = (Image)(new Bitmap(retrievedImage, new Size(pFrameWidth, pFrameHeight)));
                    // RETURN the scaled image:
                    return scaledImage;
                }
                else
                {
                    // THROW a new InvalidParameterException if the width and height are not greater than 0:
                    throw new InvalidParameterException("SERVER: The width and height provided are not greater than 0.");
                }
                
            }
            else
            {
                // THROW an ElementNotFoundException if the server storage doesn't contain an image with the uId:
                throw new ElementNotFoundException("SERVER: An image with the specified uId (" + pUid + ") could not be found in the Servers image storage.");
            }
        }
        /// <summary>
        /// Rotate the image specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        /// <returns>void</returns>
        public void RotateImage(string pUid)
        {
            // IF the image with the specified uId is in the collection:
            if(_imageStorage.Images.ContainsKey(pUid))
            {
                // ROTATE the image clockwise via the image handler and save the change in the servers storage:
                _imageStorage.Images[pUid] = _imageHandler.RotateClockwise(_imageStorage.Images[pUid]);
            }
            else
            {
                // ELSE, throw an ElementNotFoundException with an error message:
                throw new ElementNotFoundException("SERVER: An image with the specified uId (" + pUid + ") could not be found in the Servers image storage.");
            }
        }
        /// <summary>
        /// Rotate the image counter clockwise specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        /// <returns>void</returns>
        public void RotateImageCounterClockwise(string pUid)
        {
            // IF the image with the specified uId is in the collection:
            if (_imageStorage.Images.ContainsKey(pUid))
            {
                // ROTATE the image counter clockwise via the image handler and save the change in the servers storage:
                _imageStorage.Images[pUid] = _imageHandler.RotateCounterClockwise(_imageStorage.Images[pUid]);
            }
            else
            {
                // ELSE, throw an ElementNotFoundException with an error message:
                throw new ElementNotFoundException("SERVER: An image with the specified uId (" + pUid + ") could not be found in the Servers image storage.");
            }
        }
        /// <summary>
        /// Flip the image specified by 'pUid' horizontally.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be flipped</param>
        /// <returns>void</returns>
        public void HorizontalFlipImage(string pUid)
        {
            // IF the image with the specified uId is in the collection:
            if (_imageStorage.Images.ContainsKey(pUid))
            {
                // FLIP the image horizontally via the image handler and save the change in the servers storage:
                _imageStorage.Images[pUid] = _imageHandler.FlipImageHorizontal(_imageStorage.Images[pUid]);
            }
            else
            {
                // ELSE, throw an ElementNotFoundException with an error message:
                throw new ElementNotFoundException("SERVER: An image with the specified uId (" + pUid + ") could not be found in the Servers image storage.");
            }
        }
        /// <summary>
        /// Flip the image specified by 'pUid' vertically.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be flipped</param>
        /// <returns>void</returns>
        public void VerticalFlipImage(string pUid)
        {
            // IF the image with the specified uId is in the collection:
            if (_imageStorage.Images.ContainsKey(pUid))
            {
                // FLIP the image vertically via the image handler and save the change in the servers storage:
                _imageStorage.Images[pUid] = _imageHandler.FlipImageVertical(_imageStorage.Images[pUid]);
            }
            else
            {
                // ELSE, throw an ElementNotFoundException with an error message:
                throw new ElementNotFoundException("SERVER: An image with the specified uId (" + pUid + ") could not be found in the Servers image storage.");
            }
        }
    }
}
