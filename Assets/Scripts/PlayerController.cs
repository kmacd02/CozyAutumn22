using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Lantern lantern;

    public Vector2 Direction => dir;
    private Vector2 dir = Vector2.zero;
    private bool attacking = false;

    [SerializeField] private int maxHealth = 5;
    private int health = 5;
    
    [SerializeField] private float speed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lantern = GetComponentInChildren<Lantern>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("DirX", Direction.x);
        if (attacking)
        {
            rb.velocity = new Vector2( dir.x * speed * 0.05f, 0);
        }
        else
        {
            rb.velocity = dir * speed;
        }

        GameManager.fuelUI.UpdateSprite(health);
    }

    public void OnMove(InputValue input)
    {
        dir = input.Get<Vector2>();
    }

    public void DecrementHealth(int damage)
    {
        if (health == 0 && damage > 0)
        {
            SceneManager.LoadScene("Death");
            return;
        }
        
        health -= damage;
        
        if (health < 0)
        {
            health = 0;
        }else if (health > maxHealth)
        {
            health = maxHealth;
        }
        
        lantern.updateLight((float) health /maxHealth);

        if (damage > 0) StartCoroutine(DamageFlash());
        else StartCoroutine(HealFlash());
    }

    private IEnumerator DamageFlash()
    {
        animator.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.0833f);
        animator.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
    
    private IEnumerator HealFlash()
    {
        animator.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.0833f);
        animator.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
    
    #region Attack
    public void OnAttack(InputValue input)
    {
        if(attacking) return;
        
        animator.SetTrigger("Attack");
        attacking = true;
    }

    public void BeginAttack()
    {
        lantern.toggleWeapon(true);
    }

    public void EndAttack()
    {
        lantern.toggleWeapon(false);
        animator.ResetTrigger("Attack");
        attacking = false;
    }

    #endregion
}
