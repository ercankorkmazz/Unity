using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class language : MonoBehaviour {

	public GameObject enbuton;
	public GameObject trbuton;

    public GameObject play;
    public GameObject lvlselect;
    public GameObject loginTitle;
    public GameObject loginBTNText;
    public GameObject mainMenuText;

	public GameObject setting;
	public GameObject setText;
	public GameObject langText;
	public GameObject resetText;
	public GameObject resetAns;
	public GameObject r_yes;
	public GameObject r_no;
    public GameObject kadi;
    public GameObject sifre;
    public GameObject loginustbaslik;

    public GameObject quit;
	public GameObject quitText;
	public GameObject quitAns;
	public GameObject yes;
	public GameObject no;

	string lang;
	public void Update() 
	{
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
        play.GetComponentInChildren<Text>().text = "PLAY";
        lvlselect.GetComponentInChildren<Text>().text = "LEVELS";
        loginTitle.GetComponentInChildren<Text>().text = "LOGIN";
        loginBTNText.GetComponentInChildren<Text>().text = "LOGIN";
        mainMenuText.GetComponentInChildren<Text>().text = "MAIN MENU";

		setting.GetComponentInChildren<Text>().text = "SETTINGS";
		setText.GetComponentInChildren<Text>().text = "SETTINGS";
		langText.GetComponentInChildren<Text>().text = "LANGUAGE";
		resetText.GetComponentInChildren<Text>().text = "RESET";
		resetAns.GetComponentInChildren<Text>().text = "ARE YOU SURE YOU WANT RESET?";
		r_yes.GetComponentInChildren<Text>().text = "YES";
		r_no.GetComponentInChildren<Text>().text = "NO";
        kadi.GetComponentInChildren<Text>().text = "USER NAME";
        sifre.GetComponentInChildren<Text>().text = "PASSWORD";
        loginustbaslik.GetComponentInChildren<Text>().text = "LOGIN";

        quit.GetComponentInChildren<Text>().text = "QUIT";
		quitText.GetComponentInChildren<Text>().text = "QUIT";
		quitAns.GetComponentInChildren<Text>().text = "ARE YOU SURE YOU WANT QUIT?";
		yes.GetComponentInChildren<Text>().text = "YES";
		no.GetComponentInChildren<Text>().text = "NO";
		Save ();
	}

	public void tr() 
	{
		lang = "tr";
		enbuton.GetComponent<Button>().interactable = true;
		trbuton.GetComponent<Button>().interactable = false;
		play.GetComponentInChildren<Text>().text = "OYNA";
        lvlselect.GetComponentInChildren<Text>().text = "SEVIYELER";
        loginTitle.GetComponentInChildren<Text>().text = "GIRIS";
        loginBTNText.GetComponentInChildren<Text>().text = "GIRIS YAP";
        mainMenuText.GetComponentInChildren<Text>().text = "ANA MENU";

		setting.GetComponentInChildren<Text>().text = "AYARLAR";
		setText.GetComponentInChildren<Text>().text = "AYARLAR";
		langText.GetComponentInChildren<Text>().text = "DIL";
		resetText.GetComponentInChildren<Text>().text = "SIFIRLA";
		resetAns.GetComponentInChildren<Text>().text = "SIFIRLAMAK ISTEDIGINE EMIN MISIN?";
		r_yes.GetComponentInChildren<Text>().text = "EVET";
		r_no.GetComponentInChildren<Text>().text = "HAYIR";
        kadi.GetComponentInChildren<Text>().text = "KULLANICI ADI";
        sifre.GetComponentInChildren<Text>().text = "SIFRE";
        loginustbaslik.GetComponentInChildren<Text>().text = "UYE GIRISI";

        quit.GetComponentInChildren<Text>().text = "ÇIKIS";
		quitText.GetComponentInChildren<Text>().text = "ÇIKIS";
		quitAns.GetComponentInChildren<Text>().text = "ÇIKMAK ISTEDIGINE EMIN MISIN?";
		yes.GetComponentInChildren<Text>().text = "EVET";
		no.GetComponentInChildren<Text>().text = "HAYIR";
		Save ();
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
}
[Serializable]
class Langu
{
	public string lang;
}