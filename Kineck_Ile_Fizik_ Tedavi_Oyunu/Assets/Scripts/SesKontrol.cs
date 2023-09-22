using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class SesKontrol : MonoBehaviour
{
    public AudioClip MusicSound;
    public Slider MuzikSesiVolSlider;
    public Slider ButtonVolSlider;

    public float Music_Volume;
    public float Button_Volume;

    GameObject ButtonSoundController_Object;
    AudioSource myButtonSesi_AudioSource;

    void Start ()
    {

        GetComponent<AudioSource>().PlayOneShot(MusicSound);//müziği çal
        ButtonSoundController_Object = GameObject.Find("ButtonSoundController");
        myButtonSesi_AudioSource = ButtonSoundController_Object.GetComponent<AudioSource>();//button sesine ulaş
        Yukle();//Kayıtlı bi deger dönüyorsa tabiki en başta cagırılacak
        MuzikSesSeviyesiGuncelle(Music_Volume);//cagır
        ButtonSesSeviyesiGuncelle(Button_Volume);//cagır
    }
    public void MuzikSesSeviyesiGuncelle(float Deger)
    {
        MuzikSesiVolSlider.value = Deger;//value degerini deger degiskenine at
        GetComponent<AudioSource>().volume = Deger;//müzik volumesi ile yukarı da atanan value degerini eşitle
    }

    public void ButtonSesSeviyesiGuncelle(float ButtonDeger)
    {
        ButtonVolSlider.value = ButtonDeger;//value degerini deger degiskenine at
        myButtonSesi_AudioSource.volume = ButtonDeger;//button volumesi ile yukarı da atanan value degerini eşitle
    }

    public void showMusic_SliderValue(Slider Music_SliderValue)
    {
        Music_Volume = Music_SliderValue.value;//müzik sliderin daki degeri music volume si degiskenine ata .Bu ayar slider i hareket ettirmek amaçlıdır
        Kaydet();//Bu ayarlanan slider i kaydet fonk. cagırarak kaydet
    }
    public void showButtonSliderValue(Slider Button_SliderValue)
    {
        Button_Volume = Button_SliderValue.value;//müzik sliderin daki degeri music volume si degiskenine ata .Bu ayar slider i hareket ettirmek amaçlıdır
        Kaydet();//Bu ayarlanan slider i kaydet fonk. cagırarak kaydet
    }
    public void Kaydet()
    {
        BinaryFormatter BF = new BinaryFormatter();
        FileStream Dosya = File.Create("Save/Ses.dat"); // Bu iki satır veritabanını oluşturuyo

        VeriPaketi Veri = new VeriPaketi();
        Veri.Music_Volume = MuzikSesiVolSlider.value;//Music_Volume degeri ,yukarıdan gelen müzk sliderin value degerine eşitleniyor
        Veri.Button_Volume = ButtonVolSlider.value;//Button_Volume degeri ,yukarıdan gelen button sliderin value degerine eşitleniyor

        BF.Serialize(Dosya, Veri);
        Dosya.Close();
    }
    public void Yukle()
    {
        if (File.Exists("Save/Ses.dat"))
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream Dosya = File.Open("Save/Ses.dat", FileMode.Open);
            VeriPaketi Veri = (VeriPaketi)BF.Deserialize(Dosya);

            Music_Volume = Veri.Music_Volume;//Float degerlere veri tabanından gelen degerler eşitlendi
            Button_Volume = Veri.Button_Volume;//Float degerlere veri tabanından gelen degerler eşitlendi

            Dosya.Close();
        }
        else
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream Dosya = File.Create("Save/Ses.dat"); // Bu iki satır veritabanını oluşturuyor

            VeriPaketi Veri = new VeriPaketi();
            Veri.Music_Volume = 1.0f;//kayıtlı deger yoksa hepsini fulle
            Veri.Button_Volume = 1.0f;//kayıtlı deger yoksa hepsini fulle
            BF.Serialize(Dosya, Veri);
            Dosya.Close();

            Music_Volume = 1.0f;
            Button_Volume = 1.0f;
        }
    }
    [Serializable]
    class VeriPaketi
    {
        public float Music_Volume;
        public float Button_Volume;
        // veri tiplerine göre bu alanda değişkenler çoğaltılabilir.
    }
}
