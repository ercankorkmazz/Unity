using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class level : MonoBehaviour {

	public GameObject []seviyeler;

    int oturum;
    int gelenKullaniciID;
    int gelenHastaID;

    string sonKaydedilenSeviyeID;
    int aktifSahneID;
    public void Start()
    {
        asamaKontroluYap();
        if (oturum == 1)
            menuListele();
    }
    public void Update()
    {
        asamaKontroluYap();
    }
    public void asamaKontroluYap()
    {
        oturumBilgisiGetir();
        hastalar hastaBilgileri = ServerDatabase.Instance.hastaSorgula(gelenHastaID);

        if (hastaBilgileri.asamaKontrolu == 1)
        {
            sahneleriSifirla();
            menuListele();
            ServerDatabase.Instance.asamaKontroluSifirla(gelenHastaID);
        }        
    }

    public void menuListele()
    {
        seviyeBilgileriniGetir();
        oturumBilgisiGetir();

        hastalar hasta = ServerDatabase.Instance.hastaSorgula(gelenHastaID);
        
        for (int i = 0; i < 6; i++)
        {
            if (i <= Convert.ToInt32(hasta.asamaSayisi) - 1)
                seviyeler[i].SetActive(true);
            else
                seviyeler[i].SetActive(false);
        }

        for (int i = 0; i < seviyeler.Length; i++)
        {
            seviyeler[i].GetComponent<Button>().interactable = false;
            seviyeler[i].GetComponentInChildren<Text>().text = "";
        }
        seviyeBilgileriniGetir();
        int aktifSonSevise = Convert.ToInt32(sonKaydedilenSeviyeID);
        for (int i = 0; i < aktifSonSevise; i++)
        {
            seviyeler[i].GetComponent<Button>().interactable = true;
            seviyeler[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
        }
    }
    public void aktifSahneKaydet(int gelenAktifSeviyeID)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Save/level.dat");

        Level data = new Level();
        data.sonKaydedilenSeviyeID = sonKaydedilenSeviyeID;
        data.aktifSahneID = gelenAktifSeviyeID.ToString();

        bf.Serialize(file, data);
        file.Close();
    }
    public void sahneleriSifirla()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Save/level.dat");

        Level data = new Level();
        data.sonKaydedilenSeviyeID = "1";
        data.aktifSahneID = "1";

        bf.Serialize(file, data);
        file.Close();
    }
    public void seviyeBilgileriniGetir()
	{
		if(File.Exists("Save/level.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open("Save/level.dat", FileMode.Open);
			Level data = (Level)bf.Deserialize(file);
			file.Close();

            sonKaydedilenSeviyeID = data.sonKaydedilenSeviyeID;
            aktifSahneID = Convert.ToInt32(data.aktifSahneID);
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

            oturum = Convert.ToInt32(data.oturum);
            gelenKullaniciID = Convert.ToInt32(data.kullaniciID);
            gelenHastaID = Convert.ToInt32(data.hastaID);
        }
    }
}
[Serializable]
class Level
{
    public string sonKaydedilenSeviyeID;
    public string aktifSahneID;
    public int Can { get; internal set; }
}

