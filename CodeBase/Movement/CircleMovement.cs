using UnityEngine;

namespace CodeBase.Movement
{
    public class CircleMovement : MonoBehaviour
    {
        [SerializeField] private Transform center;
        [SerializeField] private float radius, angularSpeed;
        
        [SerializeField] public AudioSource audioSource;

        private int _direction = 1;
        private float _positionX, _positionY, _angle;

        private void Update()
        {
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)||Input.GetKeyDown(KeyCode.Space))
            {
                _direction *= -1;
                
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }

            _angle = (_angle + Time.deltaTime * angularSpeed * _direction) % 360f;

            var position = center.position;
            _positionX = position.x + Mathf.Cos(_angle * Mathf.Deg2Rad) * radius;
            _positionY = position.y + Mathf.Sin(_angle * Mathf.Deg2Rad) * radius;
            transform.position = new Vector2(_positionX, _positionY);
        }

        public void GenerateRandomCoinPosition(GameObject coinPrefab)
        {
            if (coinPrefab != null)
            {
                float randomAngle = Random.Range(0f, 360f);
                float randomRotation = Random.Range(0f, 360f);

                Vector3 position = center.position;
                float x = position.x + Mathf.Cos(randomAngle * Mathf.Deg2Rad) * radius;
                float y = position.y + Mathf.Sin(randomAngle * Mathf.Deg2Rad) * radius;
                Vector3 newPosition = new Vector3(x, y, 0f);

                GameObject inactiveCoin = GameObject.FindWithTag("Coin");

                if (inactiveCoin != null)
                {
                    inactiveCoin.SetActive(true);
                    inactiveCoin.transform.position = newPosition;
                    
                    inactiveCoin.transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
                }
                else
                {
                    GameObject newCoin = Instantiate(coinPrefab, newPosition, Quaternion.Euler(0f, 0f, randomRotation));
                    newCoin.SetActive(true);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            var centerPosition = center.position;
            Gizmos.DrawWireSphere(centerPosition, radius);
        }
    }
}