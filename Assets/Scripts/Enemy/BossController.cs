using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator animator;
    
    [SerializeField] private BossHand claw1;
    [SerializeField] private BossHand claw2;
    [SerializeField] private GameObject beam;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("handAttack", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        flipSprite(GameManager.player.transform.position.x > transform.position.x);
    }
    
    void flipSprite(bool b)
    {
        claw1.gameObject.GetComponent<SpriteRenderer>().flipX = b;
        claw2.gameObject.GetComponent<SpriteRenderer>().flipX = b;
        GetComponent<SpriteRenderer>().flipX = b;
    }

    void handAttack()
    {
        StartCoroutine(handAttackCoroutine());
    }

    IEnumerator handAttackCoroutine()
    {
        claw1.StartAttack();
        yield return new WaitForSeconds(1f);
        claw2.StartAttack();
    }

    void snowAttack()
    {
        animator.Play("SnowAttack");
    }
}
