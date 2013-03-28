using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackLibrary.W8.Services.LiveTile;

namespace TrackLibrary.W8.Services.LiveTile
{
    public class TileWideSmallImageAndText02 : ITileBase, ITileWide
    {
        public string Image01 { get; set; }
        public string Image01alt { get; set; }
        public string Text01 { get; set; }
        public string Text02 { get; set; }
        public string Text03 { get; set; }
        public string Text04 { get; set; }
        public string Text05 { get; set; }

        public string ToXml()
        {
            string xml = String.Format(@"<tile>
                                          <visual>
                                            <binding template='TileWideSmallImageAndText02'>
                                              <image id='1' src='{0}' alt='{1}'/>
                                              <text id='1'>{2}</text>
                                              <text id='2'>{3}</text>
                                              <text id='3'>{4}</text>
                                              <text id='4'>{5}</text>
                                              <text id='5'>{6}</text>
                                            </binding>  
                                          </visual>
                                        </tile>", Image01, Image01alt, Text01, Text02, Text03, Text04, Text05);
            return xml;
        }
    }
}
