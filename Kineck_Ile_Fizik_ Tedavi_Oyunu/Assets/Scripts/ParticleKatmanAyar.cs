using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKatmanAyar : MonoBehaviour {
    
	void Start ()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Template";
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 10;
    }
}
