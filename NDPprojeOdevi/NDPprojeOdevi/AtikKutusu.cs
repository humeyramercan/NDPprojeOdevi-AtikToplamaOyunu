using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPprojeOdevi
{
    class AtikKutusu:IAtikKutusu // Atık kutularımızın kalıtım alacağı genel bir atık kutusu sınıfı tanımladık ve IAtik interface imizden kalıtım aldık
    {
      protected  int _bosaltmaPuani; // her kutumuzun boşaltma puanını atayacagımız değişkenimizi tanımladık
      protected double _dolulukOrani; //her kutumuzun doluluk oranını hesaplayıp atayacagımız değişkenimizi tanımladık
      protected double _kapasite; // her kutumuzun kapasitesini atayacağımız değişkenimizi tanımladık
      public  int BosaltmaPuani { get { return _bosaltmaPuani; } } // boşaltma puanımızı okuyabilmek için propertymizi tanımladık
        public bool Ekle(Atik atik) // ekle metodumuz, kutumuzda eğer eklenen atık hacmi kadar veya daha büyük bir hacim varsa true dondurecektir
        {          
            if(atik.Hacim <=Kapasite- DoluHacim)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
       public   bool Bosalt() // boşalt metodumuz eger kutumuzun doluluk oranı 75 ustundeyse true dondurecektir
        {
            if(DolulukOrani>75)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      public    double Kapasite { get { return _kapasite; } } // her kutumuzun kapasitesiniokuyacağımız propertymizi tanımladık
      public   double DoluHacim { get; private set; } // her kutumuzun dolu hacmini atayacağımız propertymizi tanımladık.Bu propertynin set metodunu private yaptık çünkü kutunun yeni dolu hacmini sınıf içerisinde hesaplayacağız dışarıdan erişerek değil.
        public void DoluHacimHesapla(Atik atik) // Bu metod kutunun mevcut dolu hacmine içine atılacağı atığın hacmini ekler

        {
            DoluHacim += atik.Hacim;
        }
        public void KutuyuBosalt() // Bu metod kutunun dolu hacmini 0 layarak kutuyu boşlatır.
        {
            DoluHacim = 0;
        }

        public double DolulukOrani // DolulukOrani propertysi hesaplanan _dolulukOrani değerini bize döndürecektir
        {
            get
            {
                 _dolulukOrani= (DoluHacim / Kapasite) * 100; // doluluk oranını hesaplayıp değişkenimize atadık
                return _dolulukOrani;
            }

           
        }
    }
}
