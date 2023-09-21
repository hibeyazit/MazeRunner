using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ders2 : MonoBehaviour
{
    string isim = "Mat";
    public static Ders2 instance;

    void Start()
    {
        instance = this;
    }


    void Update()
    {

        Ders1.instance.Mat(isim);

    }
    public void Turk()
    {
        Debug.Log("Ders 2 den geldim");
    }
}
