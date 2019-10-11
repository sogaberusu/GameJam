using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToResult : MonoBehaviour
{
    private bool GameClearFlag = false;
    private bool GameOverFlag = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            GameClearFlag = true;
            Debug.Log("ClearFlag");
        }
        if (Input.GetKey(KeyCode.P))
        {
            GameOverFlag = true;
            Debug.Log("OverFlag");
        }

        if (GameClearFlag == true)
        {
            SceneManager.LoadScene("GameClear");
            Debug.Log("Game Clear!!");
        }
        if (GameOverFlag == true)
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("Game Over...");
        }
    }
}
