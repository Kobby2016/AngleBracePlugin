﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tekla Structures Namespaces
using TSM = Tekla.Structures.Model;
using TSD = Tekla.Structures.Dialog;
using TSDT = Tekla.Structures.Datatype;
using T3D = Tekla.Structures.Geometry3d;
using TSMUI = Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;

namespace AngleBracingPlugin
{
    class StructuresData
    {
        [StructuresField("AngleBracingType")]
        public TSDT.Integer AngleBracingType;
        [StructuresField("AngleBracingProfile")]
        public TSDT.Integer AngleBracingProfile;
        [StructuresField("AnglePosition")]
        public TSDT.Integer AnglePosition;
        [StructuresField("AngleOffset")]
        public TSDT.Distance AngleBracingTyper;
    }
}
