using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Beetle_Move : MonoBehaviour
{
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();

        anim.Play("Dynastid beetle_male_idle2");
    }

    // Update is called once per frame
    void Update()
    {
        //クワガタとの距離が近かったらに変更予定
        if (Input.GetKey("joystick button 1"))
        {
            anim.Play("Dynastid beetle_male_attack2");
        }
        else if (Input.GetKey("joystick button 0"))
        {
            transform.Translate(0.0f, 0.0f, 0.05f);
            anim.Play("Dynastid beetle_male_walk");
        }
        else if (Input.GetKey("joystick button 2"))
        {
            transform.Translate(0.0f, 0.0f, -0.05f);
            anim.Play("Dynastid beetle_male_walk");
        }
        else
        {
            anim.Play("Dynastid beetle_male_idle2");
        }
    }
}
