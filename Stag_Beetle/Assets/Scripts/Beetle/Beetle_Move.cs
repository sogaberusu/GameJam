using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Beetle_Move : MonoBehaviour
{
    Animation anim;
    Transform player;
    enum BeetleState
    {
        idle,
        advance,
        recession,
        attack
    }
    BeetleState beetleState = BeetleState.advance;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();

        anim.Play("Dynastid beetle_male_idle2");

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Dorcus_titanus_male").transform;
        Vector3 playerPos = player.transform.position;
        Vector3 beetlePos = this.transform.position;
        float dis = Vector3.Distance(playerPos, beetlePos);
        Debug.Log("Distance:" +dis);

        //クワガタとの距離が近かったら攻撃
        if (dis < 30.0f )
        {
            beetleState = BeetleState.attack;
        }



        if(beetleState == BeetleState.idle)
        {
            anim.Play("Dynastid beetle_male_idle2");
        }
        if (beetleState == BeetleState.advance)
        {
            transform.position += transform.forward * 0.05f;
            anim.Play("Dynastid beetle_male_walk");
        }
        if (beetleState == BeetleState.recession)
        {
            transform.position += transform.forward * -0.05f;
            anim.Play("Dynastid beetle_male_walk");
        }
        if (beetleState == BeetleState.attack)
        {
            anim.Play("Dynastid beetle_male_attack2");

            beetleState = BeetleState.recession;
        }
    }
}
