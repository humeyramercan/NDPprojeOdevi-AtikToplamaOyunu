﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPprojeOdevi
{
    class Salatalik:Atik
    {
        public Salatalik()
        {
            _hacim = 120;
            _atigim = Image.FromFile("cucumber.jpg");
        }
    }
}