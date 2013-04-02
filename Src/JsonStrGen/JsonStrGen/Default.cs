using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;

namespace JsonStrGen
{
    public partial class Default : Form
    {
        public Default()
        {
            InitializeComponent();
            this.btnGen.Click += new EventHandler(btnGen_Click);
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            IList<ResourceEntity> resourceList = new List<ResourceEntity>();
            resourceList.Add(new ResourceEntity { ResourceId = "1", ImageFilePath = "./Resource/Img/mapCell.png" });
            resourceList.Add(new ResourceEntity { ResourceId = "2", ImageFilePath = "./Resource/Img/tree.png" });

            IList<RenderEntity> mapList = new List<RenderEntity>();
            for (int x = 1; x <= 100; ++x)
            {
                for (int y = 1; y <= 100; ++y)
                {
                    int cx, cy;
                    this.ConvertMapIndex2Location(x, y, out cx, out cy);
                    mapList.Add(new RenderEntity { CX = cx, CY = cy, CWidth = 64, CHeight = 64, SX = 0, SY = 0, SWidth = 64, SHeight = 64, ResourceId = "1" });
                }
            }

            IList<RenderEntity> buildingList = new List<RenderEntity>();
            buildingList.Add(new RenderEntity { CX = 400, CY = 100, CWidth = 96, CHeight = 128, SX = 0, SY = 0, SWidth = 96, SHeight = 128, ResourceId = "2" });
            buildingList.Add(new RenderEntity { CX = 300, CY = 256, CWidth = 96, CHeight = 128, SX = 0, SY = 0, SWidth = 96, SHeight = 128, ResourceId = "2" });
            buildingList.Add(new RenderEntity { CX = 500, CY = 500, CWidth = 96, CHeight = 128, SX = 0, SY = 0, SWidth = 96, SHeight = 128, ResourceId = "2" });
            buildingList.Add(new RenderEntity { CX = 100, CY = 458, CWidth = 96, CHeight = 128, SX = 0, SY = 0, SWidth = 96, SHeight = 128, ResourceId = "2" });
            buildingList[0].CreateFoundation(0);
            buildingList[1].CreateFoundation(1);
            buildingList[2].CreateFoundation(0);
            buildingList[3].CreateFoundation(1);

            var str1 = (new JavaScriptSerializer()).Serialize(resourceList);
            var str2 = (new JavaScriptSerializer()).Serialize(mapList);
            var str3 = (new JavaScriptSerializer()).Serialize(buildingList);

            using (var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "out.json", false, Encoding.UTF8))
            {
                sw.WriteLine(str1);
                sw.WriteLine();
                sw.WriteLine(str2);
                sw.WriteLine();
                sw.WriteLine(str3);
                sw.Flush();
                sw.Close();
            }
        }

        private void ConvertMapIndex2Location(int xIndex, int yIndex, out int x, out int y)
        {
            x = (xIndex - 1) * 64;
            y = (yIndex - 1) * 64;
        }
    }
}
