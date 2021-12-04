using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.1, 04-12-21
/// </summary>
namespace Server.UserExceptions
{
    /// <summary>
    /// The user-defined InvalidParameterException. This will be thrown whenever a parameter is too big, small or the wrong format.
    /// </summary>
    public class InvalidParameterException : Exception
    {
        /// <summary>
        /// Default constructor for InvalidParameterException.
        /// </summary>
        public InvalidParameterException()
        {
        }

        /// <summary>
        /// Overloaded constructor for InvalidParameterException. Allows an error-message to be provided.
        /// </summary>
        /// <param name="pErrorMessage">The error message to be printed to the user when the exception is thrown, passed to the parent class.</param>
        public InvalidParameterException(string pErrorMessage) : base(pErrorMessage)
        {
        }
    }
}
