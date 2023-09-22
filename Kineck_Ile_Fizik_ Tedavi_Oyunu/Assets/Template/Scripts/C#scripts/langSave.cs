using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class langSave : MonoBehaviour {
	public string language;

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create("Save/language.dat");

		Language data = new Language();
		data.language = language;

		bf.Serialize(file, data);
		file.Close();
	}
	public void Load()
	{
		if(File.Exists("Save/language.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open("Save/language.dat", FileMode.Open);
			Language data = (Language)bf.Deserialize(file);
			file.Close();

			language = data.language;
		}
	}
}
[Serializable]
class Language
{
	public string language;
}
