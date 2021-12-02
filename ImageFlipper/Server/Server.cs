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
            throw new NotImplementedException();
        }

        public Image GetImage(string pUid, int pFrameWidth, int pFrameHeight)
        {
            throw new NotImplementedException();
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
