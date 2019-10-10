using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle_Attack_Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = GameObject.Find("Dynastid beetle_male").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void InActive()
    {
        gameObject.SetActive(false);
    }
}
