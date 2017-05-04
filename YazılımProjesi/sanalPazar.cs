using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazýlýmProjesi{
public class sanalPazar {

    private Stringim stringim;

    private string sanalPazarAdresi;
    private List<string> urunFiyatBirlikte = new List<string>();
    private List<string> yazici = new List<string>();
    private List<string> fiyat = new List<string>();
    private HtmlNodeCollection cekilecekTag1;
    private HtmlNode urunResimleri;
    private string aranacakUrun;
    private string donenAdres;
    private string donenUrunAdi;
    private string donenUrunResimAdresi;
    private string donenUrunFiyati;
    private HtmlAgilityPack.HtmlDocument document;
    private string html;
    private string siteLogo;
    private HtmlNode urunAdDugumu;
    private System.Net.WebClient client;
    private Uri url;
    private HtmlNodeCollection ucreti;
    private List<string> urunler;
    private string siteAdi;
    private string urunTagi;
    private string aranacakUrunResimTagi;

    public sanalPazar() {
        stringim = new Stringim();
        sanalPazarAdresi = "";
        document = new HtmlAgilityPack.HtmlDocument();
        client = new WebClient();
        urunler = new List<string>();
        siteAdi = "SANALPAZAR";
        urunTagi = "//img[@itemprop='image']";
        siteLogo = "http://www.sanalpazar.com/images/yeni_yil/logo.png?v=1";
    }
    public string getSiteAdi() {
        return siteAdi;
    }

    public string getUrunLinki()
    {

        HtmlNode node = document.DocumentNode.SelectNodes("//a[@class='sp-font-14-b-black']").First();
        donenAdres= node.Attributes["href"].Value.ToString();



        return donenAdres;
    }
    public void stringiDocumenteYukle() {
        document.LoadHtml(html);
    }
    public string subSil(string _text) {
        string a = "<sup>";
        string b = "</sup>";
        _text = _text.Replace(a, "");
        _text = _text.Replace(b, "");
        return _text;
    }
    public void urlyiStringeAt() {
        html = client.DownloadString(url);
    }
    public void urunleriAl() {
        cekilecekTag1 = document.DocumentNode.SelectNodes("//a[@class='sp-font-14-b-black']");
    }
    public void ucretleriAl() {
        ucreti = document.DocumentNode.SelectNodes("//span[@itemprop='price']");        
    }
    public void setAdress(string text) {
        sanalPazarAdresi = "http://www.sanalpazar.com/urunara?criteria=" + text;
        url = new Uri(sanalPazarAdresi);
    }
    public string getAdress() {
        return sanalPazarAdresi;
    }
    public void urunleriUrunlistesineAt() {
        foreach (var baslik in cekilecekTag1) {
            urunler.Add(baslik.InnerText);
        }
        donenUrunAdi = urunler[0];
    }
    public void ucretleriFiyatListesineAt() {
        foreach (var itemParasi in ucreti) {
            fiyat.Add(subSil(itemParasi.InnerHtml));
        }
        donenUrunFiyati = fiyat[0];
        donenUrunFiyati = stringim.virguldenSonraKirp(donenUrunFiyati);
    }
    public void urunleriVeFiyatlariniBirlestir() {
        for (int i = 0; i < urunler.Count; i++) {

            urunFiyatBirlikte.Add(urunler[i] + " --> " + fiyat[i]);
        }
    }
    public void urunResminiAl() {

        urunAdDugumu = document.DocumentNode.SelectNodes(urunTagi).First();
        donenUrunResimAdresi = urunAdDugumu.Attributes["src"].Value.ToString(); //urun adini setle



    }
    public string urunAramaAdresiSetGet {
        get { return donenUrunAdi; }
        set { donenUrunAdi = value; }
    }
    public string aranacakUrunSetGet {
        get { return aranacakUrun; }
        set { aranacakUrun = value; }
    }
    public string donenUrunFiyatiSetGet {
        get { return donenUrunFiyati; }
        set { donenUrunFiyati = value; }
    }
    public string donenUrunResimAdresiSetGet {
        get { return donenUrunResimAdresi; }
        set { donenUrunResimAdresi = value; }
    }
    public string siteAdiSetGet {
        get { return siteAdi; }
        set { siteAdi = value; }
    }
    public string siteLogoSetGet {
        get { return siteLogo; }
        set { siteLogo = value; }
    }

    public string getUrunAdi()
    {
        return donenUrunAdi;
    }

    public Task asenkronArama()
    {
        return Task.Factory.StartNew(() =>
        {
            sanalPazarSitesiUzerindeAramaYap();
        });
    }

    public List<string> sanalPazarSitesiUzerindeAramaYap() {

        setAdress(aranacakUrun);

        urlyiStringeAt();

        stringiDocumenteYukle();

        urunleriAl();

        ucretleriAl();

        urunleriUrunlistesineAt();

        ucretleriFiyatListesineAt();

        urunleriVeFiyatlariniBirlestir();

        urunResminiAl();
        return urunFiyatBirlikte;

    }
}

}