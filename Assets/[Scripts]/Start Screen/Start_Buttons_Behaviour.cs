using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Buttons_Behaviour : MonoBehaviour
{
    public void PlayGame()
    {
        LivesStatic.score = 0;
        LivesStatic.playerLives = 3;
        RespawnPositionStatic.SetSpawnIndex(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
