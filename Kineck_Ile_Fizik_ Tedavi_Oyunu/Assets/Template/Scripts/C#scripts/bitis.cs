using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class bitis : MonoBehaviour {

    GameObject GameControler_Object;
    ServerDatabase myServerDatabase;
    GameController myGameController;

    string sonKaydedilenSeviyeID;
    string aktifSahneID;

    public GameObject KazandınPaneli;
    public GameObject KaybettinPaneli;
    public static int seviyeSkoru { get; set; }

    int toplamHareketSayisi;
    int gelenHastaID;
    string para;

    void Start()
    {
        para = "0";
        KazandınPaneli.SetActive(false);
        KaybettinPaneli.SetActive(false);

        GameControler_Object = GameObject.Find("GameControler");
        myServerDatabase = GameControler_Object.GetComponent<ServerDatabase>();
        myGameController = GameControler_Object.GetComponent<GameController>();

        seviyeBilgileriniGetir();
        oturumBilgisiGetir();
        toplamHareketSayisi = myServerDatabase.asamayaGoreHareketTekrariSayisiSorgula(gelenHastaID.ToString(), aktifSahneID);
        seviyeSkoru = toplamHareketSayisi * 10;
    }

    void Update()
	{
        seviyeBilgileriniGetir();
        
        if (GameController.Skor == seviyeSkoru)
        {
            if(GameController.yardimci_2 == GameController.yardimci)
            {
                GameController.Hareket_Uretme_Kontrolu = 1;
                SeviyeGetir();
                //InvokeRepeating("SeviyeGetir", 0, 0); // 2 saniye sonra tekrarsız bir kere fonksüyon çağırır.
            }
        }
        else if (GameController.Canlar < 1)
        {
            KaybettinPaneli.SetActive(true);
        }
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
    public void skorBilgileriniKaydet()
    {
        //Debug.Log(GameController.seviyeSkorlari[0]);
        //ServerDatabase.Instance.skoruKaydet(gelenHastaID, Convert.ToInt32(aktifSahneID), GameController.seviyeSkorlari[0]);
        //ServerDatabase.Instance.skoruKaydet(gelenHastaID, Convert.ToInt32(aktifSahneID), "sfdghfjgj");
    }
    public void seviyeBilgileriniKaydet()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create("Save/level.dat");

		Level data = new Level();
        if (Convert.ToInt32(aktifSahneID) == Convert.ToInt32(sonKaydedilenSeviyeID))
            data.sonKaydedilenSeviyeID = (Convert.ToInt32(aktifSahneID) + 1).ToString();
        else
            data.sonKaydedilenSeviyeID = sonKaydedilenSeviyeID;

        data.aktifSahneID = (Convert.ToInt32(aktifSahneID) + 1).ToString();

        bf.Serialize(file, data);
		file.Close();
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
    public void SeviyeGetir()
    {
        seviyeBilgileriniGetir();
        oturumBilgisiGetir();
        hastalar hastaBilgileri = ServerDatabase.Instance.hastaSorgula(gelenHastaID);

        //skorBilgileriniKaydet();

        if (Convert.ToInt32(aktifSahneID) == Convert.ToInt32(hastaBilgileri.asamaSayisi))
        {
            KazandınPaneli.SetActive(true);
        }
        else
        {
            seviyeBilgileriniKaydet();
            Application.LoadLevel(1);
        }
    }
   public void AnaMenu()
   {
        Application.LoadLevel(0);
   }
}
