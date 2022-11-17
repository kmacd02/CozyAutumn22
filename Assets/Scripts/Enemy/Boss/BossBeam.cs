using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeam : MonoBehaviour
{
    public enum States
    {
        Idle,
        Active
    }

    [SerializeField] public GameObject enemy;
    
    [NonSerialized] public States curState = States.Idle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curState == States.Active)
        {
            transform.eulerAngles += new Vector3(0, 0, Time.deltaTime * 20f);
        }
    }

    public void startSpin()
    {
        curState = States.Active;
        InvokeRepeating("spawnEnemy", 2, 2);
    }

    public void stopSpin()
    {
        curState = States.Idle;
        transform.eulerAngles = Vector3.zero;
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(curState == States.Idle) return;

        PlayerController p = col.GetComponent<PlayerController>();
        if (p != null)
        {
            p.DecrementHealth(2);
        }
    }

    public void spawnEnemy()
    {
        Instantiate(enemy, transform.parent.transform.position, Quaternion.identity);
    }
}
