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
            Application.Run(_client.Run());
        }
    }
}
