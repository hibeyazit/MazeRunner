using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    float inputX;
    float inputY;
    public Transform character;
    Animator anim;
    Vector3 currentDirection;
    Camera mainCam;
    float maxLength=1;
    float rotationSpeed=10;
    float maxSpeed;
    public int coinAmount = 10;
    public Text coint;
    int coinTotal;
    Rigidbody rb;
    public float jumpForce = 10f;
    public float jumpDuration = 0.5f;
    public float jumpCooldown = 1f;
    private bool isJumping = false;
    private float jumpTimer = 0f;
    private float lastJumpTime = 0f;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }
    void LateUpdate() 
    {
        jump();
        Movement();
        currentDirection = new Vector3(inputX,0 ,inputY);
       
        InputMove();
        InputRotation();
    }
    void Movement()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 1;
            inputX = maxSpeed * Input.GetAxis("Horizontal");
            inputY = maxSpeed * Input.GetAxis("Vertical");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            maxSpeed = 0.8f;
            inputX = maxSpeed * Input.GetAxis("Horizontal");
            inputY = maxSpeed * Input.GetAxis("Vertical");
        }
        else
        {
            maxSpeed = 0f;
            inputX = maxSpeed * Input.GetAxis("Horizontal");
            inputY = maxSpeed * Input.GetAxis("Vertical");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("runleft", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("runleft", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("runright", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("runright", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("runback", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("runback", false);
        }
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            isJumping = true;
            jumpTimer = 0f;
            lastJumpTime = Time.time;
        }

        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer < jumpDuration)
            {
                rb.AddForce(Vector3.up * (jumpForce/50), ForceMode.Impulse);
            }
            else
            {
                isJumping = false;
            }
        }

    }
    bool CanJump()
    {
        return Time.time - lastJumpTime > jumpCooldown;
    }
    void InputMove()
    {
        anim.SetFloat("speed",Vector3.ClampMagnitude(currentDirection,maxSpeed).magnitude,maxLength,Time.deltaTime*10);
    }
    void InputRotation()
    {
        Vector3 CamOffset = mainCam.transform.TransformDirection(currentDirection);
        CamOffset.y = 0;
        character.forward = Vector3.Slerp(character.forward,CamOffset,Time.deltaTime*rotationSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            coinTotal += coinAmount;
            coint.text = "" + coinTotal;
           
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            HealthSystem.instance.Damage(40);
        }
    }

}
