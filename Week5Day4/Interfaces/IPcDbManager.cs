﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day4.Entities;

namespace Week5Day4.Interfaces
{
    interface IPcDbManager : IDbManager<Pc>
    {
        public List<Pc> FilterByOS(_OS os);
    }
}
