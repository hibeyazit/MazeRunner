using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ders1 : MonoBehaviour
{

    public static Ders1 instance;
    public Text Yaz�;
    public Image Bar;
    void Start()
    {
        instance = this;

    }

    void Update()
    {
       
               
    }
   public  void Mat(string name) 
    {
        Debug.Log("Ders ismi "+ name);
    
    }
    public void BasBana()
    {
        Yaz�.text = "UWUUUUUUUU";
        Bar.fillAmount =Bar.fillAmount-10;
     
    }


}
