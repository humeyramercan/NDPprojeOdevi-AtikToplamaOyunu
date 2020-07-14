using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPprojeOdevi
{
    class Domates:Atik
    {
        public Domates()
        {
            _hacim = 150;
            _atigim = Image.FromFile("tomato.png");
        }
    }
}
