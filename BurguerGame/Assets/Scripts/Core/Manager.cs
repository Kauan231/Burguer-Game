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

        public void AddPoints() {
            Points += 10;
        }
        public void RemovePoints() {
            Points -= 10;
        }
        public void EndGame() {
            Debug.Log("END");
        }

        void Update()
        {
            GameTimer.Count();
            GameTimeUI.text = GameTimer.FormattedTime;
            ScoreUI.text = Points.ToString();
        }
    }

}

