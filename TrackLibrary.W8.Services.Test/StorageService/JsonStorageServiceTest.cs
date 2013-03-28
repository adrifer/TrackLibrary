using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackLibrary.W8.Services;
using TrackLibrary.W8.Services.Test.StorageService.Model;

namespace TrackLibrary.W8.Services.Test.StorageService
{
    [TestClass]
    public class JsonStorageServiceTest
    {
        [TestMethod]
        public async Task TestJsonStorageService_load_and_save()
        {
            Producto producto = new Producto()
            {
                Title = "Titulo",
                Subtitle = "Subtitulo",
                Id = 1
            };

            IStorageService<Producto> storageService = new JsonStorageService<Producto>();
            await storageService.SaveAsync("data.json", producto);

            Producto producto2 = await storageService.LoadAsync("data.json");

            Assert.AreEqual(producto.Title, producto2.Title);
        }

        [TestMethod]
        public async Task TestJsonStorageService_no_file_load_return_new_T()
        {
            IStorageService<Producto> storageService = new JsonStorageService<Producto>();

            Producto producto = await storageService.LoadAsync("nofile.json");

            Assert.IsNotNull(producto);
        }
    } 
}
