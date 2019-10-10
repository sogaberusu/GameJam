using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float Speed = 2.0f;
    float z = 0.0f;
    Animation anim;
    private bool IsAtk = false;
    private bool IsWalk = false;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();

        anim = this.gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        z = Input.GetAxis("Vertical") * Speed;

        //コントローラー対応の移動記述。　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
        if (!IsAtk)
        {
            if (z != 0.0f)
            {
                IsWalk = true;
                anim.Play("alcides_walk");
                Debug.Log("歩く");

            }
            else if (z == 0.0f)
            {
                anim.Play("alcides_idle1");
                Debug.Log("待機");
            }
        }

        if (Input.GetKey("joystick button 0") && !IsWalk)
        {
            IsAtk = true;
            anim.Play("alcides_attack2");
            Debug.Log("攻撃動作");
        }

        if (!anim.isPlaying && IsAtk)
        {
            IsAtk = false;
        }

        if (!IsAtk && IsWalk)
        {
            IsWalk = false;
            Debug.Log("IsWalk = false");
        }
        this.transform.position += this.transform.forward * z;
        this.transform.position += this.transform.up * (-0.098f);
    }
}
