using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;


namespace YazılımProjesi {
    public class Hepsiburada {
        private Stringim stringim;  // string islemlerini yapacak nesne
        private string siteAdi = "HEPSIBURADA";
        private string siteLogo = "http://images.hepsiburada.net/assets/hepsiburada-logo.png";
        private string urunAramaAdresi = "http://www.hepsiburada.com/ara?q=";
        private string aranacakUrun = "";
        private string donenUrunAdi = "";
        private string donenUrunFiyati = "";
        private string donenUrunResimAdresi = "";
        private string donenUrunLinki = "";

        private HtmlWeb htmlWeb = new HtmlWeb();  // arama yaparken kullanılacak tarayıcı degiskeni
        private HtmlDocument htmlDocument = new HtmlDocument();  // siteden donen html kodlarının tutulacagı degisken


        public Hepsiburada() {  //parametresiz yapici
            stringim = new Stringim();
        }

        public Hepsiburada(string aranacakUrun) {  // parametreli yapici
            this.aranacakUrun = aranacakUrun;
            stringim = new Stringim();
        }


        public Task asenkronArama() {   // form kilitlenmesine karsin asenkron sekilde arama yapan fonksiyon
            return Task.Factory.StartNew(() => {
                ara();
                sonucAyikla();
            });
        }


        public void ara() {  // arama yapan fonksiyon
            aranacakUrun = stringim.boslukKarakteriniArtiYap(aranacakUrun);  // Orn: "iphone 5s" --> "iphone+5s"
            urunAramaAdresi = stringim.stringBirlestir(urunAramaAdresi, aranacakUrun);  // "http://www.hepsiburada.com/ara?q=" + "iphone+5s"
            htmlDocument = htmlWeb.Load(urunAramaAdresi); // html kodlarını dokuman degiskene aktar
        }

        public void sonucAyikla() {   // tek tek string olarak ayıkla
            HtmlNode urunAdDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='box product no-hover']//img[@class='product-image']").First();
            HtmlNode urunFiyatDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='box product no-hover']//span[@class='price product-price']").First();
            HtmlNode urunResimDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='box product no-hover']//img[@class='product-image']").First();
            HtmlNode urunLinkDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='box product no-hover']//a").First();

            donenUrunAdi = urunAdDugumu.Attributes["alt"].Value.ToString();  // arama sonucu donen urun adı
            donenUrunAdi = stringim.hepsiBuradaKarakterSorunuDuzelt(donenUrunAdi); // arama sonucu donen urun ismindeki Turkce karakter sorunu duzelt

            donenUrunFiyati = urunFiyatDugumu.InnerHtml.ToString();       // arama sonucu donen urun fiyati
            donenUrunFiyati = stringim.virguldenSonraKirp(donenUrunFiyati);


            donenUrunResimAdresi = "http:" + urunResimDugumu.Attributes["src"].Value.ToString(); // arama sonucu donen urun resim linki
            donenUrunLinki = "http://www.hepsiburada.com" + urunLinkDugumu.Attributes["href"].Value.ToString(); // arama sonucu donen urun linki


        }

        public string urunAramaAdresiSetGet {   // set get fonksiyonlari
            get { return urunAramaAdresi; }
            set { urunAramaAdresi = value; }
        }

        public string aranacakUrunSetGet {
            get { return aranacakUrun; }
            set { aranacakUrun = value; }
        }

        public string donenUrunAdiSetGet {
            get { return donenUrunAdi; }
            set { donenUrunAdi = value; }
        }

        public string donenUrunFiyatiSetGet {
            get { return donenUrunFiyati; }
            set { donenUrunFiyati = value; }
        }

        public string donenUrunResimAdresiSetGet {
            get { return donenUrunResimAdresi; }
            set { donenUrunResimAdresi = value; }
        }

        public string donenUrunLinkAdresiSetGet {
            get { return donenUrunLinki; }
            set { donenUrunLinki = value; }
        }

        public string siteAdiSetGet {
            get { return siteAdi; }
            set { siteAdi = value; }
        }

        public string siteLogoSetGet {
            get { return siteLogo; }
            set { siteLogo = value; }
        }
    }
}
