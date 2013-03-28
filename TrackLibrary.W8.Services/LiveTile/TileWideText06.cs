using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackLibrary.W8.Services.LiveTile;

namespace TrackLibrary.W8.Services.LiveTile
{
    public class TileWideText06 : ITileBase, ITileWide
    {
        public string Text01 { get; set; }
        public string Text02 { get; set; }
        public string Text03 { get; set; }
        public string Text04 { get; set; }
        public string Text05 { get; set; }
        public string Text06 { get; set; }
        public string Text07 { get; set; }
        public string Text08 { get; set; }
        public string Text09 { get; set; }
        public string Text10 { get; set; }

        public string ToXml()
        {
            string xml = String.Format(@"<tile>
                                          <visual>
                                            <binding template='TileWideText06'>
                                              <text id='1'>{0}</text>
                                              <text id='2'>{1}</text>
                                              <text id='3'>{2}</text>
                                              <text id='4'>{3}</text>
                                              <text id='5'>{4}</text>
                                              <text id='6'>{5}</text>
                                              <text id='7'>{6}</text>
                                              <text id='8'>{7}</text>
                                              <text id='9'>{8}</text>
                                              <text id='10'>{9}</text>
                                            </binding>  
                                          </visual>
                                        </tile>", Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08, Text09, Text10);
            return xml;
        }
    }
}
