using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Beetle_Move : MonoBehaviour
{
    Animation anim;
    Transform player;
    GameObject Box;
    BoxCollider horn;
    enum BeetleState
    {
        idle,
        advance,
        recession,
        attack,
        attacked,
    }
    BeetleState beetleState = BeetleState.idle;
    int transitionCount = 0;
    bool IsAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //player = GameObject.Find("Alcides").transform;
        //Vector3 playerPos = player.transform.position;
        //Vector3 beetlePos = this.transform.position;
        //float dis = Vector3.Distance(playerPos, beetlePos);
        if (transitionCount > 60 && !anim.IsPlaying("Dynastid beetle_male_attack2") && !anim.IsPlaying("Dynastid beetle_male_idle1"))
        {
            while (true)
            {
                int random;
                random = Random.Range((int)BeetleState.idle, (int)BeetleState.attacked);
                if (beetleState == BeetleState.idle && beetleState == (BeetleState)random
                    || beetleState == BeetleState.attack && beetleState == (BeetleState)random)
                {
                    random = Random.Range((int)BeetleState.idle, (int)BeetleState.attacked);
                }
                else
                {
                    beetleState = (BeetleState)random;
                    transitionCount = 0;
                    break;
                }
            }
        }
        ////クワガタとの距離が近かったら攻撃
        //else if (dis < 30.0f)
        //{
        //    beetleState = BeetleState.attack;
        //}
        else
        {
            transitionCount++;
        }

        if (beetleState == BeetleState.idle)
        {
            anim.CrossFade("Dynastid beetle_male_idle1");
        }
        if (beetleState == BeetleState.advance)
        {
            transform.position += transform.forward * 0.1f;
            anim.CrossFade("Dynastid beetle_male_walk");
        }
        if (beetleState == BeetleState.recession)
        {
            transform.position += transform.forward * -0.05f;
            anim.CrossFade("Dynastid beetle_male_walk");
        }
        if (beetleState == BeetleState.attack)
        {
            anim.CrossFade("Dynastid beetle_male_attack2");
            IsAttack = true;
        }
        if (!anim.IsPlaying("Dynastid beetle_male_attack2") && IsAttack == true)
        {
            beetleState = BeetleState.idle;
            IsAttack = false;
        }
        Debug.Log(beetleState);

        //this.transform.position += this.transform.up * (-0.098f);
    }

    //void OnTriggerEnter(BoxCollider col)
    //{
    //    if (col.tag == "Enemy")
    //    {
    //        Debug.Log("敵に当たった");
    //    }
    //}
}
