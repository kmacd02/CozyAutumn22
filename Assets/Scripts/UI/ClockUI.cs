using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private Image clockUI;
    [SerializeField] private Sprite[] sprites;

    public void UpdateSprite(int time)
    {
        if (time < 0 || time > 7)
        {
            return;
        }

        clockUI.sprite = sprites[time];

    }
}
