using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle_Attack : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Alcides");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //クワガタのHPを減らす処理を描く
            Debug.Log("あたった");

            //player.GetComponent
        }
    }
}
