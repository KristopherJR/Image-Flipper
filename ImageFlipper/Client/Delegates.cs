using System;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.3, 04-12-21
/// </summary>
namespace Main
{
    /// <summary>
    /// Triggered from ImageGallery when the user loads an image path. Received by the Controller, then sent to Server.
    /// </summary>
    /// <param name="pImagePath">An IList containing the paths of the Images to be loaded into the Server storage.</param>
    public delegate void SendPathToServerDelegate(IList<String> pImagePath);
    /// <summary>
    /// Triggered from ImageGallery when the user wishes to open the editor. Received by the client.
    /// </summary>
    /// <param name="pSelectedImage">The Image that the user has selected.</param>
    /// <param name="pSelectedImageUid">The uId of the Image the user has selected.</param>
    public delegate void PrimeEditorDelegate(Image pSelectedImage, String pSelectedImageUid);
    /// <summary>
    /// Triggered from ImageEditor when the user presses the RotateClockwiseButton. Received by the Controller.
    /// </summary>
    /// <param name="uId">The Unique Identifier of the Image to be rotated in the Servers storage.</param>
    public delegate void RotateImageClockwiseDelegate(string uId);
    /// <summary>
    /// Triggered from ImageEditor when the user presses the RotateCounterClockwiseButton. Received by the Controller.
    /// </summary>
    /// <param name="uId">The Unique Identifier of the Image to be rotated in the Servers storage.</param>
    public delegate void RotateImageCounterClockwiseDelegate(string uId);
    /// <summary>
    /// Triggered from ImageEditor when the user presses the FlipImageHorizontalButton. Received by the Controller.
    /// </summary>
    /// <param name="uId">The Unique Identifier of the Image to be flipped in the Servers storage.</param>
    public delegate void FlipImageHorizontalDelegate(string uId);
    /// <summary>
    /// Triggered from ImageEditor when the user presses the FlipImageVerticalButton. Received by the Controller.
    /// </summary>
    /// <param name="uId">The Unique Identifier of the Image to be flipped in the Servers storage.</param>
    public delegate void FlipImageVerticalDelegate(string uId);
    /// <summary>
    /// Triggered from ImageEditor when the user presses the SaveImageButton. Received by the Controller.
    /// </summary>
    /// <param name="uId">The Unique Identifier of the Image to be saved in the Servers storage.</param>
    public delegate void SaveImageDelegate(string uId);
    /// <summary>
    /// Triggered from ImageEditor when the user presses the SaveACopyButton. Received by the Controller.
    /// </summary>
    /// <param name="uId">The Unique Identifier of the Image to be saved in the Servers storage.</param>
    public delegate void SaveImageCopyDelegate(string uId);
}
