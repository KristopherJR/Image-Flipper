using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.1, 04-12-21
/// </summary>
namespace Main.UserExceptions
{
    /// <summary>
    /// The user-defined ElementNotFoundException. This will be thrown when an element in a collection class can not be found.
    /// </summary>
    public class ElementNotFoundException : Exception
    {
        /// <summary>
        /// Default constructor for ElementNotFoundException.
        /// </summary>
        public ElementNotFoundException()
        {
        }

        /// <summary>
        /// Overloaded constructor for ElementNotFoundException. Allows an error-message to be provided.
        /// </summary>
        /// <param name="pErrorMessage">The error message to be printed to the user when the exception is thrown, passed to the parent class.</param>
        public ElementNotFoundException(string pErrorMessage) : base(pErrorMessage)
        {
        }
    }
}
