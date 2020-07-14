using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPprojeOdevi
{
    class KolaKutusu:Atik
    {
       public KolaKutusu()
        {
            _hacim = 350;
            _atigim = Image.FromFile("coke.png");
        }
    }
}
