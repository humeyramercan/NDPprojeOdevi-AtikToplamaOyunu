using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NDPprojeOdevi
{
    class Atik:IAtik // bütün atıklarımızın miras alacağı genel bir atık sınıfı tanımladık ve IAtik interface inden kalıtım aldık
    {
      protected int _hacim;
      public  int Hacim { get { return _hacim; } }

      protected Image _atigim;
  
      public Image Atigim { get { return _atigim; } }

       
    }  
}
     