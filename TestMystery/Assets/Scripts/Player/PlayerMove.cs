using System;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour, IMovable
    {
        [SerializeField] private float _baseSpeed, _slowSpeed, _increasedSpead;
        private Vector2 _moveVector;

        private void IncreaseSpeed()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _baseSpeed = _increasedSpead;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _baseSpeed = _slowSpeed;
            }
        }
        
        public void Move()
        {
            float horizontalSpeed = Input.GetAxis("Horizontal");
            _moveVector = new Vector2(horizontalSpeed, 0) * _baseSpeed * Time.deltaTime;
            transform.Translate(_moveVector);
            
            var clampedXPos = transform.position;
            clampedXPos.x =  Mathf.Clamp(transform.position.x, -6, 6);
            transform.position = clampedXPos;
        }
        
        private void Update()
        {
            Move();
            IncreaseSpeed();
        }

        
    }
}
