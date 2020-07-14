using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPprojeOdevi
{
    class Gazete:Atik
    {
        public Gazete()
        {
            _hacim = 250;
            _atigim = Image.FromFile("newspaper.png");
        }
    }
}
