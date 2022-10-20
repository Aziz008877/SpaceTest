using Player;
using UnityEngine;

namespace Enemy
{
    public class Asteroid : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PlayerMove player))
            {
                HpSlider playerHp = FindObjectOfType<HpSlider>();
                
                playerHp.DecreaseHpValue(1);
            }
        }
    }
}
