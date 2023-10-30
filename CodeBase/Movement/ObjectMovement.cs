using UnityEngine;

namespace CodeBase.Movement
{
    public class ObjectMovement : MonoBehaviour
    {
        [SerializeField]private float speed;
        
        private bool _hasReachedTarget;
        public Transform followTarget;
        public Transform teleportLocation;

        void Update()
        {
            if (_hasReachedTarget) return;
            Vector3 newPosition = Vector3.MoveTowards(transform.position, followTarget.position, speed * Time.deltaTime);
            transform.position = newPosition;

            if (transform.position != followTarget.position) return;
            _hasReachedTarget = false;
            transform.position = teleportLocation.position;
        }
    }
}