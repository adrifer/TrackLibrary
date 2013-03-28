using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackLibrary.W8.Services.LiveTile
{
    public class TileSquareAndWide : ITileBase
    {
        private ITileSquare _square;
        private ITileWide _wide;

        public TileSquareAndWide(ITileSquare square, ITileWide wide)
        {
            _square = square;
            _wide = wide;
        }

        public string ToXml()
        {
            string squareString = _square.ToXml().Replace("<tile>", "").Replace("<visual>", "").Replace("</visual>", "").Replace("</tile>", "");
            string wideString = _wide.ToXml().Replace("<tile>", "").Replace("<visual>", "").Replace("</visual>", "").Replace("</tile>", "");

            string tile = String.Format(@"<tile>
                                            <visual>
                                                {0}
                                                {1}
                                            </visual>
                                          </tile>", squareString, wideString);
            return tile;
        }
    }
}
