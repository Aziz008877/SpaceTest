using System;
using Enemy;
using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        private float _bulletFlySpeed = 15;
        private float _bulletDestroyValue = 15;
        public static Action OnAsteroidKilled;
        private void Update()
        {
            transform.Translate(-transform.up * _bulletFlySpeed * Time.deltaTime);

            if (transform.position.y > _bulletDestroyValue)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Asteroid asteroid))
            {
                OnAsteroidKilled?.Invoke();
                Destroy(asteroid.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
