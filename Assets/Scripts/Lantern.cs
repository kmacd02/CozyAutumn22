using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
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
        
    }

    public void toggleWeapon(bool b)
    {
        hitbox.enabled = b;
        if(b == false) hits.Clear();
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
    }
}
