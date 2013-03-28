using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TrackLibrary.W8.Services
{
    /// <summary>
    /// Class to serialize/deserialize to JSON and save/load
    /// </summary>
    /// <typeparam name="T">Type to serialize</typeparam>
    public class JsonStorageService<T> : IStorageService<T> where T : new()
    {
        /// <summary>
        /// Load and deserialize fron JSON
        /// </summary>
        /// <param name="filename">Name of the file to load</param>
        /// <returns></returns>
        public async Task<T> LoadAsync(string filename)
        {
            T result = default(T);
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);

                string json = await FileIO.ReadTextAsync(file);

                result = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                result = new T();
            }
            return result;
        }

        /// <summary>
        /// Save and serialize to JSON
        /// </summary>
        /// <param name="filename">Name of the file to load</param>
        /// <param name="file">File to save and serialize</param>
        /// <returns></returns>
        public async Task SaveAsync(string filename, T file)
        {
            const string FILEAUX = "fileaux";

            try
            {
                //Abrimos el archivo donde vamos a guardar, si existe lo reemplazamos
                StorageFile saveFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(FILEAUX, CreationCollisionOption.ReplaceExisting);

                string json = JsonConvert.SerializeObject(file, Formatting.Indented);

                await FileIO.WriteTextAsync(saveFile, json);

                await saveFile.RenameAsync(filename, NameCollisionOption.ReplaceExisting);
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
