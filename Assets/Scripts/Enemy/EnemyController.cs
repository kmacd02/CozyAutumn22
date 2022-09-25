using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private AIPath aiPath;

    private Vector3 dir;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();

        GetComponent<AIDestinationSetter>().target = GameManager.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        dir = aiPath.desiredVelocity;
        animator.SetFloat("DirX", dir.x);

        if (aiPath.reachedDestination && !attacking)
        {
            attacking = true;
            aiPath.canMove = false;
            StartCoroutine(Attack());
        }
    }
    
    #region Stun

    public void Stun()
    {
        animator.Play("Death");
        aiPath.canMove = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    #endregion
    
    #region Attack

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0f);
        animator.SetTrigger("Attack");
    }

    public void FinishAttack()
    {
        aiPath.canMove = true;
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerController p = col.GetComponent<PlayerController>();
        if (p != null)
        {
            p.DecrementHealth(1);
        }
    }

    #endregion
}
