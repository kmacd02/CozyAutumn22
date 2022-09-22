using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour
{
    [SerializeField] private Image fuelUI;
    [SerializeField] private Sprite[] sprites;

    public void UpdateSprite(int fuel)
    {
        if (fuel < 0 || fuel > 5)
        {
            return;
        }

        fuelUI.sprite = sprites[fuel];
               
    }
}
