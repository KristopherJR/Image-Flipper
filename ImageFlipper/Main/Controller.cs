using Client;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Main
{
    /// <summary>
    /// Main controller class for ImageFlipper.
    /// 
    /// Author: Kristopher Randle
    /// Version: 0.1, 02-12-21
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

        public Controller()
        {
            // INITALISE the client and server:
            _client = new Client.Client();
            _server = new Server.Server();
            // RUN the application by calling the clients run method:
            Application.Run(_client.Run(SendPathToServer, RotateImageClockwise, RotateImageCounterClockwise, FlipImageHorizontal, FlipImageVertical, SaveImage, SaveImageCopy));
        }

        public void SendPathToServer(IList<String> pImagePaths)
        {
            _server.Load(pImagePaths);
            // TRIGGER a callback and provided the client with the loaded image from the serveR:
            foreach(String id in pImagePaths)
            {
                _client.AddImage(id, _server.GetImage(id, 150, 150));
            }
        }

        public void FlipImageHorizontal(string pUid)
        {
            (_server as Server.Server).HorizontalFlipImage(pUid);
            _client.ImageEditor.EditImage = _server.GetImage(pUid, 300, 300);
        }
        public void FlipImageVertical(string pUid)
        {
            (_server as Server.Server).VerticalFlipImage(pUid);
            _client.ImageEditor.EditImage = _server.GetImage(pUid, 300, 300);
        }
        public void RotateImageClockwise(string pUid)
        {
            Console.WriteLine("delegate fired!!!");
            _server.RotateImage(pUid);
            _client.ImageEditor.EditImage = _server.GetImage(pUid, 300, 300);
        }
        public void RotateImageCounterClockwise(string pUid)
        {
            (_server as Server.Server).RotateImageCounterClockwise(pUid);
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
