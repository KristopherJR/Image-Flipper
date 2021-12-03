﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.1, 02-12-21
/// </summary>
namespace Main
{
    /// <summary>
    /// Delegate to send an image path to the server.
    /// </summary>
    public delegate void SendPathToServerDelegate(IList<String> pImagePath);
    /// <summary>
    /// Triggered from ImageGallery when the user wishes to open the editor. Received by the client.
    /// </summary>
    public delegate void PrimeEditorDelegate();
    
}
