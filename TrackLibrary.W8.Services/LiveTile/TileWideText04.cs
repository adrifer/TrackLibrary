using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackLibrary.W8.Services.LiveTile;

namespace TrackLibrary.W8.Services.LiveTile
{
    public class TileWideText04 : ITileBase, ITileWide
    {
        public string Text01 { get; set; }


        public string ToXml()
        {
            string xml = String.Format(@"<tile>
                                          <visual>
                                            <binding template='TileWideText04'>
                                              <text id='1'>{0}</text>

                                            </binding>  
                                          </visual>
                                        </tile>", Text01);
            return xml;
        }
    }
}
