using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private ParticleSystem sparks;
    [SerializeField] private GameObject light;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Light()
    {
        sparks.Play();
        GetComponent<Animator>().Play("Lit");
        light.SetActive(true);
    }
}
