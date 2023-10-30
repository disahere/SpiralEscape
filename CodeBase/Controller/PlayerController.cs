using CodeBase.Movement;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CircleMovement circleMovement;
        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private Text collectedCoinsText;
        
        [SerializeField] public AudioSource soundDeath;
        [SerializeField] public AudioSource soundCoin;

        private int _collectedCoins;
        void Start()
        {
            _collectedCoins = 0;
            UpdateCollectedCoinsText();
        }

        private void UpdateCollectedCoinsText()
        {
            collectedCoinsText.text = " " + _collectedCoins;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Coin"))
            {
                if (soundCoin != null)
                {
                    soundCoin.Play();
                }
                
                _collectedCoins++;
                UpdateCollectedCoinsText();
                other.gameObject.SetActive(false);
                
                circleMovement.GenerateRandomCoinPosition(coinPrefab);
            }
            else if (other.CompareTag("Plate"))
            {
                if (soundDeath != null)
                {
                    soundDeath.Play();
                }
                
                gameObject.SetActive(false);
            }
        }
    }
}