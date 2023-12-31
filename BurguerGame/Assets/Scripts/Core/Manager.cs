using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core {
    public class Manager : MonoBehaviour
    {   
        public Timer GameTimer = new Timer();
        public Text GameTimeUI, ScoreUI;
        public int Points;
        public GameObject EndGamePageUI;
        public Text FinalScoreUI;  
        bool _gameEnded;

        public AudioSource Wrong, Correct;

        public void AddPoints() {
            Correct.Play();
            Points += 10;
        }
        public void RemovePoints() {
            Wrong.Play();
            Points -= 20;
        }
        public void EndGame() {
            _gameEnded = true; 
            FinalScoreUI.text = Points.ToString();
            EndGamePageUI.SetActive(true);
            gameObject.SetActive(false);
            Debug.Log("END");
        }

        void Update()
        {
            if(_gameEnded) return;

            if(GameTimer.FinishGame) {
                EndGame();
            }

            GameTimer.Count();
            GameTimeUI.text = GameTimer.FormattedTime;
            ScoreUI.text = Points.ToString();
        }
    }

}

