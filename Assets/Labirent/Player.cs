using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward*speed*Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(yatay, 0, dikey);
        rb.AddForce(move * speed * Time.deltaTime,ForceMode.Impulse);
        //rb.velocity = move * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("WÝN");
        }
    }
    
}
