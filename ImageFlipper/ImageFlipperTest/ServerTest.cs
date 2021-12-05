using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Server;
using System.Collections.Generic;
using Server.UserExceptions;

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
    public class ServerTest
    {
        /// <summary>
        /// Test Server GetImage() method in normal conditions:
        /// - expected response is the test passing with valid width and height (greater than 0).
        /// - PASS condition: Exception is not thrown when valid parameters are provided.
        /// - FAIL condition: Exception is thrown with valid parameters.
        /// </summary>
        [TestMethod]
        public void GetImageWidthAndHeightTestNormal()
        {
            #region ARRANGE
            // INSTANTIATE IServer:
            IServer server = new Server.Server();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path:
            imagePaths.Add(@"FishAssets\JavaFish.png");
            // ADD the path to the servers storage:
            (server as Server.Server).ImageStorage.Add(imagePaths);
            #endregion ARRANGE

            #region ACT
            // CALL the GetImage() method and pass in normal parameters in a try-catch:
            try
            {
                server.GetImage(imagePaths[0], 150, 150);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (InvalidParameterException e)
            {
                // PRINT the error message:
                Console.WriteLine(e.Message);
                // FAIL the test if an exception is thrown with valid parameters:
                Assert.IsFalse(true, "An InvalidParameterException was thrown when all parameters were valid.");
                // RETURN to prevent the program reaching the pass condition:
                return;
            }
            // PASS the test if an exception is not thrown with valid parameters:
            Assert.IsTrue(true, "System did not throw an exception when width and height parameters were valid.");
            #endregion ASSERT
        }

        /// <summary>
        /// Test Server GetImage() method in normal conditions:
        /// - expected response is an exception being thrown with the message:
        ///   "SERVER: The width and height provided are not greater than 0."
        /// - PASS condition: Exception is not thrown when valid parameters are provided.
        /// - FAIL condition: Exception is thrown with valid parameters.
        /// </summary>
        [TestMethod]
        public void GetImageWidthAndHeightTestInvalid()
        {
            #region ARRANGE
            // INSTANTIATE IServer:
            IServer server = new Server.Server();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path:
            imagePaths.Add(@"FishAssets\JavaFish.png");
            // ADD the path to the servers storage:
            (server as Server.Server).ImageStorage.Add(imagePaths);
            #endregion ARRANGE

            #region ACT
            // CALL the GetImage() method and pass in an invalid width and height in a try-catch:
            try
            {
                server.GetImage(imagePaths[0], -2, -1000);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (InvalidParameterException e)
            {
                // PRINT the error message:
                Console.WriteLine(e.Message);
                // PASS the test if an exception is thrown with invalid parameters:
                Assert.IsTrue(true, "An InvalidParameterException was thrown when the width and height were less than 0.");
                // RETURN to prevent the program reaching the fail condition:
                return;
            }
            // FAIL the test if an exception is not thrown with invalid parameters:
            Assert.IsFalse(true, "System failed to detect invalid width and height image parameters.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test Server RotateImage() method in normal conditions:
        /// - expected response is the test passing without throwing an exception if the Uid is valid.
        /// - PASS condition: ElementNotFoundException is not thrown when a valid uId is provided.
        /// - FAIL condition: ElementNotFoundException is thrown with a valid uId.
        /// </summary>
        [TestMethod]
        public void RotateImageUidExistsTest()
        {
            #region ARRANGE
            // INSTANTIATE IServer:
            IServer server = new Server.Server();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path:
            imagePaths.Add(@"FishAssets\JavaFish.png");
            // ADD the path to the servers storage:
            (server as Server.Server).ImageStorage.Add(imagePaths);
            #endregion ARRANGE

            #region ACT
            // CALL the RotateImage() method and pass in a valid uId in a try-catch:
            try
            {
                server.RotateImage(imagePaths[0]);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (ElementNotFoundException e)
            {
                // PRINT the error message:
                Console.WriteLine(e.Message);
                // FAIL the test if an exception is thrown with a valid uId:
                Assert.IsFalse(true, "An ElementNotFoundException was thrown when the uId was valid.");
                // RETURN to prevent the program reaching the pass condition:
                return;
            }
            // PASS the test if an exception is not thrown with a valid uId:
            Assert.IsTrue(true, "An ElementNotFoundException was not thrown when the uId was valid.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test Server RotateImage() method when the uId does not exist:
        /// - expected response is the test passing by throwing an exception if the Uid is invalid.
        /// - PASS condition: ElementNotFoundException is thrown when an invalid uId is provided.
        /// - FAIL condition: ElementNotFoundException is not thrown with an invalid uId.
        /// </summary>
        [TestMethod]
        public void RotateImageUidDoesntExistTest()
        {
            #region ARRANGE
            // INSTANTIATE IServer:
            IServer server = new Server.Server();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path (but do not add it to the storage):
            imagePaths.Add(@"FishAssets\JavaFish.png");
            #endregion ARRANGE

            #region ACT
            // CALL the RotateImage() method and pass in an invalid uId (not in the collection) in a try-catch:
            try
            {
                server.RotateImage(imagePaths[0]);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (ElementNotFoundException e)
            {
                // PRINT the error message:
                Console.WriteLine(e.Message);
                // PASS the test if an exception is thrown with an invalid uId:
                Assert.IsTrue(true, "An ElementNotFoundException was thrown when the uId was invalid.");
                // RETURN to prevent the program reaching the fail condition:
                return;
            }
            // FAIL the test if an exception is not thrown with a valid uId:
            Assert.IsTrue(true, "An ElementNotFoundException was not thrown when the uId was invalid.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test Server RotateImageCounterClockwise() method in normal conditions:
        /// - expected response is the test passing without throwing an exception if the Uid is valid.
        /// - PASS condition: ElementNotFoundException is not thrown when a valid uId is provided.
        /// - FAIL condition: ElementNotFoundException is thrown with a valid uId.
        /// </summary>
        [TestMethod]
        public void RotateImageCounterClockwiseUidExistsTest()
        {
            #region ARRANGE
            // INSTANTIATE IServer:
            IServer server = new Server.Server();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path:
            imagePaths.Add(@"FishAssets\JavaFish.png");
            // ADD the path to the servers storage:
            (server as Server.Server).ImageStorage.Add(imagePaths);
            #endregion ARRANGE

            #region ACT
            // CALL the RotateImageCounterClockwise() method and pass in a valid uId in a try-catch:
            try
            {
                (server as Server.Server).RotateImageCounterClockwise(imagePaths[0]);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (ElementNotFoundException e)
            {
                Console.WriteLine(e.Message);
                // FAIL the test if an exception is thrown with a valid uId:
                Assert.IsFalse(true, "An ElementNotFoundException was thrown when the uId was valid.");
                // RETURN to prevent the program reaching the pass condition:
                return;
            }
            // PASS the test if an exception is not thrown with a valid uId:
            Assert.IsTrue(true, "An ElementNotFoundException was not thrown when the uId was valid.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test Server RotateImageCounterClockwise() method when the uId does not exist:
        /// - expected response is the test passing by throwing an exception if the Uid is invalid.
        /// - PASS condition: ElementNotFoundException is thrown when an invalid uId is provided.
        /// - FAIL condition: ElementNotFoundException is not thrown with an invalid uId.
        /// </summary>
        [TestMethod]
        public void RotateImageCounterClockwiseUidDoesntExistTest()
        {
            #region ARRANGE
            // INSTANTIATE IServer:
            IServer server = new Server.Server();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path (but do not add it to the storage):
            imagePaths.Add(@"FishAssets\JavaFish.png");
            #endregion ARRANGE

            #region ACT
            // CALL the RotateImageCounterClockwise() method and pass in an invalid uId (not in the collection) in a try-catch:
            try
            {
                (server as Server.Server).RotateImageCounterClockwise(imagePaths[0]);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (ElementNotFoundException e)
            {
                // PRINT the error message:
                Console.WriteLine(e.Message);
                // PASS the test if an exception is thrown with an invalid uId:
                Assert.IsTrue(true, "An ElementNotFoundException was thrown when the uId was invalid.");
                // RETURN to prevent the program reaching the fail condition:
                return;
            }
            // FAIL the test if an exception is not thrown with a valid uId:
            Assert.IsTrue(true, "An ElementNotFoundException was not thrown when the uId was invalid.");
            #endregion ASSERT
        }
    
        /// <summary>
        /// Test Server HorizontalFlipImage() method in normal conditions:
        /// - expected response is the test passing without throwing an exception if the Uid is valid.
        /// - PASS condition: ElementNotFoundException is not thrown when a valid uId is provided.
        /// - FAIL condition: ElementNotFoundException is thrown with a valid uId.
        /// </summary>
        [TestMethod]
        public void HorizontalFlipImageUidExistsTest()
        {
            #region ARRANGE
            // INSTANTIATE IServer:
            IServer server = new Server.Server();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path:
            imagePaths.Add(@"FishAssets\JavaFish.png");
            // ADD the path to the servers storage:
            (server as Server.Server).ImageStorage.Add(imagePaths);
            #endregion ARRANGE

            #region ACT
            // CALL the HorizontalFlipImage() method and pass in a valid uId in a try-catch:
            try
            {
                server.HorizontalFlipImage(imagePaths[0]);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (ElementNotFoundException e)
            {
                Console.WriteLine(e.Message);
                // FAIL the test if an exception is thrown with a valid uId:
                Assert.IsFalse(true, "An ElementNotFoundException was thrown when the uId was valid.");
                // RETURN to prevent the program reaching the pass condition:
                return;
            }
            // PASS the test if an exception is not thrown with a valid uId:
            Assert.IsTrue(true, "An ElementNotFoundException was not thrown when the uId was valid.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test Server HorizontalFlipImage() method when the uId does not exist:
        /// - expected response is the test passing by throwing an exception if the Uid is invalid.
        /// - PASS condition: ElementNotFoundException is thrown when an invalid uId is provided.
        /// - FAIL condition: ElementNotFoundException is not thrown with an invalid uId.
        [TestMethod]
        public void HorizontalFlipImageUidDoesntExistTest()
        {
            #region ARRANGE
            // INSTANTIATE IServer:
            IServer server = new Server.Server();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path (but do not add it to the storage):
            imagePaths.Add(@"FishAssets\JavaFish.png");
            #endregion ARRANGE

            #region ACT
            // CALL the HorizontalFlipImage() method and pass in an invalid uId (not in the collection) in a try-catch:
            try
            {
                server.HorizontalFlipImage(imagePaths[0]);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (ElementNotFoundException e)
            {
                // PRINT the error message:
                Console.WriteLine(e.Message);
                // PASS the test if an exception is thrown with an invalid uId:
                Assert.IsTrue(true, "An ElementNotFoundException was thrown when the uId was invalid.");
                // RETURN to prevent the program reaching the fail condition:
                return;
            }
            // FAIL the test if an exception is not thrown with a valid uId:
            Assert.IsTrue(true, "An ElementNotFoundException was not thrown when the uId was invalid.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test Server VerticalFlipImage() method in normal conditions:
        /// - expected response is the test passing without throwing an exception if the Uid is valid.
        /// - PASS condition: ElementNotFoundException is not thrown when a valid uId is provided.
        /// - FAIL condition: ElementNotFoundException is thrown with a valid uId.
        /// </summary>
        [TestMethod]
        public void VerticalFlipImageUidExistsTest()
        {
            #region ARRANGE
            // INSTANTIATE IServer:
            IServer server = new Server.Server();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path:
            imagePaths.Add(@"FishAssets\JavaFish.png");
            // ADD the path to the servers storage:
            (server as Server.Server).ImageStorage.Add(imagePaths);
            #endregion ARRANGE

            #region ACT
            // CALL the VerticalFlipImage() method and pass in a valid uId in a try-catch:
            try
            {
                server.VerticalFlipImage(imagePaths[0]);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (ElementNotFoundException e)
            {
                Console.WriteLine(e.Message);
                // FAIL the test if an exception is thrown with a valid uId:
                Assert.IsFalse(true, "An ElementNotFoundException was thrown when the uId was valid.");
                // RETURN to prevent the program reaching the pass condition:
                return;
            }
            // PASS the test if an exception is not thrown with a valid uId:
            Assert.IsTrue(true, "An ElementNotFoundException was not thrown when the uId was valid.");
            #endregion ASSERT
        }
        /// <summary>
        /// Test Server VerticalFlipImage() method when the uId does not exist:
        /// - expected response is the test passing by throwing an exception if the Uid is invalid.
        /// - PASS condition: ElementNotFoundException is thrown when an invalid uId is provided.
        /// - FAIL condition: ElementNotFoundException is not thrown with an invalid uId.
        [TestMethod]
        public void VerticalFlipImageUidDoesntExistTest()
        {
            #region ARRANGE
            // INSTANTIATE IServer:
            IServer server = new Server.Server();
            // INSTANTIATE an IList, call it imagePaths:
            IList<String> imagePaths = new List<String>();
            // POPULATE imagePaths with a valid path (but do not add it to the storage):
            imagePaths.Add(@"FishAssets\JavaFish.png");
            #endregion ARRANGE

            #region ACT
            // CALL the VerticalFlipImage() method and pass in an invalid uId (not in the collection) in a try-catch:
            try
            {
                server.VerticalFlipImage (imagePaths[0]);
            }
            #endregion ACT

            #region ASSERT
            // CATCH the exception and print the error message:
            catch (ElementNotFoundException e)
            {
                // PRINT the error message:
                Console.WriteLine(e.Message);
                // PASS the test if an exception is thrown with an invalid uId:
                Assert.IsTrue(true, "An ElementNotFoundException was thrown when the uId was invalid.");
                // RETURN to prevent the program reaching the fail condition:
                return;
            }
            // FAIL the test if an exception is not thrown with a valid uId:
            Assert.IsTrue(true, "An ElementNotFoundException was not thrown when the uId was invalid.");
            #endregion ASSERT
        }
    }
}