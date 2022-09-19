using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using 

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    private int DirX;

    //private bool attacking = false;

    private int health = 3;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //target = GetComponent<AIDestinationSetter>
        //DirX = GetComponent<>
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //#region Attack
    //public void OnAttack(InputValue input)
    //{
    //    if (attacking) return;

    //    animator.SetTrigger("Attack");
    //    attacking = true;
    //}

    //#endregion
}
