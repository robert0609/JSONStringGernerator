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
        public int ZOrder
        {
            get
            {
                return this.CY + this.CHeight;
            }
        }
        public string ResourceId;

        public FoundationEntity Foundation;

        public void CreateFoundation(int flag)
        {
            this.Foundation = new FoundationEntity();
            if (flag == 0)
            {
                this.Foundation.Flag = "circle";
                this.Foundation.Radius = this.CWidth / 2;
            }
            else
            {
                this.Foundation.Flag = "rectangle";
                this.Foundation.RectPoints = new Location[2][];
                this.Foundation.RectPoints[0] = new Location[2];
                this.Foundation.RectPoints[1] = new Location[2];
                this.Foundation.RectPoints[0][0] = new Location { X = 0 - CWidth / 2, Y = 20 };
                this.Foundation.RectPoints[0][1] = new Location { X = CWidth / 2, Y = 20 };
                this.Foundation.RectPoints[1][0] = new Location { X = 0 - CWidth / 2, Y = -20 };
                this.Foundation.RectPoints[1][1] = new Location { X = CWidth / 2, Y = -20 };
            }
        }
    }

    public class FoundationEntity
    {
        public string Flag;
        public int Radius;
        public Location[][] RectPoints;
    }

    public class Location
    {
        public int X;
        public int Y;
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
