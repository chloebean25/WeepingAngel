using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


namespace MyLibrary
{



    public class Timer : MonoBehaviour
    {
        private float m_timeLeft = 0.0f;



        public UnityEvent timeout;
        public bool autoStart = true;
        public bool autoRestart = false;
        public bool useScaledTime = true;
        public float countDownTime = 1.0f;
        public float timeScale = 1.0f;
        public float timeLeft { get { return m_timeLeft;} }
        public bool countingDown { get { return m_timeLeft > 0.0f; } }
        public TMP_Text timerText;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (autoStart)
            {
                StartTimer();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(m_timeLeft > 0.0f)
            {
                if (useScaledTime)
                    m_timeLeft -= (Time.deltaTime * timeScale);
                else
                    m_timeLeft -= (Time.unscaledDeltaTime * timeScale);
                if (m_timeLeft <= 0.0f)
                {
                    timeout.Invoke();

                    if (autoRestart)
                    {
                        StartTimer();
                    }
                }
            }
            UpdateTimerUI();
        }
        void UpdateTimerUI()
        {
            float seconds = Mathf.Max(m_timeLeft, 0);
            int minutes = Mathf.FloorToInt(seconds / 60);
            int remainingSeconds = Mathf.FloorToInt(seconds % 60);

            timerText.text = string.Format("{0:D2}:{1:D2}", minutes, remainingSeconds);

        }
        public void StartTimerFromEvent()
        {
            StartTimer();
        }

        public void StopTimer()
        {
            m_timeLeft = 0.0f;
        }

        public void StartTimer(float? _countDown = null,bool _autoRestart = false)
        {
            if (_countDown != null && _countDown > 0.0f)
                countDownTime = (float) _countDown;

            autoRestart = _autoRestart;

            m_timeLeft = countDownTime;
        }
    }
}

