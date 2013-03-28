using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace TrackLibrary.W8.Services
{
    /// <summary>
    /// Class to serialize/deserialize to XML and save/load
    /// </summary>
    /// <typeparam name="T">Type to serialize</typeparam>
    public class XmlStorageService<T> : IStorageService<T> where T : new()
    {
        /// <summary>
        /// Load and deserialize fron XML
        /// </summary>
        /// <param name="filename">Name of the file to load</param>
        /// <returns></returns>
        public async Task<T> LoadAsync(string filename)
        {
            T result = default(T);
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);

                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    if (stream != null)
                    {
                        //Inicializamos el serializador y desserializamos
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        result = (T)serializer.Deserialize(stream);
                    }
                }
            }
            catch (Exception)
            {
                result = new T();
            }
            return result;
        }

        /// <summary>
        /// Save and serialize to XML
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
                using (Stream stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(FILEAUX, CreationCollisionOption.ReplaceExisting))
                {
                    //Serializamos
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stream, file);
                    await stream.FlushAsync();
                }
                await saveFile.RenameAsync(filename, NameCollisionOption.ReplaceExisting);
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
