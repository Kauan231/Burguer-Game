using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core {
    public class Timer
    {
        public float _seconds, _timer = 0f;
        public float _minutes = 2f;
        public bool FinishGame = false;
        public string FormattedTime;
        public void Count()
        {
            if(FinishGame) return;

            _seconds -= Time.deltaTime;
            if(_seconds <= 0 && _minutes <= 0) {
                FinishGame = true;
            } 
            if(_seconds <= 0 && _minutes > 0) {
                _minutes--;
                _seconds = 60f;
            }
            FormattedTime = string.Format("{0:0}:{1:00}", _minutes, _seconds);
        }
    }
}

