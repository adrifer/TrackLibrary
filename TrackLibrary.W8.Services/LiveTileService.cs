using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackLibrary.W8.Services.LiveTile;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace TrackLibrary.W8.Services
{
    /// <summary>
    /// LiveTile service
    /// Templates: http://msdn.microsoft.com/en-us/library/windows/apps/hh761491.aspx
    /// </summary>
    public class LiveTileService : TrackLibrary.W8.Services.ILiveTileService
    {
        private List<ITileBase> tiles;
        private TileUpdater tileUpdater;
        private BadgeUpdater badgeUpdater;

        public LiveTileService()
        {
            tiles = new List<ITileBase>();

            tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
            badgeUpdater = BadgeUpdateManager.CreateBadgeUpdaterForApplication();

            tileUpdater.EnableNotificationQueue(true);
        }

        #region Public Methods


        /// <summary>
        /// Clear all tiles not set yet
        /// </summary>
        public void ClearTemporalyTiles()
        {
            tiles.Clear();
        }

        /// <summary>
        /// Removes all updates and causes the tile to display its default content as declared in the app's manifest.
        /// </summary>
        public void ClearLiveTile()
        {
            tileUpdater.Clear();
        }

        /// <summary>
        /// Set a collection of tiles
        /// </summary>
        /// <typeparam name="T">Type of the list</typeparam>
        /// <param name="list">List of objects to create a tyle</param>
        /// <param name="action">Method to create a tile for each object in the list</param>
        public void SetCollectionLiveTile<T>(IEnumerable<T> list, Func<T, ITileBase> action)
        {
            foreach (T tile in list.Take(5))
            {
                tiles.Add(action(tile));
            }
        }

        /// <summary>
        /// Add a single tile
        /// </summary>
        /// <param name="tile"></param>
        public void AddTile(ITileBase tile)
        {
            tiles.Add(tile);
        }

        /// <summary>
        /// Set a number badge
        /// </summary>
        /// <param name="num"></param>
        public void SetBadge(int num)
        {
            XmlDocument badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);
            XmlElement badgeElement = (XmlElement)badgeXml.SelectSingleNode("/badge");
            badgeElement.SetAttribute("value", num.ToString());

            BadgeNotification badge = new BadgeNotification(badgeXml);

            badgeUpdater.Update(badge);
        }

        /// <summary>
        /// Set a Glyph badge
        /// </summary>
        /// <param name="glyph">Enum with the glyph</param>
        public void SetBadge(BadgeGlyph glyph)
        {
            XmlDocument badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeGlyph);
            XmlElement badgeElement = (XmlElement)badgeXml.SelectSingleNode("/badge");
            badgeElement.SetAttribute("value", glyph.ToString());

            BadgeNotification badge = new BadgeNotification(badgeXml);

            badgeUpdater.Update(badge);
        }

        /// <summary>
        /// Update the live tile with all tiles you've added before
        /// </summary>
        public void UpdateTiles()
        {
            foreach (ITileBase tile in tiles)
            {
                tileUpdater.Update(Convert(tile.ToXml()));
            }
        }

        #endregion

        #region PrivateMethods

        private TileNotification Convert(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            return new TileNotification(document);
        }

        #endregion
    }
}
