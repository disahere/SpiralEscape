using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Manager
{
    public class ButtonManager : MonoBehaviour
    {
        public bool isPaused;

        void Update()
        {
            Time.timeScale = isPaused ? 0 : 1;
        }
        
        public void OnPauseButtonClicked()
        {
            isPaused = true;
        }

        public void OnResumeButtonClicked()
        {
            isPaused = false;
        }
        
        public void OnQuitGameButtonClicked()
        {
            Application.Quit();
        }
        
        public void OnRestartGameButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OnPlayGameButtonClicked()
        {
            SceneManager.LoadScene("LoadingGame");
        }

        public void OnBackMenuButtonClicked()
        {
            SceneManager.LoadScene("LoadingMenu");
        }
    }
}
