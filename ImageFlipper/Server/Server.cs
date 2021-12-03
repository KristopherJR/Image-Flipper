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

        public Image GetImage(string pUid, int pFrameWidth, int pFrameHeight)
        {
            Image retrievedImage = _imageStorage.RetrieveImage(pUid);
            Image scaledImage = (Image)(new Bitmap(retrievedImage, new Size(pFrameWidth,pFrameHeight)));


            return scaledImage;
        }

        public void HorizontalFlipImage(string pUid)
        {
            throw new NotImplementedException();
        }

        public void RotateImage(string pUid)
        {
            throw new NotImplementedException();
        }

        public void VerticalFlipImage(string pUid)
        {
            throw new NotImplementedException();
        }
    }
}
