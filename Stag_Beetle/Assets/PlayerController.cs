using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] BoxCollider horn = null;
    [SerializeField] GameObject beetle = null;
    Beetle_Move beetle_Move;
    [SerializeField]  float Speed = 2.0f;
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
        //コントローラー対応の移動記述。　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
        if (!IsAtk)
        {
            if (moveSpeed != 0.0f)
            {
                anim.Play("alcides_walk");

            }
            else if (moveSpeed == 0.0f)
            {
                anim.Play("alcides_idle1");
            }
        }

        //if (Input.GetKey("joystick button 0"))
        //{
        //    IsAtk = true;
        //    anim.Play("alcides_attack2");
        //    moveSpeed *= 0.0f;
        //}
        if (Input.GetKey(KeyCode.J) )
        {
            IsAtk = true;
            anim.Play("alcides_attack2");
            canThrowBeetle = true;
        }

        if (canThrowBeetle && IsHunt)
        {
            if (Input.GetKey(KeyCode.J))
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
        this.transform.position += ms;
        rb.AddForce(this.transform.up * (-9.8f) * 1000);
        this.transform.position += this.transform.up * (-0.098f);
    }
    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //    }
    //}
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            rb.velocity *= 0.0f;
            rb.Sleep();
            notMove = true;
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
}
