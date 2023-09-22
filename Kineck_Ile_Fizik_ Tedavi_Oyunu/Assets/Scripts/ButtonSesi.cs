using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class ButtonSesi : MonoBehaviour
{
    public AudioClip ButtonSound;

    public void ButonSesiCal()
    {
        GetComponent<AudioSource>().PlayOneShot(ButtonSound);
    }
}
