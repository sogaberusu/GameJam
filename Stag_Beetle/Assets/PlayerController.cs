using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] BoxCollider horn = null;
    [SerializeField] GameObject beetle = null;
    Beetle_Move beetle_Move;
    [SerializeField]  float Speed = 0.5f;
    public int Hp = 100;
    float moveSpeed = 0.0f;
    Rigidbody rb;
    Animation anim;
    private bool IsAtk = false;
    private bool notMove = false;
    public bool IsHunt = false;
    private bool canThrowBeetle = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animation>();
        beetle_Move=beetle.GetComponent<Beetle_Move>();
    }

    void Update()
    {
        moveSpeed = Input.GetAxis("Vertical") * Speed;
        float dx = Input.GetAxis("Horizontal") * (Speed / 5);
        //コントローラー対応の移動記述。　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
        if (!IsAtk)
        {
            if (moveSpeed != 0.0f || dx != 0.0f)
            {
                anim.Play("alcides_walk");

            }
            else if (moveSpeed == 0.0f && dx == 0.0f)
            {
                anim.Play("alcides_idle1");
            }
        }

        if (Input.GetKey("joystick button 0"))
        {
            IsAtk = true;
            anim.Play("alcides_attack2");
            canThrowBeetle = true;
        }

        if (canThrowBeetle && IsHunt)
        {
            if (Input.GetKey("joystick button 0"))
            {
                beetle_Move.AttackSuccess();
                IsHunt = false;
                anim.Play("alcides_greeting");
            }
        }

        if (!anim.isPlaying && IsAtk)
        {
            IsAtk = false;
        }
        Vector3 ms = this.transform.forward;
        Vector3 msr = this.transform.right;
        if (!notMove)
        {
            ms *= moveSpeed;
        }
        else if (notMove && moveSpeed > 0.0f)
        {
            ms *= 0.0f;
        }
        else if (notMove && moveSpeed < 0.0f)
        {
            ms *= moveSpeed;
        }

        if (IsHunt|| IsAtk)
        {
            ms *= 0.0f;
        }
        msr *= dx;
        ms += msr;
        this.transform.position += ms;
        rb.AddForce(this.transform.up * (-9.8f) * 1000);
        this.transform.position += this.transform.up * (-0.098f);

        if (Hp < 0)
        {
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            rb.velocity *= 0.0f;
            rb.position = this.transform.position;
            rb.Sleep();
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            rb.velocity *= 0.0f;
            rb.position = this.transform.position;
            rb.Sleep();
            notMove = true;
        }
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("ゴール");
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            notMove = false;
        }
    }
    void AttackStart()
    {
        horn.enabled = true;
        
    }

    void AttackEnd()
    {
        horn.enabled = false;

    }
    void OnTriggerEnter(Collider collider)
    {
    }
}
