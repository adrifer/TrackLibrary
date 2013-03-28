using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackLibrary.W8.Services.LiveTile;

namespace TrackLibrary.W8.Services.LiveTile
{
    public class TileWideSmallImageAndText04 : ITileBase, ITileWide
    {
        public string Image01 { get; set; }
        public string Image01alt { get; set; }
        public string Text01 { get; set; }
        public string Text02 { get; set; }

        public string ToXml()
        {
            string xml = String.Format(@"<tile>
                                          <visual>
                                            <binding template='TileWideSmallImageAndText04'>
                                              <image id='1' src='{0}' alt='{1}'/>
                                              <text id='1'>{2}</text>
                                              <text id='2'>{3}</text>
                                            </binding>  
                                          </visual>
                                        </tile>", Image01, Image01alt, Text01, Text02);
            return xml;
        }
    }
}
