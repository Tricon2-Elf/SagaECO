using System;

namespace SagaDB.Item
{
    [Serializable]
    public class Hair
    {
        public uint ItemID;
        public byte Gender;
        public short HairStyle;
        public short HairWig;
        public short ManageGroup;
        public string HairName;
        public string WigName;
        public string NpcBeforeSay;
        public string NpcAfterSay;
        public string Remarks;
    }
}
