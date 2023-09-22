using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class LogInMenu : MonoBehaviour
{
    GameObject GameControler_Object;
    sessionControl mysessionController;
    MenuControl myMenuControl;
    level myLevel;

    public InputField userNameIF;
    public InputField passwordIF;
    public Text infoText;
    void Start()
    {
        GameControler_Object = GameObject.Find("GameControler"); // Sahnedeki nese adı ile o nesneye ekli Class'a ulaşmaya yarar.
        mysessionController = GameControler_Object.GetComponent<sessionControl>();
        myMenuControl = GameControler_Object.GetComponent<MenuControl>();
        myLevel = GameControler_Object.GetComponent<level>();
    }

    void Awake()
    {
        infoText.text.Equals(string.Empty);
        passwordIF.inputType = InputField.InputType.Password;
    }

    void OnEnable()
    {
        userNameIF.text = "";
        passwordIF.text = "";

        infoText.text = "";
    }

    public void girisYapBTN()
    {
        string kadi = userNameIF.text;
        string sifre = passwordIF.text;

        User user = ServerDatabase.Instance.girisPaneliKullaniciKontrolu(kadi, sifre);

        if (user.kadi == null)
        {
            infoText.text = "KULLANICI ADI VEYA SIFRE HATALI";
        }

        if (user.sifre == passwordIF.text)
        {
            if (user.KTuru == 2)
            {
                infoText.text = "";
                
                mysessionController.oturumAc(user.id, user.hastaID);
                mysessionController.Load();
                myMenuControl.LevelSelect();
                myLevel.menuListele();
            }                
            else
                infoText.text = "GIRIS YETKINIZ YOK";
        }

    }
}
