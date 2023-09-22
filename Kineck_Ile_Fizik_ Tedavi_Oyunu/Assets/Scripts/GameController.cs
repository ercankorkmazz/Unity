using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour
{
    GameObject GameControler_Object;
    ServerDatabase myServerDatabase;
    bitis myBitis;

    public Text angleText; 
    public Text kontrolText;
    public Text hrktText;
    public Text SkorText;
    public Text SeviyeText;
    public Text OrtaSeviyeText;
    public Text hareketAciklamasiText;
    public Text tekrarSayisiText;

    public GameObject DumanEfekti;

    private int index = 0;
    public int satirSayisi = 0;
    private int sonOynatilanHareketSatiri = 0;
    public int hareketTekrarSayisi = 0;
    public int hareketTekrariYardimcisi = 1;
    public float beklemeSuresi = 0;

    public int SkorArttirmaMiktari;
    string sonKaydedilenSeviyeID;
    string aktifSahneID;
    int gelenHastaID;
    public static int Toplam_Goruntulenen_Hareket_Sayisi { get; set; }
    public static int toplamHareketSayisi { get; set; }
    public static int yardimci { get; set; }
    public static int yardimci_2 { get; set; }
    public static int dogruYapinHareketSayisi { get; set; }
    public static int yanlisYapilanHareketSayisi { get; set; }
    public static int Hareket_Uretme_Kontrolu { get; set; }
    public static int Skor { get; set; }
    public static int Canlar { get; set; }

    public GameObject[] Hareket_Resimleri;
    public GameObject HareketSkorlariniKaydedenObje;
    public static int Hareket_1 { get; set; }
    public static int Hareket_2 { get; set; }
    public static int Hareket_3 { get; set; }
    public static int Hareket_4 { get; set; }
    public static int Hareket_5 { get; set; }
    public static string[] seviyeSkorlari { get; set; }
    void Start()
    {
        GameControler_Object = GameObject.Find("GameControler");
        myServerDatabase = GameControler_Object.GetComponent<ServerDatabase>();
        myBitis = GameControler_Object.GetComponent<bitis>();

        Canlar = 5;
        yardimci = 0;
        yardimci_2 = 0;
        Skor = 0;
        SkorText.text = Skor.ToString();
        Hareket_Uretme_Kontrolu = 0;
        Toplam_Goruntulenen_Hareket_Sayisi = 0;
        dogruYapinHareketSayisi = 0;
        yanlisYapilanHareketSayisi = 0;

        oturumBilgisiGetir();
        seviyeBilgileriniGetir();
        SeviyeText.text = aktifSahneID;
        OrtaSeviyeText.text = " " + aktifSahneID;

        toplamHareketSayisi = myServerDatabase.asamayaGoreHareketTekrariSayisiSorgula(gelenHastaID.ToString(), aktifSahneID) + (myServerDatabase.asamayaGoreHarekSayisiSorgula(gelenHastaID.ToString(), aktifSahneID) - 1);
        
        satirSayisi = myServerDatabase.asamayaGoreHarekSayisiSorgula(gelenHastaID.ToString(), aktifSahneID);
        seviyeSkorlari = new string[satirSayisi];

        StartCoroutine(Spawn());
    }
    
    void Update ()
    {
        // Açı ve hareketlerin kontrolü
        hrktText.text = Hareket_Uretme_Kontrolu.ToString();
        angleText.text = HareketKontrolu.Hareket_B.ToString("F1") + " - " + HareketKontrolu.Hareket_C.ToString("F1") + " - " + HareketKontrolu.Hareket_D.ToString("F1") + " - " + HareketKontrolu.Hareket_E.ToString("F1");
        kontrolText.text = Hareket_1 + "-" + Hareket_2 + "-" + Hareket_3 + "-" + Hareket_4 + "-" + Hareket_5;
    }
    
    public void seviyeBilgileriniGetir()
    {
        if (File.Exists("Save/level.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("Save/level.dat", FileMode.Open);
            Level data = (Level)bf.Deserialize(file);
            file.Close();

            sonKaydedilenSeviyeID = data.sonKaydedilenSeviyeID;
            aktifSahneID = data.aktifSahneID;
        }
    }
    public void oturumBilgisiGetir()
    {
        if (File.Exists("Save/oturum.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("Save/oturum.dat", FileMode.Open);
            SessionData data = (SessionData)bf.Deserialize(file);
            file.Close();

            gelenHastaID = Convert.ToInt32(data.hastaID);
        }
    }
    public void oturumKapat()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Save/oturum.dat");

        SessionData data = new SessionData();
        data.oturum = 0;

        bf.Serialize(file, data);
        file.Close();
    }

    IEnumerator Spawn() 
    {
        do
        {
            yield return new WaitForSeconds(3.4f);

            if (Toplam_Goruntulenen_Hareket_Sayisi > toplamHareketSayisi)
            {
                Hareket_Uretme_Kontrolu = 1;
                
                int hedeflenenSkor = myServerDatabase.asamayaGoreHareketTekrariSayisiSorgula(gelenHastaID.ToString(), aktifSahneID);
                hedeflenenSkor = hedeflenenSkor * 10;

                if (Skor == hedeflenenSkor)
                    myBitis.SeviyeGetir();
                else
                {
                    // Tüm hareket tekrarları tamamlanmasına rağmen skora ulaşılamamışsa kaybettin panelini getirir.
                    myBitis.KaybettinPaneli.SetActive(true);
                }
            }
            else
            {
                if (Hareket_Uretme_Kontrolu == 0)
                {
                    if (yardimci_2 <= yardimci)
                        Toplam_Goruntulenen_Hareket_Sayisi++;

                    yardimci_2++;

                    oturumBilgisiGetir();
                    seviyeBilgileriniGetir();
                    satirSayisi = myServerDatabase.asamayaGoreHarekSayisiSorgula(gelenHastaID.ToString(), aktifSahneID);

                    string[,] gelenHareketListesi = new string[satirSayisi, 7];

                    gelenHareketListesi = myServerDatabase.asamayaGoreHareketSorgula(gelenHastaID.ToString(), aktifSahneID);

                    index = Convert.ToInt32(gelenHareketListesi[sonOynatilanHareketSatiri, 3]);
                    beklemeSuresi = Convert.ToInt32(gelenHareketListesi[sonOynatilanHareketSatiri, 4]);
                    hareketTekrarSayisi = Convert.ToInt32(gelenHareketListesi[sonOynatilanHareketSatiri, 5]);
                    hareketAciklamasiText.text = gelenHareketListesi[sonOynatilanHareketSatiri, 6].ToString();
                    tekrarSayisiText.text = gelenHareketListesi[sonOynatilanHareketSatiri, 5];

                    yardimci = hareketTekrarSayisi + 1;

                    //Debug.Log(yardimci_2 + " - " + yardimci + " - " + sonOynatilanHareketSatiri);
                    
                    if (yardimci_2 == yardimci)
                    {
                        yardimci_2 = 0;
                        
                        Vector3 spawnPosition = new Vector3(0, 3.8f, 2);
                        Instantiate(HareketSkorlariniKaydedenObje, spawnPosition, Quaternion.identity);


                        //Debug.Log("Son oynatilan:" + sonOynatilanHareketSatiri + " Dogru:" + dogruYapinHareketSayisi + " Yanlis:" + yanlisYapilanHareketSayisi);
                        
                        string hareketAdi = myServerDatabase.hareketAdiSordula(gelenHareketListesi[sonOynatilanHareketSatiri, 3]);

                        string skorBilgisi = "<strong>Hareket Adı:</strong> " + hareketAdi + "<br><strong>Doğru Yapılan Tekrar Sayısı:</strong> " + dogruYapinHareketSayisi + "<br><strong>Yanlış Yapılan Tekrar Sayısı:</strong> " + yanlisYapilanHareketSayisi;

                        ServerDatabase.Instance.skoruKaydet(gelenHastaID, Convert.ToInt32(aktifSahneID), skorBilgisi);
                        

                        if (sonOynatilanHareketSatiri < satirSayisi - 1)
                        {
                            sonOynatilanHareketSatiri++;
                            hareketTekrariYardimcisi = 1;
                            dogruYapinHareketSayisi = 0;
                            yanlisYapilanHareketSayisi = 0;
                        }

                        //Debug.Log("Son oynatilan:" + sonOynatilanHareketSatiri + " Toplam satir:" + (satirSayisi-1));

                    }
                    else
                    {
                        if (Toplam_Goruntulenen_Hareket_Sayisi <= toplamHareketSayisi)
                        {
                            hareketTekrariYardimcisi++;

                            Vector3 spawnPosition = new Vector3(0, -1.74f, 2);
                            Instantiate(Hareket_Resimleri[index], spawnPosition, Quaternion.identity);
                            Instantiate(DumanEfekti, spawnPosition, Quaternion.identity); // Duman efekti üretilecek
                        }
                    }

                    Hareket_Uretme_Kontrolu = 1;
                }
            }
        }
        while (Canlar > 0);    
    }
}