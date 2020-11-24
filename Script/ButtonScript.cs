using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Level");
    }

    
}
