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
            Application.Run(_client.Run(SendPathToServer, RotateImageClockwise, RotateImageCounterClockwise, FlipImageHorizontal, FlipImageVertical));
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
    }
}
