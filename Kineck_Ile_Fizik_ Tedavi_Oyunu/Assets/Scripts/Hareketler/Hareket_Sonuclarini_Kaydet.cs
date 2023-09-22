using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket_Sonuclarini_Kaydet : MonoBehaviour {

    private float Sayac;
    void Start ()
    {
        Sayac = 3.4f;
    }
	void Update () {
        if (Sayac < 0.000001f)
        {
            Destroy(gameObject);

            if (GameController.Canlar != 0)
                GameController.Hareket_Uretme_Kontrolu = 0;
        }
    }

    void FixedUpdate()
    {
        if (Sayac > 0)
            Sayac -= Time.deltaTime; //zaman azalcak
    }
}
