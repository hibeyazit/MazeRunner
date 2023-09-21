using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RifleSystem : MonoBehaviour
{
    [Header("Settings")]
    float AtesEtmeSikligi_1;
    public float AtesEtmeSikligi_2;
    public float range;
    float bullet=30;
    float maxBullet=30;
    public Image Fill;
    [Header("Sounds")]
    public AudioSource[] shootingSounds;
    [Header("effects")]
    public ParticleSystem[] effects;
    [Header("General Operations")]
    public Camera MyCam;
    Animator anim;
    AudioSource audioG;
    void Start()
    {
        anim = GetComponent<Animator>();
        audioG = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (bullet>0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Time.time > AtesEtmeSikligi_1)
                {
                    fire();
                    bullet--;
                    Fill.fillAmount = bullet / maxBullet;
                    audioG.Play();
                    AtesEtmeSikligi_1 = Time.time + AtesEtmeSikligi_2;

                }
            }
        }
        if (bullet < 1)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                shootingSounds[1].Play();
            }           
        }

        if (Input.GetKey(KeyCode.R) && bullet<1)
        {    
            shootingSounds[2].Play();
            bullet = maxBullet;
            //DELAY EKLE  Sarjor sesi geliþtir

        }



    }
    void fire()
    {
        RaycastHit Hit;
        if (Physics.Raycast(MyCam.transform.position,MyCam.transform.forward,out Hit,range))
        {
            effects[0].Play();
            Instantiate(effects[1], Hit.point, Quaternion.LookRotation(Hit.normal));
            if (Hit.transform.name == "enemy")
            {
                HealthSystem.instance.enemyDamage(10);
                if (HealthSystem.instance.enemyCurrentHealth<1)
                { 
                    Destroy(Hit.collider.gameObject);
                    HealthSystem.instance.enemyCurrentHealth = HealthSystem.instance.enemyMaxHealth;
                }
              
            }  
        }

    }
}
