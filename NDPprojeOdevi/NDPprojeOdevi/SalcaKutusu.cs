using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NDPprojeOdevi
{
    class SalcaKutusu:Atik
    {
   public  SalcaKutusu()
        {
            _hacim = 550;

            _atigim = Image.FromFile("tomatoPaste.jpg");
            
        }
    }
}
