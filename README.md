# TrackLibrary

## ¿Que es?

TrackLibrary es una librería para usar en aplicaciones Windows 8 XAML. Contiene una serie de servicios que nos ayudan a realizar una serie de tareas comunes.

## ¿Que servicios trae?
Hasta ahora TrackLibrary contiene:

* `JsonStorageService` - Servicio para guardar en un fichero con formato JSON.
* `XmlStorageService` - Servicio para guardar en un fichero con formato XML.
* `LiveTileService` - Servicio para gestionar los Live Tiles de nuestra app.

## ¿Como usarlo?

### JsonStorageService
Para guardar un elemento y cargarlo sería:

  using TrackLibrary.W8.Services;
	
	IStorageService<Producto> storageService = new JsonStorageService<Producto>();
  List<string> list = new List<string>();
  list.Add("Elemento 1");
  list.Add("Elemento 2");
  list.Add("Elemento 3");
	
	// Guardar el objeto
	await storageService.SaveAsync("data.json", list);
	
	//Cargamos el objeto desde el archivo
	List<string> list2 = await storageService.LoadAsync("data.json");

### LiveTileService
Ejemplo para crear live tiles desde una lista de elementos

  using TrackLibrary.W8.Services;
  using TrackLibrary.W8.Services.LiveTile;
  
	ILiveTileService tileService = new LiveTileService();
  List<Persona> list = new List<Persona>();
  list.Add(new Persona(){Nombre = "Walter", Apellido = "Bishop"});
  list.Add(new Persona(){Nombre = "Peter", Apellido = "Bishop"});
  list.Add(new Persona(){Nombre = "Olivia", Apellido = "Dunham"});
	
	// Le pasamos la lista de objetos que queremos tener como tiles
  // y ademas le matamos un methodo que dado un objeto de ese tipo
  // devuelva un tile ya creado para cada objeto en la lista.
	tileService.SetCollectionLiveTile<Persona>(list, persona =>
  {
    TileWideBlockAndText02 tile = new LiveTile.TileWideBlockAndText02();
    tile.Text01 = persona.Nombre;
    tile.Text02 = persona.Apellido;
    
    return tile;
  });
  
  // Le decimos al servicio que actualice ya el LiveTile con los tiles
  // que le hemos pasado
  tileService.UpdateTiles();
