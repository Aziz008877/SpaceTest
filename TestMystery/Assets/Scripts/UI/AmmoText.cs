using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class AmmoText : MonoBehaviour
    {
        private TextMeshProUGUI _ammoText;

        private void Awake()
        {
            _ammoText = GetComponent<TextMeshProUGUI>();
            DisplayAmmoCount(15);
        }

        public void DisplayAmmoCount(int ammoValue)
        {
            _ammoText.text = $"Ammo Left: {ammoValue}";
        } 
    }
}
