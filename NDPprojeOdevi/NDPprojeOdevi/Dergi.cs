using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPprojeOdevi
{
    class Dergi:Atik
    {
        public Dergi()
        {
            _hacim = 200;
            _atigim = Image.FromFile("magazine.jpg");
        }
    }
}
