/****************************************************************************
**					      SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				      BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				     NESNEYE DAYALI PROGRAMLAMA DERSİ
**					      2021-2022 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 01
**				ÖĞRENCİ ADI............: Mehmet Asım ÖZLEN
**				ÖĞRENCİ NUMARASI.......: G211210300
**              DERSİN ALINDIĞI GRUP...: 2A  Grubu 
****************************************************************************/
using System;
using System.IO;

namespace G211210300
{
    public class SifreKontrol                                   // Metotların yer aldığı şifre kontrol sınıfı oluşturulmuştur. 
    {
       
        public static int BuyukHarfSayaci(string sifre, int buyukHarfSayisi, int buyukHarfPuani)
        {
            for (int i = 0; i < sifre.Length; i++)
            {
                char ch = sifre[i];
                if (ch >= 'A' && ch <= 'Z')
                    buyukHarfSayisi++;
            }
            Console.WriteLine("Büyük harf sayısı:  " + buyukHarfSayisi);
            
            if (buyukHarfSayisi == 0)
                buyukHarfPuani = 0;
            else if (buyukHarfSayisi == 1)
            {
                buyukHarfPuani = 10;
            }
            else
            {
                buyukHarfPuani = 20;
            }
            return buyukHarfPuani;
        }

        // buyukHarfPuani değerini döndüren statik sınıf oluşturulmuştur. Kullanıcı tarafından girilen şifre parametresini alır. Büyük harfler için verilen puan BuyukHarfSayaci metodu içerisinde hesaplanmaktadır. 

        public static int KucukHarfSayaci(string sifre, int kucukHarfSayisi, int kucukHarfPuani)
        {
            for (int i = 0; i < sifre.Length; i++)
            {
                char ch = sifre[i];
                if (ch >= 'a' && ch <= 'z')
                    kucukHarfSayisi++;
            }
            Console.WriteLine("Küçük harf sayısı:  " + kucukHarfSayisi);

            if (kucukHarfSayisi == 0)
                kucukHarfPuani = 0;
            else if (kucukHarfSayisi == 1)
            {
                kucukHarfPuani = 10;
            }
            else
            {
                kucukHarfPuani = 20;
            }
            return kucukHarfPuani;
        }

        // kucukHarfPuani değerini döndüren statik sınıf oluşturulmuştur. Kullanıcı tarafından girilen şifre parametresini alır. Küçük harfler için verilen puan KucukHarfSayaci metodu içerisinde hesaplanmaktadır. 


        public static int RakamSayaci(string sifre, int rakamSayisi, int rakamPuani)
        {
            for (int i = 0; i < sifre.Length; i++)
            {
                char ch = sifre[i];
                if (ch >= '0' && ch <= '9')
                    rakamSayisi++;
            }
            Console.WriteLine("Rakam sayısı:       " + rakamSayisi);
            
            if (rakamSayisi == 0)
                rakamPuani = 0;
            else if (rakamSayisi == 1)
            {
                rakamPuani = 10;    
            }
            else
            {
                rakamPuani = 20;
            }
            return rakamPuani; 
        }

        // rakamPuani değerini döndüren statik sınıf oluşturulmuştur. Kullanıcı tarafından girilen şifre parametresini alır. Rakamlar için verilen puan RakamSayaci metodu içerisinde hesaplanmaktadır. 

        public static int SembolSayaci(string sifre, int sembolSayisi, int sembolPuani)
        {
            for (int i = 0; i < sifre.Length; i++)
            {
                char ch = sifre[i];
                if (ch >= 'A' && ch <= 'Z')
                    continue;
                else if (ch >= 'a' && ch <= 'z')
                    continue;
                else if (ch >= '0' && ch <= '9')
                    continue;
                else
                    sembolSayisi++;
            }
            Console.WriteLine("Sembol sayısı:      " + sembolSayisi);

            if (sembolSayisi == 1)
                sembolPuani = 10;
            else 
            {
                sembolPuani = 10*sembolSayisi;
            }
            return sembolPuani;
        }

        // sembolPuani değerini döndüren statik sınıf oluşturulmuştur. Kullanıcı tarafından girilen şifre parametresini alır. Türkçe karakterler sembol olarak değerlendirilmektedir.
        // Semboller için verilen puan SembolSayaci metodu içerisinde hesaplanmaktadır. 


        public static void Main()
        {
            string sifre = "";
            int buyukHarfSayisi = 0, kucukHarfSayisi = 0;
            int rakamSayisi = 0, sembolSayisi = 0;
            int buyukHarfPuani = 0, kucukHarfPuani = 0;
            int rakamPuani = 0, sembolPuani = 0;
            int toplamPuan = buyukHarfPuani + kucukHarfPuani + rakamPuani + sembolPuani;

            while (true)
            {
                Console.Write("Lütfen kontrol için şifrenizi giriniz: ");
                sifre = (Console.ReadLine());

                char boslukKarakteri = ' ';
                int bosluk = sifre.Where(x => (x == boslukKarakteri)).Count();

                if (bosluk > 0)                         // Şifre içinde boşluk karakteri olması kabul edilmemektedir. Bu kontrol bosluk değişkeni vasıtasıyla yapılır.
                {
                    Console.WriteLine("Şifre boşluk karakteri içeremez!");

                }
                else if (sifre.Length < 9)              // Şifre uzunluğu en az 9 karakter olmalıdır. Şifre uzunluğu kontrol edilerek kullanıcıya geri bildirimde bulunulur.
                {
                    Console.WriteLine("Şifre en az 9 karakter uzunluğunda olmalıdır!");
                }
                else
                {
                    buyukHarfPuani = BuyukHarfSayaci(sifre, buyukHarfSayisi, buyukHarfPuani);
                    kucukHarfPuani = KucukHarfSayaci(sifre, kucukHarfSayisi, kucukHarfPuani);
                    rakamPuani = RakamSayaci(sifre, rakamSayisi, rakamPuani);
                    sembolPuani = SembolSayaci(sifre, sembolSayisi, sembolPuani);

                    toplamPuan = buyukHarfPuani + kucukHarfPuani + rakamPuani + sembolPuani;
                    
                    if (buyukHarfPuani == 0 || kucukHarfPuani == 0 || rakamPuani == 0 || sembolPuani == 0)      // Büyük harf, küçük harf, rakam ve sembol karakterlerinin herbirinin en az 1 adet olma koşulu kontrol edilir.
                        Console.WriteLine("Geçersiz şifre. Şifre en az birer adet büyük harf, küçük harf, rakam ve sembol içermelidir!");
                    else
                    {
                        if (toplamPuan >= 100)                   // toplamPuan parametresi 100 ve üzerinde bir değere sahipse kullanıcıya 100 puan değeri gösterilir. 
                            Console.WriteLine("Güçlü şifre. Toplam puan: 100");
                        else if (toplamPuan >= 90)              // toplamPuan parametresi 90 ve üzerinde bir değere sahipse kullanıcıya güçlü şifre ve puan değeri gösterilir. 
                        {
                            Console.WriteLine("Güçlü şifre. Toplam puan: " + toplamPuan); 
                        }
                        else if (toplamPuan >= 70)              // toplamPuan parametresi 70 ve üzerinde bir değere sahipse kullanıcıya  puan değeri gösterilir. 
                        {
                            Console.WriteLine("Şifre kabul edildi. Toplam puan: " + toplamPuan);
                        }
                        else                                    // toplamPuan parametresi 70 değerinden küçükse şifre kabul edilmedi uyarısı ekrana yazdırılır.
                        {
                            Console.WriteLine("Şifre kabul edilmedi, lütfen daha güçlü bir şifre giriniz.");
                        }
                    }
                }
            }
        }
    }
}