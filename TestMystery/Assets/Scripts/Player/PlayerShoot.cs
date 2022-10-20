using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerShoot : MonoBehaviour, IShootable
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private int _bulletCount;
        [SerializeField] private UnityEvent<int> _onPlayerShoot;

        public void Shoot()
        {
            if (_bulletCount > 0)
            {
                _bulletCount--;
                _onPlayerShoot?.Invoke(_bulletCount);
                Instantiate(_bullet, transform.position, Quaternion.Euler(0,0, 90));
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }
}
