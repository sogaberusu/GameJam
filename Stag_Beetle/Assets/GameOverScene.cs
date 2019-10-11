using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("joystick button 4"))
        {
            SceneManager.LoadScene("Game 2");
            Debug.Log("Restart");
        }
        if (Input.GetKey("joystick button 5"))
        {
            SceneManager.LoadScene("Title");
            Debug.Log("Go to Title Scene");
        }
    }
}