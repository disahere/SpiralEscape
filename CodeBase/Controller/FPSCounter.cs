using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Controller
{
    public class FPSCounter : MonoBehaviour
    {
        public Text fpsText;
        public float updateInterval = 0.5f;

        private float _accum;
        private int _frames;
        private float _timeleft;

        private void Start()
        {
            _timeleft = updateInterval;
        }

        private void Update()
        {
            _timeleft -= Time.deltaTime;
            _accum += Time.timeScale / Time.deltaTime;
            _frames++;

            if (!(_timeleft <= 0.0)) return;
            float fps = _accum / _frames;
            string fpsTextString = string.Format("FPS: {0:F2}", fps);
            fpsText.text = fpsTextString;

            _timeleft = updateInterval;
            _accum = 0;
            _frames = 0;
        }
    }
}
