using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

/// <summary>
/// Author: Kristopher Randle & Marc Price
/// Version: 0.1, 04-12-21
/// </summary>
namespace ImageFlipperTest
{
    /// <summary>
    /// Tests for the ImageStorage class of the Server. Based on test classes by Marc Price.
    /// </summary>
    [TestClass]
    public class ImageStorageTest
    {
        /// <summary>
        /// Test ImageStorage Add() method in normal conditions:
        /// - ImagePaths list contains 3 paths (Strings). (valid range is 1 - 10 paths (Strings))
        /// - expected response is "SERVER: Images succesfully loaded from path and added to storage."
        /// </summary>
        [TestMethod]
        public void AddTestNormalAmountOfImages()
        {
        }
        /// <summary>
        /// Test ImageStorage Add() method when too many paths are provided:
        /// - ImagePaths list contains 15 paths (Strings). (valid range is 1 - 10 paths (Strings))
        /// - expected response is "SERVER: List contains too many paths (Strings). The maximum amount of paths is 10. Current path count: 15."
        /// </summary>
        [TestMethod]
        public void AddTestTooManyImages()
        {
        }
        /// <summary>
        /// Test ImageStorage Add() method when too few paths are provided:
        /// - ImagePaths list contains 0 paths (Strings). (valid range is 1 - 10 paths (Strings))
        /// - expected response is "SERVER: List contains too few paths (Strings). List must contain at least 1 path. Current path count: 0."
        /// </summary>
        [TestMethod]
        public void AddTestTooFewImages()
        {
        }
        /// <summary>
        /// Test ImageStorage Add() method when the path provided is valid:
        /// - ImagePath = "\Image-Flipper\ImageFlipper\Client\JavaFish.png".
        /// - expected response is "SERVER: Images succesfully loaded from path and added to storage."
        /// </summary>
        [TestMethod]
        public void AddTestValidParameter()
        {
        }
        /// <summary>
        /// Test ImageStorage Add() method when the path provided is not in a valid format:
        /// - ImagePath = "fakePath!".
        /// - expected response is "SERVER: The provided path: x is not a valid image path format."
        /// </summary>
        [TestMethod]
        public void AddTestInvalidParameter()
        {
        }
        /// <summary>
        /// Test ImageStorage Add() method when the path provided is in a valid format but the image can not be found on disk:
        /// - ImagePath = "\Image-Flipper\ImageFlipper\Client\NOT-AN-ACTUAL-IMAGE.png".
        /// - expected response is "SERVER: File could not be loaded from path. The file does not exist."
        /// </summary>
        [TestMethod]
        public void AddTestFileNotFoundException()
        {
        }
        /// <summary>
        /// Test ImageStorage Remove() method in normal conditions:
        /// - uId = "Test".
        /// - expected response is "SERVER: Image Succesfully Removed from Collection. uId: Test."
        /// </summary>
        [TestMethod]
        public void RemoveTestNormal()
        {
        }
        /// <summary>
        /// Test ImageStorage Remove() method when the uId is not in the list:
        /// - uId = "NOT_IN_LIST".
        /// - expected response is "SERVER: Image could not be removed from list as the uId could not be found. uId: NOT_IN_LIST."
        /// </summary>
        [TestMethod]
        public void RemoveTestElementNotFound()
        {
        }
        /// <summary>
        /// Test ImageStorage RetrieveImage() method in normal conditions:
        /// - uId = "Test".
        /// - expected response is "SERVER: Image retrieved from collection. uId: Test."
        /// </summary>
        [TestMethod]
        public void RetrieveImageTestNormal()
        {
        }
        /// <summary>
        /// Test ImageStorage RetrieveImage() method when the uId is not in the list:
        /// - uId = "NOT_IN_LIST".
        /// - expected response is "SERVER: Image could not be retrieved from list as the uId could not be found. uId: NOT_IN_LIST."
        /// </summary>
        [TestMethod]
        public void RetrieveImageTestElementNotFound()
        {
        }
    }
}
