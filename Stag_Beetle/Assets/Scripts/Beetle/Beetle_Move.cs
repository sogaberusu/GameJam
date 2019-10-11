using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Beetle_Move : MonoBehaviour
{
    Animation anim;
    Transform player;
    GameObject Box;
    public BoxCollider horn;
    public Rigidbody body;
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

        Box = GameObject.Find("Cube");
        horn = Box.GetComponent<BoxCollider>();
        body = this.GetComponent<Rigidbody>();
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
        //Debug.Log(beetleState);

        //重力
        Vector3 ms = this.transform.forward;
        body.position += ms;
        body.AddForce(this.transform.up * (-9.8f) * 1000);
        this.transform.position += this.transform.up * (-0.098f);

        //body.isKinematic = false;

        //if (body.isKinematic == false)
        //{
        //    transform.SetPositionAndRotation(new Vector3(76.0f, transform.position.y, 0.0f), Quaternion.Euler(90.0f, 90.0f, 0.0f));
        //}
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("体が当たっている");
            body.position = this.transform.position;
            //body.isKinematic = true;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            body.position = this.transform.position;
            body.Sleep();
            if (body.IsSleeping())
            {
                Debug.Log("スリープ");
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("体が離れた");

            //body.isKinematic = false;
        }
    }
}
