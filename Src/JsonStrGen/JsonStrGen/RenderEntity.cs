using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonStrGen
{
    /// <summary>
    /// {"CX": 100, "CY": 458, "CWidth": 96, "CHeight": 128, "SX": 0, "SY": 0, "SWidth": 96, "SHeight": 128, "ZOrder": 586, "ResourceId": "./Resource/Img/tree.png"}
    /// </summary>
    public class RenderEntity
    {
        public int CX;
        public int CY;
        public int CWidth;
        public int CHeight;
        public int SX;
        public int SY;
        public int SWidth;
        public int SHeight;
        public int ZOrder;
        public string ResourceId;
    }

    public class MapEntity
    {
        public int XIndex;
        public int YIndex;
        public int SX;
        public int SY;
        public int ZOrder;
        public string ResourceId;
    }
}
