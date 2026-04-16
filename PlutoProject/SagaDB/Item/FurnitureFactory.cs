using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using SagaLib;

namespace SagaDB.Furniture
{
    public class FurnitureFactory : Factory<FurnitureFactory, Furniture>
    {
        public FurnitureFactory()
        {
            this.loadingTab = "Loading furniture database";
            this.loadedTab = " furnitures loaded.";
            this.databaseName = "furniture";
            this.FactoryType = FactoryType.CSV;
        }

        protected override void ParseXML(System.Xml.XmlElement root, System.Xml.XmlElement current, Furniture item)
        {
            throw new NotImplementedException();
        }

        protected override uint GetKey(Furniture item)
        {
            return item.ItemID;
        }

        public Furniture GetFurniture(uint id)
        {
            if (items.ContainsKey(id))
            {
                Furniture f = items[id];
                return f;
            }
            else
            {
                Logger.ShowError("No Furniture Found! (" + id + ")");
                return null;
            }
        }

        protected override void ParseCSV(Furniture item, string[] paras)
        {
            if (!uint.TryParse(paras[0], out uint itemId))
                return;
            item.ItemID = itemId;
            if (paras[1] == null || paras[1] == "0" || paras[1] == "")
            {
                item.Name = "_";
            }
            else
            {
                item.Name = paras[1];
            }

            if (!uint.TryParse(paras[2], out uint pictId))
                return;
            item.PictID = pictId;
            //item.Type = byte.Parse(paras[6]);
            if (!uint.TryParse(paras[3], out uint eventId))
                return;
            item.EventID = eventId;
            if (!ushort.TryParse(paras[4], out ushort capacity))
                capacity = 0;
            item.Capacity = capacity;
            if (!ushort.TryParse(paras[5], out ushort defaultMotion))
            {
                defaultMotion = 0;
                Logger.ShowWarning(string.Format("Invalid furniture motion value for item {0}: {1}", item.ItemID, paras[5]));
            }
            item.DefaultMotion = defaultMotion;
            for (int v = 6; v < 13; v++)
            {
                if (ushort.TryParse(paras[v], out ushort motion) && motion > 0)
                    item.Motion.Add(motion);
            }
        }
    }
}
