using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackLibrary.W8.Services
{
    /// <summary>
    /// Class to serialize/deserialize and save/load
    /// </summary>
    /// <typeparam name="T">Type to serialize</typeparam>
    public interface IStorageService<T>
    {
        /// <summary>
        /// Load and deserialize
        /// </summary>
        /// <param name="filename">Name of the file to load</param>
        /// <returns></returns>
        Task<T> LoadAsync(string filename);

        /// <summary>
        /// Save and serialize
        /// </summary>
        /// <param name="filename">Name of the file to load</param>
        /// <param name="file">File to save and serialize</param>
        /// <returns></returns>
        Task SaveAsync(string filename, T file);
    }
}
