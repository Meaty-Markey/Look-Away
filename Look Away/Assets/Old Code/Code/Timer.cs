using System;
using TMPro;
using UnityEngine;

namespace Old_Code.Code
{
    public class Timer : MonoBehaviour
    {
        public TMP_Text timerOut;
        private float _timeleft;

        private void Update()
        {
            _timeleft += Time.deltaTime;
            timerOut.text = $"Time: {Math.Round(_timeleft, 2)}";
        }
    }
}