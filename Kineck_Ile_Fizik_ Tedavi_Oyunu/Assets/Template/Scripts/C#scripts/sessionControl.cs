using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class sessionControl : MonoBehaviour {
    
    int oturum;
    public GameObject singinBTN;
    public GameObject levelsBTN;
    void Start()
    {
        //oturumKapat();
        Load();
    }
    public void oturumAc(int gelenID, int gelenHastaID)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Save/oturum.dat");

        SessionData data = new SessionData();
        data.oturum = 1;
        data.kullaniciID = gelenID;
        data.hastaID = gelenHastaID;

        bf.Serialize(file, data);
        file.Close();
    }
    public void programiKapat()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Save/oturum.dat");

        SessionData data = new SessionData();
        data.oturum = 0;

        bf.Serialize(file, data);
        file.Close();

        Application.Quit();
    }
    public void oturumKapat()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Save/oturum.dat");

        SessionData data = new SessionData();
        data.oturum = 0;

        bf.Serialize(file, data);
        file.Close();

        Application.LoadLevel(0);
    }
    public void Load()
    {
        if (File.Exists("Save/oturum.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("Save/oturum.dat", FileMode.Open);
            SessionData data = (SessionData)bf.Deserialize(file);
            file.Close();

            oturum = data.oturum;
        }
        else
            oturumKapat();

        if (oturum == 0)
        {
            singinBTN.SetActive(true);
            levelsBTN.SetActive(false);
        }
        else if(oturum == 1)
        {
            singinBTN.SetActive(false);
            levelsBTN.SetActive(true);
        }
    }
}
[Serializable]
class SessionData
{
    public int oturum;
    public int kullaniciID;
    public int hastaID;
}
