using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:4 (PROJE ÖDEVİ)
**				ÖĞRENCİ ADI............:Hümeyra Mercan
**				ÖĞRENCİ NUMARASI.......:G191210350
**              DERSİN ALINDIĞI GRUP...:2 C
****************************************************************************/

namespace NDPprojeOdevi
{
    public partial class Form1 : Form
    {
        KolaKutusu _cokeBox = new KolaKutusu();
        SalcaKutusu _tomatoPasteBox = new SalcaKutusu();
        Salatalik _cucumber = new Salatalik();
        Domates _tomato = new Domates();
        Dergi _magazine = new Dergi();
        Gazete _newspaper = new Gazete();               //atıklarımız ve kutularımızın nesnelerini oluşturduk
        Bardak _glass = new Bardak();
        CamSise _glassBottle = new CamSise();
        OrganikAtikKutusu _organikAtikKutusu = new OrganikAtikKutusu();
        KagitKutusu _kagitKutusu = new KagitKutusu();
        CamKutusu _camKutusu = new CamKutusu();
        MetalKutusu _metalKutusu = new MetalKutusu();
      
        List<Atik> atiklarim = new List<Atik>(); // rastgele resimler gelmesi için atıklarımızı diziye alacağız.Bu yüzden listemizi tanımladık
        List<Button> butonlarim = new List<Button>(); // ekleme ve boşaltma butonlarımızın aktif ve pasiflik durumundaki değişikliklerinde kolaylık olması için butonlarımızı listeye aldık

        Random _rastgeleSayi = new Random(); // listedeki index'e göre rastgele resim gelmesi için random nesnemizi tanımladık
        int _sure; // suremiz için değişken tanımladık
        int index = 0; // listemizin index değerini tutması için değişkenimizi tanımladık
        int puan = 0; // puanımızı tutması için değişkenimizi tanımladık
        public Form1()
        {       
            InitializeComponent();
        }       
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // pictureBox ımızın resim görüntüsünü strerch yaptık

            atiklarim.Add(_cokeBox);
            atiklarim.Add(_tomatoPasteBox);
            atiklarim.Add(_cucumber);
            atiklarim.Add(_tomato);
            atiklarim.Add(_magazine);   // atiklarimizi listeye aldık
            atiklarim.Add(_glass);
            atiklarim.Add(_glassBottle);
            atiklarim.Add(_cokeBox);
            atiklarim.Add(_newspaper);

            butonlarim.Add(organikAtikButton);
            butonlarim.Add(kagitButton);
            butonlarim.Add(camButton);
            butonlarim.Add(metalButton);  // ekleme ve boşaltma butonlarımızı listemize
            butonlarim.Add(organikAtikBosaltButton);
            butonlarim.Add(kagitAtikBosaltButton);
            butonlarim.Add(camAtikBosaltButton);
            butonlarim.Add(metalAtikBosaltButton);
        }

            private void YeniOyunButton_Click(object sender, EventArgs e)
        {

            yeniOyunButton.Enabled = false; // yeni oyun dediğimiz zaman yeni oyun butonumuz süre bitene kadar pasif olmalı. Bu yüzden butona basar basmaz enabled özelliğini false yaptık
            yeniOyunButton.ForeColor = Color.Black; // butonun pasif olduğu belli olsun diye yazı rengini değiştirdik
            yeniOyunButton.BackColor = Color.Firebrick; // butonun pasif olduğu belli olsun diye arkaplan rengini değiştirdik

            foreach (var butonlar in butonlarim)
            {
                butonlar.Enabled = true;              //süre bittiğinde boşaltma ve ekleme butonlarımız pasif oluyor. Tekrar Yeni oyun diyince bu butonları aktifleştirdik.
                butonlar.BackColor = Color.DeepSkyBlue;  // ekleme ve boşaltma butonlarımızın aktifleştiğini görmek adına arka plan renklerini baştaki aktifken ki haline getirdik 
            }
                                   
            _sure = 60; // yeni oyun diyince süremizi 60 yaptık
            sureLabel.Text = _sure.ToString(); // başlangı.taki suremizi labela yazdırdık

            metalAtikListBox.Items.Clear();
            camAtikListBox.Items.Clear();       //Her yeni oyun diyişimizde listboxlarımızı temizledik
            organikAtikListBox.Items.Clear();
            kagitAtikListBox.Items.Clear();

            metalAtikProgressBar.Value = 0;
            kagitAtikProgressBar.Value = 0;     //progressBar larımızı 0 ladık
            organikAtikProgressBar.Value = 0;
            camAtikProgressBar.Value = 0;

            _organikAtikKutusu.KutuyuBosalt();
            _metalKutusu.KutuyuBosalt();
            _camKutusu.KutuyuBosalt();      //Kutularımızı boşalttık
            _kagitKutusu.KutuyuBosalt();

            puan = 0; // puanımızı 0 layıp labela yazdırdık
            puanLabel.Text = puan.ToString();
          
            timer1.Start(); // timer vasıtası ile süremizi başlattık

            index = _rastgeleSayi.Next(0, 8); // rastgele sayımızı ürettik
           
            pictureBox1.Image = atiklarim[index].Atigim; // listemizden gelen rastgele atığımızın resmini pictureBox ımıza bastırdık

           
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (_sure == 0) // eğer ki _sure değerimiz 0 olmuşsa
            {
                timer1.Stop(); // timer vasıtası ile süremizi durdurduk

                yeniOyunButton.Enabled = true;
                yeniOyunButton.ForeColor = Color.White; // yeni oyun butonumuzu aktifleştirdik ve renklerini ilk baştaki aktifken ki haline çevirdik
                yeniOyunButton.BackColor = Color.OrangeRed;

                foreach (var butonlar in butonlarim)
                {
                    butonlar.Enabled = false;  // ekleme ve boşaltma butonlarımızı pasifleştirdik
                    butonlar.BackColor = Color.SteelBlue;  // ekleme ve boşaltma butonlarımızın pasifleştiğini görmek adına arka plan renklerini değiştirdik
                }
                                          
            }
            else // eger ki _sure değerimiz 0 değilse
            {
                _sure -= 1; // süremizi 1 azaltarak süremiz devam edecektir
                sureLabel.Text = _sure.ToString(); // süremizi azaldıkça labelımıza yazdırıyoruz
            }
        }

        private void OrganikAtikButton_Click(object sender, EventArgs e)
        {                            
            index = _rastgeleSayi.Next(0, 8); // organik atığımızı kutuya eklemek için butona bastığımızda hemen bir sonraki yeni resim için rastgele sayı üretttik
               
           if (pictureBox1.Image == _cucumber.Atigim && _organikAtikKutusu.Ekle(_cucumber)) // eger ki pictureBoxtaki resim salatalık ise ve salatalığı alacak kadar yer varsa (%75 doluluk oranının zaten altındadır kutu ilk ifte onu kontrol ettik zaten)
            {
                _organikAtikKutusu.DoluHacimHesapla(_cucumber); // DoluHacimHesapla metodu yardımıyla kutumuzun dolu hacmine kutuya attığımız atığın hacmini ekledik
                organikAtikListBox.Items.Add("Salatalik " + _cucumber.Hacim); // listemize salatalık ve hacmini yazdırdık
                organikAtikProgressBar.Value = (int)_organikAtikKutusu.DolulukOrani; // progressBarımızı doluluk oranı kadar arttırdık               
                puan += _cucumber.Hacim; // salatalığımızın hacmi kadar mevcut puanımızın ustune puan ekledik
                puanLabel.Text = puan.ToString(); // puanımızı label a yazdırdık
                pictureBox1.Image = atiklarim[index].Atigim; // ve rastgele yeni atık resmi bastırdık

            }
        else  if(pictureBox1.Image == _tomato.Atigim && _organikAtikKutusu.Ekle(_cucumber))// eger ki pictureBoxtaki resim domates ise ve salatalığı alacak kadar yer varsa 
            {
                _organikAtikKutusu.DoluHacimHesapla(_tomato); // DoluHacimHesapla metodu yardımıyla kutumuzun dolu hacmine kutuya attığımız atığın hacmini ekledik
                organikAtikListBox.Items.Add("Domates " + _tomato.Hacim); // listemize salatalık ve hacmini yazdırdık
                organikAtikProgressBar.Value = (int)_organikAtikKutusu.DolulukOrani; // progressBarımızı doluluk oranı kadar arttırdık
                puan += _tomato.Hacim;  // domatesimizin hacmi kadar mevcut puanımızın ustune puan ekledik
                puanLabel.Text = puan.ToString(); // puanımızı label a yazdırdık
                pictureBox1.Image = atiklarim[index].Atigim; // ve rastgele yeni atık resmi bastırdık
                
            }
           
        }
        //*************************************AYNI İŞLEMLERİ DİĞER ATIK KUTULARIMIZIN EKLEME BUTONLARI İÇİN DE YAPTIK******************************************
        private void KagitButton_Click(object sender, EventArgs e)
        {
            index = _rastgeleSayi.Next(0, 8);
                     
           if (pictureBox1.Image == _newspaper.Atigim && _kagitKutusu.Ekle(_newspaper))
            {
                _kagitKutusu.DoluHacimHesapla(_newspaper);
                kagitAtikListBox.Items.Add("Gazete " + _newspaper.Hacim);
               kagitAtikProgressBar.Value = (int)_kagitKutusu.DolulukOrani;               
                puan += _newspaper.Hacim;
                puanLabel.Text = puan.ToString();
                pictureBox1.Image = atiklarim[index].Atigim;

            }
            else if (pictureBox1.Image == _magazine.Atigim && _kagitKutusu.Ekle(_newspaper))
            {

                _kagitKutusu.DoluHacimHesapla(_magazine);
                kagitAtikListBox.Items.Add("Dergi " + _magazine.Hacim);
                kagitAtikProgressBar.Value = (int)_kagitKutusu.DolulukOrani;               
                puan += _newspaper.Hacim;
                puanLabel.Text = puan.ToString();
                pictureBox1.Image = atiklarim[index].Atigim;

            }

        }

        private void CamButton_Click(object sender, EventArgs e)
        {
        
            index = _rastgeleSayi.Next(0, 8);
                      
            if (pictureBox1.Image == _glass.Atigim && _camKutusu.Ekle(_glass))
            {
                _camKutusu.DoluHacimHesapla(_glass);
                camAtikListBox.Items.Add("Bardak " + _glass.Hacim);
                camAtikProgressBar.Value = (int)_camKutusu.DolulukOrani;              
                puan += _glass.Hacim;
                puanLabel.Text = puan.ToString();
                pictureBox1.Image = atiklarim[index].Atigim;


            }
            else if (pictureBox1.Image == _glassBottle.Atigim && _camKutusu.Ekle(_glassBottle))
            {

                _camKutusu.DoluHacimHesapla(_glassBottle);
                camAtikListBox.Items.Add("Cam Şişe " + _glassBottle.Hacim);
                camAtikProgressBar.Value = (int)_camKutusu.DolulukOrani;               
                puan += _glassBottle.Hacim;
                puanLabel.Text = puan.ToString();
                pictureBox1.Image = atiklarim[index].Atigim;

            }
       }

        private void MetalButton_Click(object sender, EventArgs e)
        {          
            index = _rastgeleSayi.Next(0, 8);          
           
          if (pictureBox1.Image == _cokeBox.Atigim && _metalKutusu.Ekle(_cokeBox))
            {
                _metalKutusu.DoluHacimHesapla(_cokeBox);
                metalAtikListBox.Items.Add("Kola Kutusu " + _cokeBox.Hacim);
                metalAtikProgressBar.Value = (int)_metalKutusu.DolulukOrani;
                puan += _cokeBox.Hacim;
                puanLabel.Text = puan.ToString();
                pictureBox1.Image = atiklarim[index].Atigim;

            }
           else  if (pictureBox1.Image == _tomatoPasteBox.Atigim && _metalKutusu.Ekle(_tomatoPasteBox))
            {

                _metalKutusu.DoluHacimHesapla(_tomatoPasteBox);
                metalAtikListBox.Items.Add("Salça Kutusu " + _tomatoPasteBox.Hacim);
                metalAtikProgressBar.Value = (int)_metalKutusu.DolulukOrani;              
                puan += _tomatoPasteBox.Hacim;
                puanLabel.Text = puan.ToString();
                pictureBox1.Image = atiklarim[index].Atigim;

            }

        }
        //**********************************************************************************************************************************************


        private void OrganikAtikBosaltButton_Click(object sender, EventArgs e)
        {
            if (_organikAtikKutusu.Bosalt()) // Organik atık kutumuzun boşalt butonuna bastığımızıda eger ki organik atık kutumuzun bosalt fonksiyonu true ise yani doluluk orani 75 ve üstü ise
            {
                organikAtikListBox.Items.Clear(); // listboxımızdaki atıkları temizliyoruz
                _organikAtikKutusu.KutuyuBosalt(); // kutumuzu KutuyuBosalt metdou yardımıyla boşaltıyoruz
                organikAtikProgressBar.Value = 0; // progressBarımızı 0 lıyoruz
                _sure += 3; // mevcut süremize 3 sn daha ekliyoruz
                sureLabel.Text = _sure.ToString(); // yeni süremizi labela yazdırıyoruz
            }
            else // eger ki bosalt metodu true ise Boşaltma butonu çalışmayacaktır
            {
                return; 
            }
        }

        private void KagitAtikBosaltButton_Click(object sender, EventArgs e)
        {
            if (_kagitKutusu.Bosalt()) // Kağıt kutumuzun boşalt butonuna bastığımızıda eger ki kağıt kutumuzun bosalt fonksiyonu true ise yani doluluk orani 75 ve üstü ise
            {
                kagitAtikListBox.Items.Clear();// listboxımızdaki atıkları temizliyoruz
                _kagitKutusu.KutuyuBosalt();// kutumuzu KutuyuBosalt metdou yardımıyla boşaltıyoruz
                kagitAtikProgressBar.Value = 0; // progressBarımızı 0 lıyoruz
                _sure += 3; // mevcut süremize 3 sn daha ekliyoruz
                sureLabel.Text = _sure.ToString();// yeni süremizi labela yazdırıyoruz
                puan += _kagitKutusu.BosaltmaPuani; // kagıt kutumuzu boşalttığımızda mevcut puanımıza kağıt kutusunu boşlatma puanı kadar daha puan ekliyoruz
                puanLabel.Text = puan.ToString(); // yeni puanımızı labela yazdırıyoruz
            }
            else // eger ki bosalt metodu true ise Boşaltma butonu çalışmayacaktır
            {
                return;
            }

        }
        // AYNI İŞLEMLERİ CAM KUTUSUNU BOŞALTTIĞIMIZDA  CAM KUTUSU BOŞALTMA PUANI ve METAL KUTUSUNU BOŞALTTIĞIMIZDA METAL KUTUSU BOŞALTMA PUANI KADAR PUAN KAZANMAK KOŞULU İLE DİĞER BOŞALT BUTONLARIMIZDA DA UYGULUYORUZ
        private void CamAtikBosaltButton_Click(object sender, EventArgs e)
        {
            if (_camKutusu.Bosalt())
            {
                camAtikListBox.Items.Clear();
                _camKutusu.KutuyuBosalt();
                camAtikProgressBar.Value = 0;
                _sure += 3;
                sureLabel.Text = _sure.ToString();
                puan += _camKutusu.BosaltmaPuani;
                puanLabel.Text = puan.ToString();
            }
            else
            {
                return;
            }
        }

        private void MetalAtikBosaltButton_Click(object sender, EventArgs e)
        {
            if (_metalKutusu.Bosalt())
            {
                metalAtikListBox.Items.Clear();
                _metalKutusu.KutuyuBosalt();
                metalAtikProgressBar.Value = 0;
                _sure += 3;
                sureLabel.Text = _sure.ToString();
                puan += _metalKutusu.BosaltmaPuani;
                puanLabel.Text = puan.ToString();
            }
            else
            {
                return;
            }
        }

        private void CikisButton_Click(object sender, EventArgs e) // cıkıs butonuna basınca uygulamamız kapanıyor
        {
            Close();
        }
    }
}
