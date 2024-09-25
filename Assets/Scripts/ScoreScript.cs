using System.Collections;
using System.Collections.Generic;
using RunGame;
using TMPro;
using UnityEngine;
public class ScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private TextMeshProUGUI highScore;

    private float currentPoints = 0f;

    GameManager gManager;
    void Start()
    {
        gManager = GameManager.Instance;
        score.gameObject.SetActive(true);
    }

    void Update()
    {   
        if (!gManager.isPlaying())
        {
           ResetPoints();
           score.gameObject.SetActive(false);
        }
        else
        {
            currentPoints += Time.deltaTime / 5;
            score.text = PointsToString();
            HighScoreSystem();
            gManager.SetTransferredPoints(Mathf.RoundToInt(currentPoints));
        }
    }

    void ResetPoints()
    {
        currentPoints = 0;
    }

    string PointsToString()
    {
        return Mathf.RoundToInt(currentPoints).ToString();
    }

    public void HighScoreSystem()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (currentPoints > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", Mathf.RoundToInt(currentPoints));
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", Mathf.RoundToInt(currentPoints));
        }

        finalScore.text = PointsToString();
        highScore.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}
