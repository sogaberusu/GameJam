using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] BoxCollider horn = null;
    [SerializeField]  float Speed = 2.0f;
    float moveSpeed = 0.0f;
    Rigidbody rb;
    Animation anim;
    private bool IsAtk = false;
    private bool IsWalk = false;
    private bool notMove = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        moveSpeed = Input.GetAxis("Vertical") * Speed;
        if (notMove)
        {
            Debug.Log(true);
        }
        //コントローラー対応の移動記述。　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
        if (!IsAtk)
        {
            if (moveSpeed != 0.0f)
            {
                IsWalk = true;
                anim.Play("alcides_walk");

            }
            else if (moveSpeed == 0.0f)
            {
                anim.Play("alcides_idle1");
            }
        }

        //if (Input.GetKey("joystick button 0") && !IsWalk)
        //{
        //    IsAtk = true;
        //    anim.Play("alcides_attack2");
        //}
        if (Input.GetKey(KeyCode.J) && !IsWalk)
        {
            IsAtk = true;
            anim.Play("alcides_attack2");
        }

        if (!anim.isPlaying && IsAtk)
        {
            IsAtk = false;
        }

        if (!IsAtk && IsWalk)
        {
            IsWalk = false;
        }
        //this.transform.position += this.transform.forward * moveSpeed;
        //this.transform.position += this.transform.up * (-0.098f);
        Vector3 ms = this.transform.forward;
        if (!notMove)
        {
            ms *= moveSpeed;
        }
        else if(moveSpeed<0.0f)
        {
            ms *= moveSpeed;
        }
        else
        {
            ms *= 0.0f;
        }
        //rb.position += ms;
        this.transform.position += ms;
        rb.AddForce(this.transform.up * (-9.8f) * 1000);
        this.transform.position += this.transform.up * (-0.098f);
        if (rb.IsSleeping())
        {
            Debug.Log("スリープ");
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            rb.position = this.transform.position;
           
            Debug.Log("あたってる");
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            rb.position = this.transform.position;
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

        Debug.Log("攻撃開始");
    }

    void AttackEnd()
    {
        horn.enabled = false;

        Debug.Log("攻撃終了");
    }
}
