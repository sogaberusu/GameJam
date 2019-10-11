using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stag_Attack : MonoBehaviour
{
    [SerializeField] GameObject beetie = null;
    [SerializeField] GameObject player = null;
    Beetle_Move beetle_Move = null;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        beetle_Move = beetie.GetComponent<Beetle_Move>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            //カブトムシを吹っ飛ばす処理を書く。
            beetle_Move.Attacked();
            playerController.IsHunt = true;
        }
    }
}
