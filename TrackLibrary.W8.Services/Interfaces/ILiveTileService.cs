using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackLibrary.W8.Services
{
    interface ILiveTileService
    {
        void AddTile(TrackLibrary.W8.Services.LiveTile.ITileBase tile);
        void ClearLiveTile();
        void ClearTemporalyTiles();
        void SetBadge(int num);
        void SetBadge(TrackLibrary.W8.Services.LiveTile.BadgeGlyph glyph);
        void SetCollectionLiveTile<T>(System.Collections.Generic.IEnumerable<T> lista, Func<T, TrackLibrary.W8.Services.LiveTile.ITileBase> action);
        void UpdateTiles();
    }
}
