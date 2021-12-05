using System;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.2, 03-12-21
/// </summary>
namespace Server
{
    /// <summary>
    /// Interface for ImageStorage.
    /// </summary>
    public interface IImageStorage
    {
        #region PROPERTIES
        /// <summary>
        /// Get-only Property for the images main storage. Returns the Dictionary of images.
        /// </summary>
        Dictionary<String,Image> Images
        {
            get;
        }
        #endregion
        /// <summary>
        /// Adds images to the collection from the file paths.
        /// </summary>
        /// <param name="pImagePaths">An IList of image paths to be added to storage.</param>
        void Add(IList<String> pImagePaths);
        /// <summary>
        /// Remove an image from the collection.
        /// </summary>
        /// <param name="pUid">The Uid key of the image to be removed from the dictionary.</param>
        void Remove(String pUid);
        /// <summary>
        /// Retrieves an image from the ImageStorage.
        /// </summary>
        /// <param name="pUid">The unique identifier of the Image to be retrieved from the dictionary. This will usually be the filepath.</param>
        /// <returns>The Image matching the provided uId from Server Storage.</returns>
        Image RetrieveImage(String pUid);
    }
}
