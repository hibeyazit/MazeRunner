using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectionManager : MonoBehaviour
{
    int coin;
    int coinTotal;
    public Text coinText;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {           
            Destroy(gameObject);
            coinTotal += 1;
            coinText.text = "" + coinTotal;
            Destroy(other.gameObject);

        }
    }
}
