using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackLibrary.W8.Services.LiveTile;

namespace TrackLibrary.W8.Services.LiveTile
{
    public class TileSquareImage : ITileBase, ITileSquare
    {
        public string Image01 { get; set; }
        public string Image01alt { get; set; }

        public string ToXml()
        {
            string xml = String.Format(@"<tile>
                                          <visual>
                                            <binding template='TileSquareBlock'>
                                              <image id='1' src='{0}' alt='{1}'/>
                                            </binding>  
                                          </visual>
                                        </tile>", Image01, Image01alt);
            return xml;
        }
    }
}
