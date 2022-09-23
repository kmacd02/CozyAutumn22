using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private BossHand claw1;
    [SerializeField] private BossHand claw2;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(handAttack), 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.player.transform.position.x > transform.position.x)
        {
            
        }
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
}
