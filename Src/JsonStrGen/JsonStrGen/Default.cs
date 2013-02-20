﻿using System;
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
            resourceList.Add(new ResourceEntity { ResourceId = 1, ImageFilePath = "./Resource/Img/mapCell.png" });
            resourceList.Add(new ResourceEntity { ResourceId = 2, ImageFilePath = "./Resource/Img/tree.png" });

            IList<MapEntity> mapList = new List<MapEntity>();
            for (int x = 1; x <= 20; ++x)
            {
                for (int y = 1; y <= 15; ++y)
                {
                    mapList.Add(new MapEntity { XIndex = x, YIndex = y, SX = 0, SY = 0, ZOrder = 0, ResourceId = 1 });
                }
            }

            var str1 = (new JavaScriptSerializer()).Serialize(resourceList);
            var str2 = (new JavaScriptSerializer()).Serialize(mapList);

            using (var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "out.json", false, Encoding.UTF8))
            {
                sw.WriteLine(str1);
                sw.WriteLine();
                sw.WriteLine(str2);
                sw.Flush();
                sw.Close();
            }
        }
    }
}