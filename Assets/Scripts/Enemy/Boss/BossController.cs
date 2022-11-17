using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    enum States
    {
        Idle,
        Claw,
        Beam
    }

    private States curState = States.Idle;
    [SerializeField] private float speed;
    private Vector3 startPos;
    
    private Animator animator;
    
    [SerializeField] private BossHand claw1;
    [SerializeField] private BossHand claw2;

    [SerializeField] private Transform[] beamPositions;
    private int curBeamPos = 0;
    [SerializeField] private BossBeam beam;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startPos = transform.position;
        StartCoroutine(startBoss());
    }

    // Update is called once per frame
    void Update()
    {
        if (curState == States.Beam)
        {
            flipSprite(beam.transform.eulerAngles.z is > 90 and < 270);
            transform.position =
                Vector3.MoveTowards(transform.position, beamPositions[curBeamPos].position, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, beamPositions[curBeamPos].position) < 0.1f)
            {
                curBeamPos++;
                if (curBeamPos >= beamPositions.Length)
                {
                    curBeamPos = 0;
                    curState = States.Idle;
                    beam.stopSpin();
                    animator.Play("SnowAttackEnd");
                }
            }
        }
        else
        {
            flipSprite(GameManager.player.transform.position.x > transform.position.x);
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * speed);

            if (curState == States.Claw)
            {
                if (claw1.curState == BossHand.States.Bobbing && claw2.curState == BossHand.States.Bobbing)
                    curState = States.Idle;
            }
        }
    }

    public IEnumerator startBoss()
    {
        yield return new WaitForSeconds(1);
        yield return handAttackCoroutine();
        yield return new WaitUntil(() => curState == States.Idle);
        yield return new WaitForSeconds(1);
        snowAttack();
        yield return new WaitUntil(() => curState == States.Idle);
        yield return new WaitForSeconds(1);
        yield return handAttackCoroutine();
        yield return new WaitUntil(() => curState == States.Idle);
        yield return new WaitForSeconds(5);
        
        StartCoroutine(startBoss());
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
        curState = States.Claw;
    }

    void snowAttack()
    {
        animator.Play("SnowAttack");
        beam.startSpin();
        curState = States.Beam;
    }
}
