using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public int Can;
    void Update()
    {
        if (GameController.Canlar < Can)
        {
            Destroy(gameObject);
        }
    }
    [Serializable]
    class VeriPaketi
    {
        public int Can;
        // veri tiplerine göre bu alanda değişkenler çoğaltılabilir.
    }
}
