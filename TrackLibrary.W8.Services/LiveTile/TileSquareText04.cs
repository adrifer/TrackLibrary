using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackLibrary.W8.Services.LiveTile;

namespace TrackLibrary.W8.Services.LiveTile
{
    public class TileSquareText04 : ITileBase, ITileSquare
    {
        public string Text01 { get; set; }

        public string ToXml()
        {
            string xml = String.Format(@"<tile>
                                          <visual>
                                            <binding template='TileSquareText04'>
                                              <text id='1'>{0}</text>
                                            </binding>  
                                          </visual>
                                        </tile>", Text01);
            return xml;
        }
    }
}
