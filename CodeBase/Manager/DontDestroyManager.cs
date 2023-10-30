using UnityEngine;

namespace CodeBase.Manager
{
    public class DontDestroyManager : MonoBehaviour
    {
        private static bool _created;

        private void Awake()
        {
            if (!_created)
            {
                DontDestroyOnLoad(this.gameObject);
                _created = true;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}