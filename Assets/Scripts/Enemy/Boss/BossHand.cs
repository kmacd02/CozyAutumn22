using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossHand : MonoBehaviour
{
    public enum States
    {
        Bobbing,
        Attacking,
        Retreating
    }
    [NonSerialized] public States curState = States.Bobbing;
    private Vector3 startPos;
    private Vector3 targetPos;
    private float offset;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        offset = Random.value * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (curState == States.Bobbing)
        {
            transform.localPosition = startPos + Vector3.up * Mathf.Cos(Time.time * 2 + offset) * 0.2f;
        }

        if (curState == States.Attacking)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 3);
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                curState = States.Retreating;
            }
        }

        if (curState == States.Retreating)
        {
            transform.position = Vector3.Lerp(transform.position, startPos + transform.parent.position, Time.deltaTime * 3);
            if (Vector3.Distance(transform.position, startPos + transform.parent.position) < 0.1f)
            {
                curState = States.Bobbing;
            }
        }
    }

    public void StartAttack()
    {
        targetPos = GameManager.player.transform.position + (GameManager.player.transform.position - transform.position).normalized * 4f;
        curState = States.Attacking;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(curState == States.Bobbing) return;

        PlayerController p = col.GetComponent<PlayerController>();
        if (p != null)
        {
            p.DecrementHealth(1);
        }
    }
}
