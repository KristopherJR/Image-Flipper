using System;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.1, 04-12-21
/// </summary>
namespace Server.UserExceptions
{
    /// <summary>
    /// The user-defined ElementNotFoundException. This will be thrown when an element in a collection class can not be found.
    /// </summary>
    public class ImageAlreadyLoadedException : Exception
    {
        /// <summary>
        /// Default constructor for ImageAlreadyLoadedException.
        /// </summary>
        public ImageAlreadyLoadedException()
        {
            // Do nothing
        }
        /// <summary>
        /// Overloaded constructor for ImageAlreadyLoadedException. Allows an error-message to be provided.
        /// </summary>
        /// <param name="pErrorMessage">The error message to be printed to the user when the exception is thrown, passed to the parent class.</param>
        public ImageAlreadyLoadedException(string pErrorMessage) : base(pErrorMessage)
        {
            // Do nothing
        }
    }
}
