using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLivesTracker : MonoBehaviour
{
    public GameObject[] hearts = new GameObject[5];

    public int lives = 3;

    // Start is called before the first frame update

    void Start()
    {
        UpdateLivesUI();

    }

    // Update is called once per frame
    void Update()
    {
        //UpdateLivesUI();
        if (lives <= 0)
        {
            HandleGameOver();
        }
        //UpdateLivesUI();
    }

    public void DecreaseLives(int amount = 1)
    {
        lives -= amount;
        UpdateLivesUI();
        if(lives <= 0)
        {
            HandleGameOver();
        }
    }

    public void IncreaseLives(int amount = 1)
    {
        lives += amount;
        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < lives)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    private void HandleGameOver()
    {
        //load game over scene
        SceneManager.LoadScene("GameOver");
    }
}
