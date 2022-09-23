using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private ParticleSystem sparks;
    [SerializeField] private GameObject light;

    private float distance = 100f;
    
    [NonSerialized] public bool inInnerRadius = false;
    [NonSerialized] public bool inOuterRadius = false;

    private bool isOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(GameManager.player.transform.position, transform.position);
        inOuterRadius = distance < 6 && isOn;
        inInnerRadius = distance < 4 && isOn;
    }

    public void Light()
    {
        sparks.Play();
        sparks.Emit(20);
        GetComponent<Animator>().Play("Lit");
        light.SetActive(true);
        FindObjectOfType<GameManager>().updateLamps(this);
        isOn = true;
    }
}
