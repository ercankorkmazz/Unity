using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HareketKontroluBolgesiKomutlari : MonoBehaviour {

    void Start()
    {
        GameController.Hareket_1 = 0;
        GameController.Hareket_2 = 0;
        GameController.Hareket_3 = 0;
        GameController.Hareket_4 = 0;
        GameController.Hareket_5 = 0;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hareket_1")
            GameController.Hareket_1 = 1;
        else if (other.gameObject.tag == "Hareket_2")
            GameController.Hareket_2 = 1;
        else if (other.gameObject.tag == "Hareket_3")
            GameController.Hareket_3 = 1;
        else if (other.gameObject.tag == "Hareket_4")
            GameController.Hareket_4 = 1;
        else if (other.gameObject.tag == "Hareket_5")
            GameController.Hareket_5 = 1;
    }
}
