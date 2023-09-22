using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class gameLang : MonoBehaviour {

    GameObject GameControler_Object;
    bitis myBitis;

    private string SkorDegeri;

    public GameObject enbuton;
    public GameObject trbuton;
    public GameObject seviyeYazi;
    public GameObject TekrarYazi;
    public GameObject kaybettinYazi;
    public GameObject kazandınYazi;
    public GameObject kaybettinYenidenYukleBTNYazi;
    public GameObject kazandınYenidenYukleBTNYazi;
    public GameObject aciklamaBaslik;
    public GameObject Hedef_Ust_Bilgi;
    public GameObject Hedef_Orta_Bilgi;
    public GameObject Hedef_Alt_Bilgi;
    public GameObject SeviyeBilgi;
    public GameObject Kaydediliyor;

    public GameObject pause;
    public GameObject restart;
    public GameObject logout;

    public GameObject setting;
    public GameObject setText;
    public GameObject langText;

    public GameObject mainMenu;
    public GameObject mainText;
    public GameObject mainAns;
    public GameObject yes;
    public GameObject no;
    public GameObject txtImg;

    string lang;
    string aktifSahneID;
	public void Update() 
	{
        SkorDegeri = bitis.seviyeSkoru.ToString();

        Load ();
		string dil = lang;
		if(dil.Equals("en"))
		{
			en ();
		}
		else if(dil.Equals("tr"))
		{
			tr ();
		}
	}

    public void en()
    {
        lang = "en";

        enbuton.GetComponent<Button>().interactable = false;
        trbuton.GetComponent<Button>().interactable = true;
        seviyeYazi.GetComponent<Text>().text = "LEVEL";
        TekrarYazi.GetComponent<Text>().text = "REPEAT";
        kaybettinYazi.GetComponent<Text>().text = "GAME OVER";
        kaybettinYenidenYukleBTNYazi.GetComponent<Text>().text = "RESTART";
        kazandınYazi.GetComponent<Text>().text = "CONGRATULATIONS! ALL LEVELS COMPLETED";
        aciklamaBaslik.GetComponent<Text>().text = "DESCRIPTIONS";
        kazandınYenidenYukleBTNYazi.GetComponent<Text>().text = "MAIN MENU";
        pause.GetComponentInChildren<Text>().text = "PAUSE";
        restart.GetComponentInChildren<Text>().text = "RESTART";
        logout.GetComponentInChildren<Text>().text = "LOGOUT";
        Kaydediliyor.GetComponentInChildren<Text>().text = "SCORE SAVING PLEASE WAIT";


        Hedef_Ust_Bilgi.GetComponent<Text>().text = "TARGET";
        Hedef_Orta_Bilgi.GetComponent<Text>().text = SkorDegeri;
        Hedef_Alt_Bilgi.GetComponent<Text>().text = "STAR";
        SeviyeBilgi.GetComponent<Text>().text = "TARGET " + SkorDegeri + " STAR";

        setting.GetComponentInChildren<Text>().text = "SETTINGS";
        setText.GetComponentInChildren<Text>().text = "SETTINGS";
        langText.GetComponentInChildren<Text>().text = "LANGUAGE";

        mainMenu.GetComponentInChildren<Text>().text = "MAIN MENU";
        mainMenu.GetComponentInChildren<Text>().text = "MAIN MENU";
        mainAns.GetComponentInChildren<Text>().text = "ARE YOU SURE YOU WANT MAIN MENU?";
        yes.GetComponentInChildren<Text>().text = "YES";
        no.GetComponentInChildren<Text>().text = "NO";
        txtImg.GetComponentInChildren<Text>().text = "MAIN MENU";//sonradan eklendi
        
        Save();
    }

    public void tr()
    {
        lang = "tr";
        enbuton.GetComponent<Button>().interactable = true;
        trbuton.GetComponent<Button>().interactable = false;
        seviyeYazi.GetComponent<Text>().text = "SEVIYE";
        TekrarYazi.GetComponent<Text>().text = "TEKRAR";
        kaybettinYazi.GetComponent<Text>().text = "OYUN BITTI";
        kaybettinYenidenYukleBTNYazi.GetComponent<Text>().text = "TEKRAR OYNA";
        kazandınYazi.GetComponent<Text>().text = "TEBRIKLER! TÜM SEVIYELERI BASARIYLA TAMAMLADINIZ";
        aciklamaBaslik.GetComponent<Text>().text = "AÇIKLAMALAR";
        kazandınYenidenYukleBTNYazi.GetComponent<Text>().text = "ANA MENU";
        pause.GetComponentInChildren<Text>().text = "DURAKLAT";
        restart.GetComponentInChildren<Text>().text = "TEKRAR";
        logout.GetComponentInChildren<Text>().text = "OTURUMU KAPAT";
        Kaydediliyor.GetComponentInChildren<Text>().text = "SKOR KAYDEDILIYOR LÜTFEN BEKLEYINIZ";

        Hedef_Ust_Bilgi.GetComponent<Text>().text = "HEDEF";
        Hedef_Orta_Bilgi.GetComponent<Text>().text = SkorDegeri;
        Hedef_Alt_Bilgi.GetComponent<Text>().text = "YILDIZ";
        SeviyeBilgi.GetComponent<Text>().text = "HEDEF " + SkorDegeri + " YILDIZ";

        setting.GetComponentInChildren<Text>().text = "AYARLAR";
        setText.GetComponentInChildren<Text>().text = "AYARLAR";
        langText.GetComponentInChildren<Text>().text = "DIL";

        mainMenu.GetComponentInChildren<Text>().text = "ANAMENU";
        mainMenu.GetComponentInChildren<Text>().text = "ANAMENU";
        mainAns.GetComponentInChildren<Text>().text = "ANAMENUYE DONMEYE EMIN MISIN?";
        yes.GetComponentInChildren<Text>().text = "EVET";
        no.GetComponentInChildren<Text>().text = "HAYIR";
        txtImg.GetComponentInChildren<Text>().text = "ANA MENÜ";//sonradan eklendi

        Save();
    }

    public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create("Save/language.dat");

		Langu data = new Langu();
		data.lang = lang;

		bf.Serialize(file, data);
		file.Close();
	}
	public void Load()
	{
		if(File.Exists("Save/language.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open("Save/language.dat", FileMode.Open);
			Langu data = (Langu)bf.Deserialize(file);
			file.Close();

			lang = data.lang;
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
            
            aktifSahneID = data.aktifSahneID;
        }
    }
}