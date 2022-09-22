using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lantern : MonoBehaviour
{
    [SerializeField] private Light2D light;
    [SerializeField] private float maxRadius;
    
    private List<GameObject> hits = new List<GameObject>();
    private Collider2D hitbox;
    private PlayerController pc;
    
    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<Collider2D>();
        pc = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Math.Abs(pc.Direction.magnitude - 1) < 0.01f)
            transform.localPosition = pc.Direction * 0.5f;
    }

    public void toggleWeapon(bool b)
    {
        hitbox.enabled = b;
        if(b == false) hits.Clear();
    }

    public void updateLight(float lightPercentage)
    {
        light.pointLightOuterRadius = maxRadius * lightPercentage;
        light.pointLightInnerRadius = maxRadius * (2f / 5f) * lightPercentage;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (hits.Contains(col.gameObject)) return;

        Lamp l = col.GetComponent<Lamp>();
        if (l != null)
        {
            l.Light();
            hits.Add(col.gameObject);
        }
        
        GasPump g = col.GetComponent<GasPump>();
        if (g != null)
        {
            pc.DecrementHealth(-999);
            hits.Add(col.gameObject);
        }
        
        EnemyController e = col.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Stun();
            hits.Add(col.gameObject);
        }
    }
}
