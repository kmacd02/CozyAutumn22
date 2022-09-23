using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mechanic : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    [SerializeField] private Image dialogue;
    [SerializeField] private TextMeshProUGUI text;

    private bool isSpeaking;

    // Start is called before the first frame update
    void Start()
    {
        bubble.SetActive(false);
        dialogue.enabled = false;
        text.enabled = false;
        isSpeaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Speak()
    {
        if (!isSpeaking)
        {
            //speech bubble above head
            bubble.SetActive(true);
            //UI dialogue box
            dialogue.enabled = true;
            isSpeaking = true;
            text.enabled = true;
            return;
        }

        else
        {
            bubble.SetActive(false);
            dialogue.enabled = false;
            isSpeaking = false;
            text.enabled = false;
            return;
        }
        
    }
}
