using UnityEngine;
using System.Collections;

public class SelfTouchCheck : MonoBehaviour 
{
	// Update is called once per frame
	void Update ()
	{
        if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                SendMessage("AnimStateSet", AnimationManager.AnimState.INTERACTIVE_STATE);
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                SendMessage("AnimStateSet", AnimationManager.AnimState.ATTACK_STATE);
            }
        }
	}
}
