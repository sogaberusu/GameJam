using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle_Attack : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Alcides");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerController.Hp);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //クワガタのHPを減らす処理を描く
            Debug.Log("あたった");

            playerController.Hp -= 10;
        }
    }
}
