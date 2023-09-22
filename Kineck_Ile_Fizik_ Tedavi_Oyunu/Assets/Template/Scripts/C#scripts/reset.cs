using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class reset : MonoBehaviour {
    //GameObject ButtonSoundController_Object;
    //AudioSource myButtonSesi_AudioSource;
    public GameObject gamereset ;

	string sonKaydedilenSeviyeID = "1";
	string para = "0";

    //void Start()
    //{
    //    ButtonSoundController_Object = GameObject.Find("ButtonSoundController");
    //    myButtonSesi_AudioSource = ButtonSoundController_Object.GetComponent<AudioSource>();
    //}
 
    public void sifirla()
	{
		gamereset.SetActive (false);
		Save ();
	}
		
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create("Save/level.dat");

		Level data = new Level();
		data.sonKaydedilenSeviyeID = sonKaydedilenSeviyeID;

		bf.Serialize(file, data);
		file.Close();
	}
	public void Load()
	{
		if(File.Exists("Save/level.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open("Save/level.dat", FileMode.Open);
			Level data = (Level)bf.Deserialize(file);
			file.Close();

            sonKaydedilenSeviyeID = data.sonKaydedilenSeviyeID;
		}
	}
}
