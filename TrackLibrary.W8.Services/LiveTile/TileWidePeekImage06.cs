using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackLibrary.W8.Services.LiveTile;

namespace TrackLibrary.W8.Services.LiveTile
{
    public class TileWidePeekImage06 : ITileBase, ITileWide
    {
        public string Image01 { get; set; }
        public string Image01alt { get; set; }
        public string Image02 { get; set; }
        public string Image02alt { get; set; }
        public string Text01 { get; set; }

        public string ToXml()
        {
            string xml = String.Format(@"<tile>
                                          <visual>
                                            <binding template='TileWidePeekImage06'>
                                              <image id='1' src='{0}' alt='{1}'/>
                                              <image id='2' src='{2}' alt='{3}'/>
                                              <text id='1'>{4}</text>
                                            </binding>  
                                          </visual>
                                        </tile>", Image01, Image01alt, Image02, Image02alt, Text01);
            return xml;
        }
    }
}
