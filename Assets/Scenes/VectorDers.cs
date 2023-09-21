using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDers : MonoBehaviour
{
    public GameObject obje;
    public GameObject Pozisyonum1;
    public GameObject Pozisyonum2;

    void Start()
    {
        //float mesafe = Pozisyonum1 - Pozisyonum2;
        //Vector3.Distance(Pozisyonum1,Pozisyonum2);
        //Pozisyonum1 = new Vector3(0,0,0);
        //obje.transform.position = Pozisyonum1;
        //transform.position = new Vector3(0, 0, 0);
        //Debug.Log(transform.position);
        //Debug.Log(transform.rotation);
        //Debug.Log(transform.localScale);
        //Pozisyonum1 = new Vector3(2f, 2f, 2f);
        //transform.position = Pozisyonum1;

        //if (Pozisyonum1 == transform.position)
        //{
        //    Debug.Log("Evet ayný");
        //}
        //else
        //{
        //    Debug.Log("Ayný degil");
        //}
        
    }
    void Update()
    {

        transform.position = Vector3.Lerp(Pozisyonum1.transform.position, Pozisyonum2.transform.position,6);

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * 20 * Time.deltaTime);
       
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * 20 * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * 20 * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * 20 * Time.deltaTime);
        //}

     
        //

    }
}
