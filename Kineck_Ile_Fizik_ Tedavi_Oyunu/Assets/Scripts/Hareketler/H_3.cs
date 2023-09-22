using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class H_3 : MonoBehaviour
{
    GameObject GameControler_Object;
    GameController myGameController;
    public GameObject H3_Bekleme_Sayaci;
    public GameObject H3_Bekleme_SayaciText;
    public GameObject ParaEfekti;
    public GameObject AtesEfekti;
    public float animasyonSuresi;
    private float Sayac;
    public static float H3_beklemeSayaci { get; set; }
    public static int beklemeSayaciKontrolu { get; set; }
    void Start()
    {
        GameControler_Object = GameObject.Find("GameControler");
        myGameController = GameControler_Object.GetComponent<GameController>();

        H3_beklemeSayaci = myGameController.beklemeSuresi;
        beklemeSayaciKontrolu = 0;
        
        if (H3_beklemeSayaci > 0)
        {
            Sayac = H3_beklemeSayaci * 3;
            H3_Bekleme_SayaciText.GetComponent<Text>().text = H3_beklemeSayaci.ToString();
        }
        else
            Sayac = 10;
        
        GameObject ZamanSayaci = GameObject.Find("H3_SayacText");
        ZamanSayaci.GetComponent<Text>().text = Mathf.RoundToInt(Sayac).ToString();
    }
    void Update()
    {
        if (GameController.Hareket_3 == 2)
        {
            GameController.Hareket_3 = 0;
            Destroy(gameObject);
            GameController.Hareket_Uretme_Kontrolu = 0;
            Instantiate(ParaEfekti, transform.position, Quaternion.identity);
            GameController.dogruYapinHareketSayisi++;

        }
        if (Sayac < 0.000001f)
        {
            GameController.Hareket_3 = 0;
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

            if(beklemeSayaciKontrolu == 1)
            {
                H3_Bekleme_Sayaci.SetActive(true);

                if (H3_beklemeSayaci > 0)
                    H3_beklemeSayaci -= Time.deltaTime; //zaman azalcak
            }
        }

        GameObject ZamanSayaciTXT = GameObject.Find("H3_SayacText");
        ZamanSayaciTXT.GetComponent<Text>().text = Mathf.RoundToInt(Sayac).ToString();

        H3_Bekleme_SayaciText.GetComponent<Text>().text = Mathf.RoundToInt(H3_beklemeSayaci).ToString();
    }
}
