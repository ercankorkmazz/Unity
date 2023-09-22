using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class H_2 : MonoBehaviour
{
    GameObject GameControler_Object;
    GameController myGameController;
    public GameObject H2_Bekleme_Sayaci;
    public GameObject H2_Bekleme_SayaciText;
    public GameObject ParaEfekti;
    public GameObject AtesEfekti;
    public float animasyonSuresi;
    private float Sayac;
    public static float beklemeSayaci { get; set; }
    public static int beklemeSayaciKontrolu { get; set; }
    void Start()
    {
        GameControler_Object = GameObject.Find("GameControler");
        myGameController = GameControler_Object.GetComponent<GameController>();

        beklemeSayaci = myGameController.beklemeSuresi;
        beklemeSayaciKontrolu = 0;


        if (beklemeSayaci > 0)
        {
            Sayac = beklemeSayaci * 3;
            H2_Bekleme_SayaciText.GetComponent<Text>().text = beklemeSayaci.ToString();
        }
        else
            Sayac = 10;

        GameObject ZamanSayaci = GameObject.Find("H2_SayacText");
        ZamanSayaci.GetComponent<Text>().text = Mathf.RoundToInt(Sayac).ToString();
    }
    void Update()
    {
        if (GameController.Hareket_2 == 2)
        {
            GameController.Hareket_2 = 0;
            Destroy(gameObject);
            GameController.Hareket_Uretme_Kontrolu = 0;
            Instantiate(ParaEfekti, transform.position, Quaternion.identity);
            GameController.dogruYapinHareketSayisi++;

        }
        if (Sayac < 0.000001f)
        {
            GameController.Hareket_2 = 0;
            Destroy(gameObject);
            Instantiate(AtesEfekti, transform.position, Quaternion.identity);
            GameController.Canlar--;
            GameController.yanlisYapilanHareketSayisi++;

            if (GameController.Canlar != 0)
                GameController.Hareket_Uretme_Kontrolu = 0;
        }
    }
    void FixedUpdate()
    {
        if (animasyonSuresi > 0)
            animasyonSuresi -= Time.deltaTime; //Bekleme süresi azalcak
        else
        {
            if (Sayac > 0)
                Sayac -= Time.deltaTime; //zaman azalcak

            if (beklemeSayaciKontrolu == 1)
            {
                H2_Bekleme_Sayaci.SetActive(true);

                if (beklemeSayaci > 0)
                    beklemeSayaci -= Time.deltaTime; //zaman azalcak
            }
        }

        GameObject ZamanSayaciTXT = GameObject.Find("H2_SayacText");
        ZamanSayaciTXT.GetComponent<Text>().text = Mathf.RoundToInt(Sayac).ToString();

        H2_Bekleme_SayaciText.GetComponent<Text>().text = Mathf.RoundToInt(beklemeSayaci).ToString();
    }
}
