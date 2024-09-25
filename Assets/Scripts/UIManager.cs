using System.Collections;
using System.Collections.Generic;
using RunGame;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    GameManager gManager;

    void Start()
    {
        gManager = GameManager.Instance;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!gManager.isPlaying())
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
