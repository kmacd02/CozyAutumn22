using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector2 Direction => dir;
    private Vector2 dir = Vector2.zero;

    private Lantern lantern;
    
    [SerializeField] private float speed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lantern = GetComponentInChildren<Lantern>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputValue input)
    {
        dir = input.Get<Vector2>();
        rb.velocity = dir * speed;
    }

    public void OnAttack(InputValue input)
    {
        lantern.toggleWeapon(true);
        StartCoroutine(testOnlyStopAttack());
    }

    IEnumerator testOnlyStopAttack()
    {
        yield return new WaitForSeconds(0.2f);
        lantern.toggleWeapon(false);
    }
}
