using Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ImageFlipperTest
{
    /// <summary>
    /// Tests the functionality of ImageGallery.
    /// 
    /// Author: Kristopher Randle
    /// Version: 0.1, 03-12-21
    /// </summary>
    [TestClass]
    public class ImageGalleryTest
    {
        /// <summary>
        /// This method will check that the system is preventing the user from loaded the same image twice. 
        /// 
        /// Pass: The system prevents the user from loading a previously loaded image.
        /// </summary>
        [TestMethod]
        public void DuplicateImageLoadingTest()
        {
            // CREATE a new ImageGallery:
            ImageGallery imageGallery = new ImageGallery();
            // TRY to add the same image twice:
            // CATCH an exception if one is thrown:
        }
    }
}
