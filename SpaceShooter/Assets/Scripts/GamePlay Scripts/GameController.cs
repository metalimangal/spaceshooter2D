using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText, PanelText;
    private int score;
    [SerializeField]
    private GameObject pausePanel;
    private GameObject player;
    public Button pause;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreText.text = "Score: "+score;
    }

    void Update()
    {
        if (!player.activeInHierarchy)
        {
            WaitTillRespawn();
        }
    }

    public void AddScore(int add)
    {
        score += add;
        scoreText.text = "Score: " + score;
    }

    public void Pause()
    {
        PanelText.text = "Pause";
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        if (PanelText.text == "Pause")
            pausePanel.gameObject.SetActive(false);
        else
            SceneManager.LoadScene("GamePlay");
        
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    void WaitTillRespawn()
    {
        pausePanel.gameObject.SetActive(true);
        PanelText.text = "Game Over!!!!";
    }

}
