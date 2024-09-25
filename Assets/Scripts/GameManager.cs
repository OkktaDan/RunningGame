using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunGame
{
    public class GameManager : MonoBehaviour
    {
        #region
        public static GameManager Instance;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            StartGame();
        }
        #endregion

        [SerializeField] private bool gameStateIsPlaying = true;
        private int transferredPoints = 0;
        
        void Update()
        {
            if (!gameStateIsPlaying)
            {
                GameOver();
            }
            else
            {
                Debug.Log($"Points: {transferredPoints}");
            }
        }

        public bool isPlaying()
        {
            return gameStateIsPlaying;
        }

        public void setIsPlaying(bool endPlay)
        {
            gameStateIsPlaying = endPlay;
        }

        public void StartGame()
        {
            Time.timeScale = 1;
        }

        public void GameOver()
        {
            Time.timeScale = 0;
        }

        public int GetTransferredPoints()
        {
            return transferredPoints;
        }

        public void SetTransferredPoints(int points)
        {
            transferredPoints = points;
        }
    }
}