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

    //private bool attacking = false;

    private int health = 3;


    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = aiPath.desiredVelocity;
        animator.SetFloat("DirX", dir.x);
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

    //#region Attack
    //public void OnAttack(InputValue input)
    //{
    //    if (attacking) return;

    //    animator.SetTrigger("Attack");
    //    attacking = true;
    //}

    //#endregion
}
