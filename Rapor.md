**Proje ad�** 			 :     En ucuzu bul
  
**Proje Geli�tiricileri** : Ahmet �lgin   : 279967  |
                                 Aykut Ar�c�o�lu : 279998 |
  							     Aykut Durucan  : 279988 |
  							     �lker Yasin Aksoy  : 279975
  
  **Proje konusu:**
  
  Projemiz sat�n al�nacak �r�nlerin ucuzunu bulmak ve m��terinin site site gezmesine ��z�m olmas� i�in tasarlanm��t�r. Projede, en pop�ler al��veri� 
siteleri oldu�undan; Hepsiburada, Sanalpazar, N11 sitelerinin kullan�lmas� kararla�t�r�ld�. Bahsedilen web siteleri incelendi;
k�t�phanelerinin html parse yetene�i ve grafiksel aray�z yetene�i g�z �n�ne al�narak C# dili tercih edildi. Projeye uygunlu�u sebebi ile nesne 
y�nelimli programlama mimarisi kullan�ld�. Daha iyi bir aray�z g�r�n�m� i�in metro framework kullan�ld�. Form tepkisizli�i sorununa  kar��n thread 
kullanma karar� al�nd�. HtmlAgilityPack, Fizzler, AngleSharp haz�r .NET k�t�phaneleri incelenerek, HtmlAgilityPack k�t�phanesinin kullan�lmas� kararla�t�r�ld�.

![picture](img/girisekrani.png)

Program �al��t�r�ld���nda bizi ho� bir ekran kar��l�yor. Kullan�c� dostu bir tasar�m olup, kullan�c�n�n sadece arama yapaca�� kelime girmesi yeterli oluyor. 
Ara buttonuna t�kland���nda belirtilen siteler �zerinde asenkron olarak arama yap�l�p liste bi�iminde, �r�nler fiyata g�re s�ral� (bubble sort algoritmas�) gelerek kar��m�za ��kar�yor.
Listeden eleman se�ti�imizde �r�n resmi ve fiyat� sol tarafta kar��m�za ��k�yor. �r�ne git dedi�imizde �r�n�n bulundu�u linke gidiyor. 

![picture](img/aramayapildi.png)

Projemizi bitbucket ortam�nda git versiyon kontrol sistemini kullanarak ger�ekle�tirdik. Tak�m �al��mas�n�n nas�l olmas� gerekti�i bir proje �zerinde nas�l toplu
�al���laca�� hakk�nda fikir sahibi olduk. 

![picture](img/branchTree.png)