using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Manager
{
    [System.Serializable]
    public class SceneInfo
    {
        public string sceneName;
        public float delay;
    }

    public class SceneLoader : MonoBehaviour
    {
        public List<SceneInfo> sceneList = new List<SceneInfo>();
        private int _currentIndex;

        private void Start()
        {
            LoadNextScene();
        }

        private void LoadNextScene()
        {
            if (_currentIndex < sceneList.Count)
            {
                StartCoroutine(LoadSceneWithDelay(sceneList[_currentIndex].sceneName, sceneList[_currentIndex].delay));
                _currentIndex++;
            }
        }

        private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(sceneName);
        }
    }
}