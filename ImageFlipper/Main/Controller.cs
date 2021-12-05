using Client;
using Server;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.5, 05-12-21
/// </summary>
namespace Main
{
    /// <summary>
    /// Main controller class for ImageFlipper. Acts as the communicated intermediary between the client and server and sets up the program.
    /// </summary>
    public class Controller
    {
        #region FIELDS
        // DECLARE an IClient, call it _client:
        private IClient _client;
        // DECLARE an IServer, call it _server:
        private IServer _server;
        #endregion

        #region PROPERTIES
        #endregion
        /// <summary>
        /// Constructor for Controller.
        /// </summary>
        public Controller()
        {
            // INITALISE the client and server:
            _client = new Client.Client();
            _server = new Server.Server();
            // RUN the application by calling the clients run method and pass in the required delegates:
            Application.Run(_client.Run(SendPathToServer, RotateImageClockwise, RotateImageCounterClockwise, FlipImageHorizontal, FlipImageVertical, SaveImage, SaveImageCopy));
        }
        /// <summary>
        /// Delegate method for SendPathToServerDelegate. Called from ImageGallery when the user tries to load an Image.
        /// </summary>
        /// <param name="pImagePaths">A List of the image paths to be sent to the server to be loaded.</param>
        public void SendPathToServer(IList<String> pImagePaths)
        {
            // CALL the Servers Load() method and pass in the paths parameter:
            _server.Load(pImagePaths);
            // TRIGGER a callback and provided the client with the loaded image from the server:
            foreach(String id in pImagePaths)
            {
                // ADD the Scaled Image to the client by requesting the Images id from the Servers loaded collection:
                _client.AddImage(id, _server.GetImage(id, 150, 150));
            }
        }
        /// <summary>
        /// Delegate method for FlipImageHorizontalDelegate. Called from ImageEditor when the user clicks the FlipImageHorizontal Button.
        /// </summary>
        /// <param name="pUid">The unique identifier of the image in the Servers storage to be flipped.</param>
        public void FlipImageHorizontal(string pUid)
        {
            // CALL the Server HorizontalFlipImage Method and pass in the uId of the image to flip:
            _server.HorizontalFlipImage(pUid);
            // UPDATE the clients ImageEditors Image by requesting the edited, scaled-image back from the server:
            _client.ImageEditor.EditImage = _server.GetImage(pUid, 300, 300);
        }
        /// <summary>
        /// Delegate method for FlipImageVerticalDelegate. Called from ImageEditor when the user clicks the FlipImageVertical Button.
        /// </summary>
        /// <param name="pUid">The unique identifier of the image in the Servers storage to be flipped.</param>
        public void FlipImageVertical(string pUid)
        {
            // CALL the Server VerticalFlipImage Method and pass in the uId of the image to flip:
            _server.VerticalFlipImage(pUid);
            // UPDATE the clients ImageEditors Image by requesting the edited, scaled-image back from the server:
            _client.ImageEditor.EditImage = _server.GetImage(pUid, 300, 300);
        }
        /// <summary>
        /// Delegate method for RotateImageClockwiseDelegate. Called from ImageEditor when the user clicks the RotateImageClockwise Button.
        /// </summary>
        /// <param name="pUid">The unique identifier of the image in the Servers storage to be rotated.</param>
        public void RotateImageClockwise(string pUid)
        {
            // CALL the Server RotateImage Method and pass in the uId of the image to rotate:
            _server.RotateImage(pUid);
            // UPDATE the clients ImageEditors Image by requesting the edited, scaled-image back from the server:
            _client.ImageEditor.EditImage = _server.GetImage(pUid, 300, 300);
        }
        /// <summary>
        /// Delegate method for RotateImageCounterClockwiseDelegate. Called from ImageEditor when the user clicks the RotateImageCounterClockwise Button.
        /// </summary>
        /// <param name="pUid">The unique identifier of the image in the Servers storage to be rotated.</param>
        public void RotateImageCounterClockwise(string pUid)
        {
            // CALL the Server RotateImageCounterClockwise Method and pass in the uId of the image to rotate:
            (_server as Server.Server).RotateImageCounterClockwise(pUid);
            // UPDATE the clients ImageEditors Image by requesting the edited, scaled-image back from the server:
            _client.ImageEditor.EditImage = _server.GetImage(pUid, 300, 300);
        }
        /// <summary>
        /// Allows a user to save their changes and overwrite the image on the disk.
        /// </summary>
        /// <param name="pUid">The unique identifier for the image to be saved.</param>
        public void SaveImage(string pUid)
        {
            // RETRIEVE the image from the server that the user has edited and save it to its original directory, overwriting it:
            (_server.GetImage(pUid, 300, 300)).Save(pUid);
            // OUTPUT a confirmation to the console that the save was succesful and provide the save directory:
            Console.WriteLine(pUid);
            Console.WriteLine("Image Sucessfully Overwritten!");
        }
        /// <summary>
        /// Allows the user to save a copy of their modified fish masterpiece!
        /// </summary>
        /// <param name="pUid">The uId of the image they have edited.</param>
        public void SaveImageCopy(string pUid)
        {
            // CREATE a new OpenFileDialog so that the user can choose a save location:
            SaveFileDialog save = new SaveFileDialog();
            // RESTRICT the save output to .PNG:
            save.Filter = "Image Files(*.png;)|*.png;";
            save.DefaultExt = "png";
            // SET a title for the save window:
            save.Title = "Save your Fishy!";
            // OPEN the File Explorer and wait for the user to choose the location:
            if (save.ShowDialog() == DialogResult.OK)
            {
                // RETRIEVE the image from the server that the user has edited and save it at the location they specified:
                (_server.GetImage(pUid, 300, 300)).Save(save.FileName);
                // OUTPUT a confirmation to the console that the save was succesful and provide the save directory:
                Console.WriteLine(save.FileName);
                Console.WriteLine("Copy of Image Saved!");
            }
        }
    }
}
