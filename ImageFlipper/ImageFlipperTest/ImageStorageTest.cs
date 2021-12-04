using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.UserExceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

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
        /// - PASS condition: Exception is not thrown with a valid amount of paths.
        /// - FAIL condition: Exception is thrown with a valid amount of paths.
        /// </summary>
        [TestMethod]
        public void AddTestNormalAmountOfPaths()
        {
            #region ARRANGE
            // INSTANTIATE ImageStorage:
            ImageStorage imageStorage = new ImageStorage();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with 3 valid paths:
            imagePaths.Add(@"FishAssets\JavaFish.png");
            imagePaths.Add(@"FishAssets\OrangeFish.png");
            imagePaths.Add(@"FishAssets\PiranhaGreen.png");
            #endregion ARRANGE

            #region ACT
            // CALL the Add() method and pass in the imagePaths in a try-catch:
            try
            {
                imageStorage.Add(imagePaths);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (InvalidParameterException e)
            {
                Console.WriteLine(e.Message);
                // FAIL the test if an exception is thrown with a valid number of paths:
                Assert.IsFalse(true, "An InvalidParameterException was thrown when a valid number of paths was provided.");
            }
            Assert.IsTrue(true);
            #endregion ASSERT
        }
        /// <summary>
        /// Test ImageStorage Add() method when too many paths are provided:
        /// - ImagePaths list contains 15 paths (Strings). (valid range is 1 - 10 paths (Strings))
        /// - expected response is an InvalidParameterException with the message:
        ///   "SERVER: List contains too many paths (Strings). The maximum amount of paths is 10. Current path count: 15."
        /// - PASS condition: Exception is thrown with an invalid amount of paths.
        /// - FAIL condition: The program does not throw an exception when there were too many paths in the List.
        /// </summary>
        [TestMethod]
        public void AddTestTooManyPaths()
        {
            #region ARRANGE
            // INSTANTIATE ImageStorage:
            ImageStorage imageStorage = new ImageStorage();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with 15 paths (it doesn't matter if they're valid or not for this test, as invalid strings are caught later):
            for(int i=0; i<15; i++)
            {
                imagePaths.Add(@"FishAssets\JavaFish.png");
            }
            #endregion ARRANGE

            #region ACT
            // CALL the Add() method and pass in the imagePaths in a try-catch:
            try
            {
                imageStorage.Add(imagePaths);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (InvalidParameterException e)
            {
                // PRINT the exception message:
                Console.WriteLine(e.Message);
                // PASS the test if an exception is thrown with an invalid number of paths:
                Assert.IsTrue(true);
                // RETURN so that the test doesn't reach the fail statement:
                return;
            }
            // FAIL the test if the program does not throw an exception when there were too many paths in the List:
            Assert.IsFalse(true, "The program did not detect that there were too many paths in the List.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test ImageStorage Add() method when too few paths are provided:
        /// - ImagePaths list contains 0 paths (Strings). (valid range is 1 - 10 paths (Strings))
        /// - expected response is an InvalidParameterException with the message:
        ///   "SERVER: List contains too few paths (Strings). List must contain at least 1 path. Current path count: 0."
        /// - PASS condition: Exception is thrown when there are too few paths.
        /// - FAIL condition: Exception is not thrown when there are too few paths.
        /// </summary>
        [TestMethod]
        public void AddTestTooFewPaths()
        {
            #region ARRANGE
            // INSTANTIATE ImageStorage:
            ImageStorage imageStorage = new ImageStorage();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            #endregion ARRANGE

            #region ACT
            // CALL the Add() method and pass in the imagePaths in a try-catch:
            try
            {
                imageStorage.Add(imagePaths);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (InvalidParameterException e)
            {
                // PRINT the exception message:
                Console.WriteLine(e.Message);
                // PASS the test if an exception is thrown with an invalid number of paths:
                Assert.IsTrue(true);
                // RETURN so that the test doesn't reach the fail statement:
                return;
            }
            // FAIL the test if the program does not throw an exception when there were too few paths in the List:
            Assert.IsFalse(true, "The program did not detect that there were too few paths in the List.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test ImageStorage Add() method when the path provided is valid:
        /// - ImagePath = "FishAssets\JavaFish.png".
        /// - expected response is an InvalidParameterException with the message:
        ///   "SERVER: Image (" + path + ") succesfully loaded from path and added to storage."
        /// - PASS condition: Exception is not thrown when the path is valid.
        /// - FAIL condition: Exception is thrown when the path is valid.
        /// </summary>
        [TestMethod]
        public void AddTestValidPathFormat()
        {
            #region ARRANGE
            // INSTANTIATE ImageStorage:
            ImageStorage imageStorage = new ImageStorage();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // ADD a valid path to the list:
            imagePaths.Add(@"FishAssets\JavaFish.png");
            #endregion ARRANGE

            #region ACT
            // CALL the Add() method and pass in the imagePaths in a try-catch:
            try
            {
                imageStorage.Add(imagePaths);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (InvalidParameterException e)
            {
                // PRINT the exception message:
                Console.WriteLine(e.Message);
                // FAIL test if an exception is thrown with a valid path:
                Assert.IsFalse(true);
                // RETURN so that the test doesn't reach the pass statement:
                return;
            }
            // PASS the test if the program does not throw an exception with a valid path:
            Assert.IsTrue(true, "The program did not throw an exception with a valid path.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test ImageStorage Add() method when the path provided is invalid:
        /// - ImagePath = "HAHAHASOFAKE.jpg".
        /// - expected response is an InvalidParameterException with the message:
        ///   "SERVER: The path (" + path + ") is not in a valid format. Valid paths should reference a .PNG image and contain " + @"\.""
        /// - PASS condition: Exception is thrown when the path is invalid.
        /// - FAIL condition: Exception is not thrown when the path is invalid.
        /// </summary>
        [TestMethod]
        public void AddTestInvalidPathFormat()
        {
            #region ARRANGE
            // INSTANTIATE ImageStorage:
            ImageStorage imageStorage = new ImageStorage();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // ADD an invalid path to the list:
            imagePaths.Add("HAHAHASOFAKE.jpg");
            #endregion ARRANGE

            #region ACT
            // CALL the Add() method and pass in the imagePaths in a try-catch:
            try
            {
                imageStorage.Add(imagePaths);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (InvalidParameterException e)
            {
                // PRINT the exception message:
                Console.WriteLine(e.Message);
                // PASS test if an exception is thrown with an invalid path:
                Assert.IsTrue(true);
                // RETURN so that the test doesn't reach the fail statement:
                return;
            }
            // FAIL the test if the program does not throw an exception with an invalid path:
            Assert.IsFalse(true, "The program did not throw an exception with an invalid path.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test ImageStorage Add() method when the user tries to load an image they have already loaded:
        /// - ImagePath = "FishAssets\JavaFish.png".
        /// - expected response is an ImageAlreadyLoadedException with the message:
        ///   "SERVER: Image (" + path + ") has already been loaded into the collection. You can not load it twice."
        /// - PASS condition: Exception is thrown when the user tries to load an image they have already loaded.
        /// - FAIL condition: Exception is not thrown when the user tries to load an image they have already loaded.
        /// </summary>
        [TestMethod]
        public void AddTestImageAlreadyLoaded()
        {
            #region ARRANGE
            // INSTANTIATE ImageStorage:
            ImageStorage imageStorage = new ImageStorage();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with 2 identical paths:
            imagePaths.Add(@"FishAssets\JavaFish.png");
            imagePaths.Add(@"FishAssets\JavaFish.png");
            #endregion ARRANGE

            #region ACT
            // CALL the Add() method and pass in the imagePaths in a try-catch:
            try
            {
                imageStorage.Add(imagePaths);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (ImageAlreadyLoadedException e)
            {
                // PRINT the exception message:
                Console.WriteLine(e.Message);
                // PASS test if an exception is thrown when the user tries to load the same image twice:
                Assert.IsTrue(true);
                // RETURN so that the test doesn't reach the fail statement:
                return;
            }
            // FAIL the test if the program does not throw an exception with a valid path:
            Assert.IsFalse(true, "The program did not throw an exception when the user tried to load the same image twice.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test ImageStorage Add() method when the path provided is in a valid format but the image can not be found on disk:
        /// - ImagePath = "FishAssets\NOT-AN-ACTUAL-IMAGE.png".
        /// - expected response is a FileNotFoundException with the message:
        ///   "SERVER: Image (" + path + ") could not be loaded from path. The file does not exist."
        /// - PASS condition: Exception is thrown when the user tries to load an image they have already loaded.
        /// - FAIL condition: Exception is not thrown when the user tries to load an image they have already loaded.
        /// </summary>
        [TestMethod]
        public void AddTestFileNotFound()
        {
            #region ARRANGE
            // INSTANTIATE ImageStorage:
            ImageStorage imageStorage = new ImageStorage();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path that doesn't resolve to a real file:
            imagePaths.Add(@"FishAssets\NOT-AN-ACTUAL-IMAGE.png");
            #endregion ARRANGE

            #region ACT
            // CALL the Add() method and pass in the imagePaths in a try-catch:
            try
            {
                imageStorage.Add(imagePaths);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (FileNotFoundException e)
            {
                // PRINT the exception message:
                Console.WriteLine(e.Message);
                // PASS test if an exception is thrown when the user tries to load an image that doesn't exist:
                Assert.IsTrue(true);
                // RETURN so that the test doesn't reach the fail statement:
                return;
            }
            // FAIL the test if the program does not throw an exception when the user tries to load an image that doesn't exist:
            Assert.IsFalse(true, "The program did not throw an exception when the user tried to load an image that doesn't exist.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test ImageStorage RetrieveImage() method in normal conditions:
        /// - uId = "TEST".
        /// - expected response "SERVER: Image (" + pUid + ") was retrieved from the collection and sent back to the caller."
        ///   "SERVER: Image retrieved from collection. uId: Test."
        /// - PASS condition: Exception is thrown when the user tries to load an image they have already loaded.
        /// - FAIL condition: Exception is not thrown when the user tries to load an image they have already loaded.
        /// </summary>
        [TestMethod]
        public void RetrieveImageTestNormal()
        {
            #region ARRANGE
            // INSTANTIATE ImageStorage:
            ImageStorage imageStorage = new ImageStorage();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with an image:
            imagePaths.Add(@"FishAssets\JavaFish.png");
            #endregion ARRANGE

            #region ACT
            // LOAD the image into storage:
            imageStorage.Add(imagePaths);
            // TRY to retrieve the image from the storage in a try-catch:
            try
            {
                Image Test = imageStorage.RetrieveImage(@"FishAssets\JavaFish.png");
            }
            #endregion ACT

            #region ASSERT
            catch(ElementNotFoundException e)
            {
                // PRINT the exception message:
                Console.WriteLine(e.Message);
                // FAIL test if an exception is thrown when the user tries to retrieve an image that is in the list:
                Assert.IsFalse(true);
                // RETURN so that the test doesn't reach the pass statement:
                return;
            }
            // PASS the test if the program does not throw an exception when the user tries to retrieve an image that is in the list:
            Assert.IsTrue(true, "The program did not throw an exception when the user tried to retrieve an image that is in the list.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test ImageStorage RetrieveImage() method when the uId is not in the list:
        /// - uId = "NOT_IN_LIST".
        /// - expected response is an ElementNotfoundException with the message:
        ///   "SERVER: Image could not be retrieved as the uId (" + uId + ") could not be found in the list."
        /// </summary>
        [TestMethod]
        public void RetrieveImageTestElementNotFound()
        {
            #region ARRANGE
            // INSTANTIATE ImageStorage:
            ImageStorage imageStorage = new ImageStorage();
            // DECLARE a string, call it uId and set it to "Test":
            string uId = "NOT_IN_LIST";
            #endregion ARRANGE

            #region ACT
            // CALL the RetrieveImage() method and pass in the uId in a try-catch, assign it to a dummy-image:
            try
            {
                Image test = imageStorage.RetrieveImage(uId);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (ElementNotFoundException e)
            {
                // PRINT the exception message:
                Console.WriteLine(e.Message);
                // PASS test if an exception is thrown when the user tries to retrieve an image that is not in the list:
                Assert.IsTrue(true);
                // RETURN so that the test doesn't reach the fail statement:
                return;
            }
            // FAIL the test if the program does not throw an exception when the user tries to retrieve an image that is not in the list:
            Assert.IsFalse(true, "The program did not throw an exception when the user tried to retrieve an image that is not in the list.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test ImageStorage Remove() method in normal conditions:
        /// - uId = "Test".
        /// - expected response is "SERVER: Image Succesfully Removed from Collection. uId: Test."
        /// </summary>
        [TestMethod]
        public void RemoveTestNormal()
        {
            #region ARRANGE
            #endregion ARRANGE

            #region ACT
            #endregion ACT

            #region ASSERT
            #endregion ASSERT
        }
        /// <summary>
        /// Test ImageStorage Remove() method when the uId is not in the list:
        /// - uId = "NOT_IN_LIST".
        /// - expected response is "SERVER: Image could not be removed from list as the uId could not be found. uId: NOT_IN_LIST."
        /// </summary>
        [TestMethod]
        public void RemoveTestElementNotFound()
        {
            #region ARRANGE
            #endregion ARRANGE

            #region ACT
            #endregion ACT

            #region ASSERT
            #endregion ASSERT
        }

    }
}
