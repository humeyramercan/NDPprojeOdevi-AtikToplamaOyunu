using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPprojeOdevi
{
    class CamSise:Atik
    {
        public CamSise()
        {
            _hacim = 600;
            _atigim = Image.FromFile("glassBottle.jpg");
        }
    }
}
