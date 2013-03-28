using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackLibrary.W8.Services.LiveTile;

namespace TrackLibrary.W8.Services.LiveTile
{
    public class TileWideImageCollection : ITileBase, ITileWide
    {
        public string Image01 { get; set; }
        public string Image01alt { get; set; }
        public string Image02 { get; set; }
        public string Image02alt { get; set; }
        public string Image03 { get; set; }
        public string Image03alt { get; set; }
        public string Image04 { get; set; }
        public string Image04alt { get; set; }
        public string Image05 { get; set; }
        public string Image05alt { get; set; }

        public string ToXml()
        {
            string xml = String.Format(@"<tile>
                                          <visual>
                                            <binding template='TileWideImageCollection'>
                                              <image id='1' src='{0}' alt='{1}'/>
                                              <image id='2' src='{2}' alt='{3}'/>
                                              <image id='3' src='{4}' alt='{5}'/>
                                              <image id='4' src='{6}' alt='{7}'/>
                                              <image id='5' src='{8}' alt='{9}'/>
                                            </binding>  
                                          </visual>
                                        </tile>", Image01, Image01alt, Image02, Image02alt, Image03, Image03alt, Image04, Image04alt, Image05, Image05alt);
            return xml;
        }
    }
}
