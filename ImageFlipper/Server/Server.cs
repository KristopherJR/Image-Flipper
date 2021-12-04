using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Server acts as the business logic for the ImageFlipper program. It performs the manipulation tasks and provides storage for the assets.
    /// 
    /// Author: Kristopher Randle
    /// IServer Author: Dr Marc Price
    /// Version 0.1, 02-12-21
    /// </summary>
    public class Server : IServer
    {
        #region FIELDS
        // DECLARE an IImageStorage, call it _imageStorage:
        IImageStorage _imageStorage;
        // DECLARE an IImageHandler, call it _imageHandler:
        IImageHandler _imageHandler;
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
            Image retrievedImage = _imageStorage.RetrieveImage(pUid);
            Image scaledImage = (Image)(new Bitmap(retrievedImage, new Size(pFrameWidth,pFrameHeight)));
            return scaledImage;
        }
        /// <summary>
        /// Rotate the image specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        /// <returns>void</returns>
        public void RotateImage(string pUid)
        {
            // ROTATE the image clockwise via the image handler and save the change in the servers storage:
            _imageStorage.Images[pUid] = _imageHandler.RotateClockwise(_imageStorage.Images[pUid]);
            Console.WriteLine("We're into server bois!");
        }
        /// <summary>
        /// Rotate the image counter clockwise specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        /// <returns>void</returns>
        public void RotateImageCounterClockwise(string pUid)
        {
            // ROTATE the image counter clockwise via the image handler and save the change in the servers storage:
            _imageStorage.Images[pUid] = _imageHandler.RotateCounterClockwise(_imageStorage.Images[pUid]);
        }
        /// <summary>
        /// Flip the image specified by 'pUid' horizontally.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be flipped</param>
        /// <returns>void</returns>
        public void HorizontalFlipImage(string pUid)
        {
            // FLIP the image horizontally via the image handler and save the change in the servers storage:
            _imageStorage.Images[pUid] = _imageHandler.FlipImageHorizontal(_imageStorage.Images[pUid]);
        }
        /// <summary>
        /// Flip the image specified by 'pUid' vertically.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be flipped</param>
        /// <returns>void</returns>
        public void VerticalFlipImage(string pUid)
        {
            // FLIP the image vertically via the image handler and save the change in the servers storage:
            _imageStorage.Images[pUid] = _imageHandler.FlipImageVertical(_imageStorage.Images[pUid]);
        }
    }
}
